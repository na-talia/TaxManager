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

while (true)
{
    Console.Write("Choose action - Add / Retrieve / Quit (a/r/q): ");
    var action = Console.ReadLine();

    if (action == "a")
    {
        // Add new tax record
        Console.Write("Enter municipality: ");
        var newMunicipality = Console.ReadLine();

        Console.Write("Enter from date (YYYY-MM-DD): ");
        DateOnly.TryParse(Console.ReadLine(), out var newFromDate);

        Console.Write("Enter to date (YYYY-MM-DD): ");
        DateOnly.TryParse(Console.ReadLine(), out var newToDate);

        Console.Write("Enter tax rate (decimal, e.g. 0.2): ");
        decimal.TryParse(Console.ReadLine(), out var newTaxRate);

        Console.Write("Enter tax type (Daily, Weekly, Monthly, Yearly): ");
        var newTaxType = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(newMunicipality) && !string.IsNullOrWhiteSpace(newTaxType))
        {
            taxList.Add(new TaxRecord
            {
                Municipality = newMunicipality,
                FromDate = newFromDate,
                ToDate = newToDate,
                TaxRate = newTaxRate,
                TaxType = newTaxType
            });

            Console.WriteLine("New tax record added.\n");
        }
        else
        {
            Console.WriteLine("Invalid input. Skipping tax record addition.\n");
        }
    }
    else if (action == "r")
    {
        // Retrieve tax record
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
    }
    else if (action == "q")
    {
        Console.WriteLine("Bye!");
        break;
    }
    else
    {
        Console.WriteLine("Invalid option, please enter 'a', 'r', or 'q'.");
    }
}