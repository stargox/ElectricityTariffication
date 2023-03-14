using System.Collections.Generic;
using ElectricityTariffication.CalculationModels;
using FluentAssertions;
using Xunit;

namespace ElectricityTariffication.Tests
{
    public class ComparisonEvaluatorTest
    {
        private const string BasicTariffProductName = "basic electricity tariff";
        private const string PackagedTariffProductName = "Packaged tariff";

        private readonly Product _basicTariffProduct = new Product(
            BasicTariffProductName,
            new BasicTariffCalculationModel(
                monthlyBasePriceInEuro: 5,
                consumptionPriceInCents: 22));

        private readonly Product _packagedTariffProduct = new Product(
            PackagedTariffProductName,
            new PackagedTariffCalculationModel(
                yearlyBasePriceInEuro: 800,
                consumptionPriceBeyondThresholdInCents: 30,
                yearlyEnergyConsumptionThreshold: 4000));

        [Theory]
        [MemberData(nameof(ValidTheoryData))]
        public void GivenYearlyConsumptionShouldReturnListOfEvaluatedProductsInCorrespondingOrder(
            decimal yearlyEnergyConsumption,
            List<EvaluatedProduct> expectedEvaluatedProducts)
        {
            // Arrange
            var products = new List<Product> { _basicTariffProduct, _packagedTariffProduct };
            var tariffComparer = new ComparisonEvaluator(products);

            // Act
            var evaluatedProducts = tariffComparer.Evaluate(yearlyEnergyConsumption);

            // Assert
            evaluatedProducts.Should().BeEquivalentTo(expectedEvaluatedProducts, options => options.WithStrictOrdering());
        }

        public static TheoryData<decimal, List<EvaluatedProduct>> ValidTheoryData =>
            new TheoryData<decimal, List<EvaluatedProduct>>
                {
                    { 3500, new List<EvaluatedProduct> { new(PackagedTariffProductName, 800), new(BasicTariffProductName, 830) } },
                    { 4500, new List<EvaluatedProduct> { new(PackagedTariffProductName, 950), new(BasicTariffProductName, 1050) } },
                    { 6000, new List<EvaluatedProduct> { new(BasicTariffProductName, 1380),   new(PackagedTariffProductName, 1400) } },
                };
    }
}