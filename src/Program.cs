var taxList = new List<TaxRecord>
{
    new() {
        Municipality = "Copenhagen",
        FromDate = new DateOnly(2025, 01, 01),
        ToDate = new DateOnly(2025, 12, 31),
        TaxRate = 0.2M,
        TaxType = "Yearly"
    },
    new() {
        Municipality = "Copenhagen",
        FromDate = new DateOnly(2025, 05, 01),
        ToDate = new DateOnly(2025, 05, 31),
        TaxRate = 0.4M,
        TaxType = "Monthly"
    },
    new() {
        Municipality = "Copenhagen",
        FromDate = new DateOnly(2025, 01, 01),
        ToDate = new DateOnly(2025, 01, 01),
        TaxRate = 0.1M,
        TaxType = "Daily"
    },
    new() {
        Municipality = "Copenhagen",
        FromDate = new DateOnly(2025, 12, 25),
        ToDate = new DateOnly(2025, 12, 25),
        TaxRate = 0.1M,
        TaxType = "Daily"
    }
};

Console.Write("Input municipality: ");
var municipality = Console.ReadLine()?.Trim();

Console.Write("Input date (YYYY-MM-DD): ");
var dateInput = Console.ReadLine()?.Trim();

if (!string.IsNullOrWhiteSpace(municipality) && DateOnly.TryParse(dateInput, out var parsedDate))
{

    // Filter tax records for the given municipality and date
    var filteredRecords = taxList.Where(record =>
    record.Municipality.Equals(municipality, StringComparison.OrdinalIgnoreCase) &&
    parsedDate >= record.FromDate &&
    parsedDate <= record.ToDate
).ToList();

    // Sort from highest to lowest priority based on index
    string[] taxTypePriority = ["Daily", "Weekly", "Monthly", "Yearly"];

    // Select the first matching tax record based on priority
    var taxRecord = filteredRecords
    .OrderBy(record => Array.IndexOf(taxTypePriority, record.TaxType))
    .FirstOrDefault();

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
    Console.WriteLine("Invalid format. Expected a valid municipality name and a date in YYYY-MM-DD format.");
}
