namespace ElectricityTariffication.CalculationModels
{
    public class PackagedTariffCalculationModel : ICalculationModel
    {
        private const int CentsInEuro = 100;
        public decimal YearlyBasePriceInEuro { get; set; }
        public decimal ConsumptionPriceBeyondThresholdInCents { get; set; }
        public decimal YearlyEnergyConsumptionThreshold { get; set; }

        public PackagedTariffCalculationModel(
            decimal yearlyBasePriceInEuro,
            decimal consumptionPriceBeyondThresholdInCents,
            decimal yearlyEnergyConsumptionThreshold)
        {
            YearlyBasePriceInEuro = yearlyBasePriceInEuro;
            ConsumptionPriceBeyondThresholdInCents = consumptionPriceBeyondThresholdInCents;
            YearlyEnergyConsumptionThreshold = yearlyEnergyConsumptionThreshold;
        }

        public decimal CalculateYearlyPrice(decimal yearlyEnergyConsumption)
        {
            var consumptionBeyondThreshold = Math.Max(yearlyEnergyConsumption - YearlyEnergyConsumptionThreshold, 0);

            return YearlyBasePriceInEuro + consumptionBeyondThreshold * ConsumptionPriceBeyondThresholdInCents / CentsInEuro;
        }
    }
}