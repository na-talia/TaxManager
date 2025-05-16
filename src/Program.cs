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

Console.Write("Input municipality: ");
var municipality = Console.ReadLine();

Console.Write("Input date (yyyy-MM-dd): ");
var dateInput = Console.ReadLine();

if (!string.IsNullOrWhiteSpace(municipality) && DateOnly.TryParse(dateInput, out var parsedDate))
{
    var taxRecord = taxList.FirstOrDefault(record =>
        record.Municipality == municipality && 
        parsedDate >= record.FromDate &&
        parsedDate <= record.ToDate
    );

    if (taxRecord != null)
    {
        Console.WriteLine($"Tax rate for {municipality} on {parsedDate} is {taxRecord.TaxRate}");
    }
    else
    {
        Console.WriteLine("No tax rate is available for the specified date.");


       /*  if (!taxList.Any(record => record.TaxType == "Weekly"))
        {
            Console.WriteLine("No weekly taxes scheduled.");
        } */
    }
}
else
{
    Console.WriteLine("Invalid format. Expected a valid municipality name and a date in yyyy-mm-dd format.");
}
