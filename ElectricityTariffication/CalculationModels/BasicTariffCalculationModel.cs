namespace ElectricityTariffication.CalculationModels
{
    public class BasicTariffCalculationModel : ICalculationModel
    {
        private const int CentsInEuro = 100;
        private const int MonthesInYear = 12;
        public decimal MonthlyBasePriceInEuro { get; set; }
        public decimal ConsumptionPriceInCents { get; set; }

        public BasicTariffCalculationModel(decimal monthlyBasePriceInEuro, decimal consumptionPriceInCents)
        {
            MonthlyBasePriceInEuro = monthlyBasePriceInEuro;
            ConsumptionPriceInCents = consumptionPriceInCents;
        }

        public decimal CalculateYearlyPrice(decimal yearlyEnergyConsumption)
        {
            return MonthesInYear * MonthlyBasePriceInEuro + yearlyEnergyConsumption * ConsumptionPriceInCents / CentsInEuro;
        }
    }
}