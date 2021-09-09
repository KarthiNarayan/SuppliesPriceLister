# SuppliesPriceLister

## Requirements

Create a console application which outputs both Humphries and Megacorp building supplies.
The information printed should be the ID, item name and price.
The supplies should be shown in a combined list.
The supplies should be ordered from most expensive to least expensive.
All prices must be shown to the nearest cent in AUD based on the exchange rate.

### Source Data
Both humphries.csv and megacorp.json contain lists of construction supplies and labour items.

#### megacorp.json
* ID should be unique
* All prices are in USD

#### humphries.csv
* All prices are in AUD

#### Exchange rate
* The exchange rate is found in appsettings.json.


### Live
Main - https://github.com/KarthiNarayan/SuppliesPriceLister/tree/main/Main

### CI/CD
Repository - GitHub Continous integration and delivery Implemented using the GitHub actions where the commit is automatically tested and published. Other Tools use in application

### Packages
* MoQ
* NUnit
* NewtonSoft
* File - IO


### Example Console Output Using Subset of Actual Data
7f3c48c4-f8b6-453f-b2fa-83ec31dfa85c, Bobcat to Dig LM of Strip Footing, $800.00

0a360e10-4e35-4e94-bd80-2e8bd6c749f1, Under Slab Sand 150mm, $77.24

1, 100 x 200 x 20mpa Internal Beam, $68.00


