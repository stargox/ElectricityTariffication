using ElectricityTariffication.CalculationModels;

namespace ElectricityTariffication
{
    public class Product
    {
        public string TariffName { get; set; }
        public ICalculationModel CalculationModel { get; set; }

        public Product(string tariffName, ICalculationModel calculationModel)
        {
            TariffName = tariffName;
            CalculationModel = calculationModel;
        }
    }
}