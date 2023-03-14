# ElectricityTariffication

## Requirements
* VisualStudio 2022
* .NET 6 SDK

## Potential improvements
* Add data validation for domain models
* Use IProductsRepository to provide list of products to evaluator to simplify integration with data sources
* Consider using IPricingRule abstraction to make tariffication models more flexible (make sense only if have a lot of tariffication models with inconsistent rules)
