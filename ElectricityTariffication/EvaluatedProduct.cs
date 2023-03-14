namespace ElectricityTariffication
{
    public class EvaluatedProduct
    {
        public string TariffName { get; set; }
        public decimal AnnualCosts { get; set; }

        public EvaluatedProduct(string tariffName, decimal annualCosts)
        {
            TariffName = tariffName;
            AnnualCosts = annualCosts;
        }
    }
}