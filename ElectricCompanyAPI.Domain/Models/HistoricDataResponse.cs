namespace ElectricCompanyAPI.Domain
{
    public class HistoricDataResponse
    {
        public string Section { get; set; }
        public string CustomerType { get; set; }  // Tipo de cliente (Residential, Commercial, Industrial)
        public DateTime Date { get; set; }
        public decimal Consumption { get; set; }  // Consumo en kWh
        public decimal LossPercentage { get; set; } // Pérdida porcentual
        public decimal CostPerWh { get; set; }  // Costo por kWh
    }

}
