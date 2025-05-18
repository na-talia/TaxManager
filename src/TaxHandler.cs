public class TaxHandler(List<TaxRecord> taxList)
{
    private readonly List<TaxRecord> _taxList = taxList;

    // Asks the user to input a new tax record and adds it to list
    public void AddTaxRecord()
    {
        Console.Write("Enter municipality: ");
        var newMunicipality = Console.ReadLine()?.Trim();

        Console.Write("Enter from date (YYYY-MM-DD): ");
        _ = DateOnly.TryParse(Console.ReadLine()?.Trim(), out var newFromDate);

        Console.Write("Enter to date (YYYY-MM-DD): ");
        _ = DateOnly.TryParse(Console.ReadLine()?.Trim(), out var newToDate);

        Console.Write("Enter tax rate (decimal, e.g. 0.2): ");
        _ = decimal.TryParse(Console.ReadLine()?.Trim(), out var newTaxRate);

        Console.Write("Enter tax type (Daily, Weekly, Monthly, Yearly): ");
        var newTaxType = Console.ReadLine()?.Trim().ToLower();

        // Basic input validation
        if (!string.IsNullOrWhiteSpace(newMunicipality) && !string.IsNullOrWhiteSpace(newTaxType))
        {
            _taxList.Add(new TaxRecord
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
            Console.WriteLine("Invalid input. Tax record not added.\n");
        }
    }

    public void RetrieveTaxRecord()
    {
        Console.Write("Input municipality: ");
        var municipality = Console.ReadLine()?.Trim();

        Console.Write("Input date (YYYY-MM-DD): ");
        var dateInput = Console.ReadLine()?.Trim();

        if (!string.IsNullOrWhiteSpace(municipality) && DateOnly.TryParse(dateInput, out var parsedDate))
        {
            // Filter tax records for the given municipality and date
            var filteredRecords = _taxList.Where(record =>
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
                Console.WriteLine($"Tax rate for {municipality} on {parsedDate} is {taxRecord.TaxRate}.\n");
            }
            else
            {
                Console.WriteLine("No tax rate is available for the specified date.\n");
            }
        }
        else
        {
            Console.WriteLine("Invalid format. Expected a valid municipality name and a date in YYYY-MM-DD format.\n");
        }
    }
}
