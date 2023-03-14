namespace ElectricityTariffication
{
    public class ComparisonEvaluator
    {
        private readonly List<Product> _products;

        public ComparisonEvaluator(List<Product> products)
        {
            _products = products;
        }

        public List<EvaluatedProduct> Evaluate(decimal yearlyEnergyConsumption)
        {
            var evaluatedProducts = _products
                .Select(product => Evaluate(product, yearlyEnergyConsumption))
                .OrderBy(result => result.AnnualCosts)
                .ToList();

            return evaluatedProducts;
        }

        private static EvaluatedProduct Evaluate(Product product, decimal yearlyEnergyConsumption)
        {
            var yearlyPrice = product.CalculationModel.CalculateYearlyPrice(yearlyEnergyConsumption);

            return new EvaluatedProduct(product.TariffName, yearlyPrice);
        }
    }
}