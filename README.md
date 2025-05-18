# TaxManager Console App

A simple C# console application to manage municipal tax records.  
It allows users to retrieve and add taxes applied in different municipalities for specific time periods.

## Features

- Retrieve tax rate for a specific municipality and date
- Supports multiple tax types:
  - Daily
  - Weekly
  - Monthly
  - Yearly
- Applies correct tax based on date and **priority**:  
  `Daily > Weekly > Monthly > Yearly`
- Add new tax records via console
- Includes basic unit tests

## How to Run the App

1. Navigate to the app folder:

```
cd src
dotnet run
```

2. Choose an action:

`1` – Add a new tax record  
`2` – Retrieve a tax record  
`q` – Quit  

## How to Run the Test

```
cd Tests
dotnet test
```

## Notes

- Data is currently stored in-memory in InitialTaxData.cs, but the code is structured to allow easy replacement with a JSON file or a database in the future.

- Code is organized using OOP principles and can be extended.
