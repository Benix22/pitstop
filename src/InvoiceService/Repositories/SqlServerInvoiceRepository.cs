using System;
using System.Threading.Tasks;
using Dapper;
using Pitstop.InvoiceService.Model;
using Polly;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Transactions;
using System.Linq;
using Serilog;

namespace Pitstop.InvoiceService.Repositories
{
    public class SqlServerInvoiceRepository : IInvoiceRepository
    {
        private string _connectionString;

        public SqlServerInvoiceRepository(string connectionString)
        {
            _connectionString = connectionString;

            // init db
            Policy
            .Handle<Exception>()
            .WaitAndRetry(5, r => TimeSpan.FromSeconds(5), (ex, ts) => { Log.Error("Error connecting to DB. Retrying in 5 sec."); })
            .Execute(() => InitializeDB());
        }

        private async void InitializeDB()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString.Replace("Invoicing", "master")))
            {
                conn.Open();

                // create database
                string sql =
                    "IF DB_ID('Invoicing') IS NULL CREATE DATABASE Invoicing;";

                await conn.ExecuteAsync(sql);

                // create tables
                conn.ChangeDatabase("Invoicing");

                sql = "IF OBJECT_ID('Customer') IS NULL " +
                        "CREATE TABLE Customer (" +
                        "[CustomerId] [nvarchar](450) NOT NULL," +
                       "[EsPersona][bit] NOT NULL," +
                       "[Nombre] [nvarchar] (max) NOT NULL," +
                       "[Pais] [nvarchar] (max) NULL," +
                       "[NIF] [nvarchar] (max) NOT NULL," +
                       "[FechaAlta] [datetime2] (7) NOT NULL," +
                       "[FechaBaja] [datetime2] (7) NULL," +
                       "[Direccion] [nvarchar] (max) NOT NULL," +
                       "[PaisDireccion] [nvarchar] (max) NULL," +
                       "[CodigoPostal] [nvarchar] (max) NOT NULL," +
                       "[Poblacion] [nvarchar] (max) NOT NULL," +
                       "[Provincia] [nvarchar] (max) NOT NULL," +
                       "[Telefono] [nvarchar] (max) NOT NULL," +
                       "[Telefono2] [nvarchar] (max) NULL," +
                       "[Movil] [nvarchar] (max) NULL," +
                       "[FechaExpNIF] [datetime2] (7) NOT NULL," +
                       "[PoblacionExpNIF] [nvarchar] (max) NULL," +
                       "[FechaNacimiento] [datetime2] (7) NOT NULL," +
                       "[PoblacionNacimiento] [nvarchar] (max) NULL," +
                       "[TipoPermiso] [nvarchar] (max) NOT NULL," +
                       "[NumeroPermiso] [nvarchar] (max) NOT NULL," +
                       "[FechaExpPermiso] [datetime2] (7) NOT NULL," +
                       "[FechaCadPermiso] [datetime2] (7) NOT NULL," +
                       "[Email] [nvarchar] (max) NOT NULL," +
                       "[Moroso] [bit] NOT NULL," +
                       "[Bloqueado] [bit] NOT NULL," +
                       "[NumeroTarjetaCred] [nvarchar] (max) NOT NULL," +
                       "[TitularTarjetaCred] [nvarchar] (max) NOT NULL," +
                       "[FechaCadTarjetaCred] [datetime2] (7) NOT NULL," +
                       "  PRIMARY KEY(CustomerId));" +

                      "IF OBJECT_ID('MaintenanceJob') IS NULL " +
                      "CREATE TABLE MaintenanceJob (" +
                      "  JobId varchar(50) NOT NULL," +
                      "  LicenseNumber varchar(50) NOT NULL," +
                      "  CustomerId varchar(50) NOT NULL," +
                      "  Description varchar(250) NOT NULL," +
                      "  StartTime datetime2 NULL," +
                      "  EndTime datetime2 NULL," +
                      "  Finished bit NOT NULL," +
                      "  InvoiceSent bit NOT NULL," +
                      "  PRIMARY KEY(JobId));" +

                      "IF OBJECT_ID('Invoice') IS NULL " +
                      "CREATE TABLE Invoice (" +
                      "  InvoiceId varchar(50) NOT NULL," +
                      "  InvoiceDate datetime2 NOT NULL," +
                      "  CustomerId varchar(50) NOT NULL," +
                      "  Amount decimal(5,2) NOT NULL," +
                      "  Specification text," +
                      "  JobIds varchar(250)," +
                      "  PRIMARY KEY(InvoiceId));";

                await conn.ExecuteAsync(sql);
            }
        }

        public async Task<Customer> GetCustomerAsync(string customerId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                return await conn.QueryFirstOrDefaultAsync<Customer>("select * from Customer where CustomerId = @CustomerId",
                    new { CustomerId = customerId });
            }
        }

        public async Task RegisterMaintenanceJobAsync(MaintenanceJob job)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql =
                    "insert into MaintenanceJob(JobId, LicenseNumber, CustomerId, Description, Finished, InvoiceSent) " +
                    "values(@JobId, @LicenseNumber, @CustomerId, @Description, 0, 0);";
                await conn.ExecuteAsync(sql, job);
            }
        }

        public async Task RegisterCustomerAsync(Customer customer)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql =
                    "INSERT INTO[dbo].[Customer] ([CustomerId] ,[EsPersona] ,[Nombre] ,[Pais] ,[NIF] ,[FechaAlta] ,[FechaBaja] ,[Direccion]" +
                    ",[PaisDireccion] ,[CodigoPostal] ,[Poblacion] ,[Provincia] ,[Telefono] ,[Telefono2] ,[Movil] ,[FechaExpNIF] ,[PoblacionExpNIF]" +
                    ",[FechaNacimiento] ,[PoblacionNacimiento] ,[TipoPermiso] ,[NumeroPermiso] ,[FechaExpPermiso] ,[FechaCadPermiso] ,[Email] ,[Moroso]" +
                    ",[Bloqueado] ,[NumeroTarjetaCred] ,[TitularTarjetaCred] ,[FechaCadTarjetaCred]) " +
                    "VALUES  (@CustomerId, @EsPersona, @Nombre, @Pais, @NIF, @FechaAlta, @FechaBaja, @Direccion, @PaisDireccion, @CodigoPostal" +
                    ", @Poblacion, @Provincia, @Telefono, @Telefono2, @Movil, @FechaExpNIF, @PoblacionExpNIF, @FechaNacimiento, @PoblacionNacimiento" +
                    ", @TipoPermiso, @NumeroPermiso, @FechaExpPermiso, @FechaCadPermiso, @Email, @Moroso ,@Bloqueado, @NumeroTarjetaCred, @TitularTarjetaCred" +
                    ", @FechaCadTarjetaCred);";
                await conn.ExecuteAsync(sql, customer);
            }
        }

        public async Task MarkMaintenanceJobAsFinished(string jobId, DateTime startTime, DateTime endTime)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query =
                    "update MaintenanceJob " +
                    "set StartTime = @StartTime, " +
                    "    EndTime = @EndTime, " +
                    "    Finished = 1 " +
                    "where JobId = @JobId";
                await conn.ExecuteAsync(query, new { JobId = jobId, StartTime = startTime, EndTime = endTime });
            }
        }

        public async Task<IEnumerable<MaintenanceJob>> GetMaintenanceJobsToBeInvoicedAsync()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query =
                    "select * from MaintenanceJob " +
                    "where Finished = 1 " +
                    "and InvoiceSent = 0";
                return await conn.QueryAsync<MaintenanceJob>(query);
            }
        }

        public async Task RegisterInvoiceAsync(Invoice invoice)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // persist invoice
                string sql =
                    "insert into Invoice(InvoiceId, InvoiceDate, CustomerId, Amount, Specification, JobIds) " +
                    "values(@InvoiceId, @InvoiceDate, @CustomerId, @Amount, @Specification, @JobIds);";
                await conn.ExecuteAsync(sql, invoice);

                // update jobs to indicate invoice sent
                var jobIds = invoice.JobIds.Split('|').Select(jobId => new { JobId = jobId });
                sql =
                    "update MaintenanceJob " +
                    "set InvoiceSent = 1 " +
                    "where JobId = @JobId ";
                await conn.ExecuteAsync(sql, jobIds);
            }
        }
    }
}
