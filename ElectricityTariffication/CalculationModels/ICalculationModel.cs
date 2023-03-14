namespace ElectricityTariffication.CalculationModels
{
    public interface ICalculationModel
    {
        decimal CalculateYearlyPrice(decimal yearlyEnergyConsumption);
    }
}