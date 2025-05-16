var taxList = new List<TaxRecord>
{
    new() {
        Municipality = "Copenhagen",
        FromDate = new DateOnly(2025, 01, 01),
        ToDate = new DateOnly(2025, 12, 31),
        TaxRate = 0.2,
        TaxType = "Yearly"
    },
    new() {
        Municipality = "Copenhagen",
        FromDate = new DateOnly(2025, 05, 01),
        ToDate = new DateOnly(2025, 05, 31),
        TaxRate = 0.4,
        TaxType = "Monthly"
    },
    new() {
        Municipality = "Copenhagen",
        FromDate = new DateOnly(2025, 01, 01),
        ToDate = new DateOnly(2025, 01, 01),
        TaxRate = 0.1,
        TaxType = "Daily"
    },
    new() {
        Municipality = "Copenhagen",
        FromDate = new DateOnly(2025, 12, 25),
        ToDate = new DateOnly(2025, 12, 25),
        TaxRate = 0.1,
        TaxType = "Daily"
    }
};

foreach (var tax in taxList)
{
    Console.WriteLine($"{tax.Municipality} from {tax.FromDate} to {tax.ToDate} has a {tax.TaxType} tax of {tax.TaxRate}.");
}

if (!taxList.Any(record => record.TaxType == "Weekly"))
{
    Console.WriteLine("No weekly taxes scheduled.");
}