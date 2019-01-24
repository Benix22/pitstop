namespace Pitstop.ContractManagementAPI.Model
{
    public class Rate
    {
        public int RateId { get; set; }

        public string Nombre { get; set; }
        public string Poliza { get; set; }
        public string Grupo { get; set; }
        public int Dias { get; set; }
        public decimal Precio { get; set; }
    }
}
