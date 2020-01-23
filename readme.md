# Avensia Developer Test

Here is the task that is a part of our recruitment process. Look through the materials and contact us if you have any questions and when you can present your solution for us.

On the presentation a Project Manager and a developer from Avensia will be present. In addition to the presentation, there is of course also the opportunity for technical discussions to get to know each other better.

You are expected to present the solution, how you designed it, what key elements you focused on and why.

Please keep in mind that the reason for the task is not only the end result but just as much how you approached the task. Use the solution to show us what you think is important for us to know about you, common design patterns, technical implementation, architectural design.

## Task

Included in this package you have `products.json` which is a list of products that the application should read. Currently the functionality of this application is very limited, and it needs to be extended.

### Some assumptions that can be made

* All prices specified in `products.json` are in USD
* You can change any file you want to
* You can use third-party nuget packages

### Tasks

* Read all products from the `products.json` file
* Cache the products you have read so the application doesn't need to read it from disk again.
* Implement any method that today throws an `NotImplementedException`
* When displaying the products, the prices should be show with the selected currency
* The user should have the option to change currency (in runtime)
* If another currency than USD is selected the prices then the prices should be converted e.g. (100 USD == 838 SEK)
* An option to list products in chunk of 5 (`ProductListVisualizer.cs`)
* An option to list all products grouped in 100 "currency" segments (`ProductListVisualizer.cs`) e.g.
```
0-100 kr
    Product A 75 kr
    Product B 100 kr
..
..
1500-1600 kr
    Product X 1565 kr
    Product Y 1595 kr

```

### Sample currency exchange rate matrix from USD to X

| Currency code | Exchange rate |
| ------------- | ------------- |
| USD           | 1.0           |
| GBP           | 0.71          |
| SEK           | 8.38          |
| DKK           | 6.06          |
