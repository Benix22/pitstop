namespace Pitstop.ContractManagementAPI.Model
{
    public class Tarifa
    {
        public int TarifaId { get; set; }

        public string Nombre { get; set; }
        public string Grupo { get; set; }
        public int Dias { get; set; }
        public decimal Precio { get; set; }
    }
}
