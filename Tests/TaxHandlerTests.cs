using System;
using System.Linq;
using Xunit;

public class TaxHandlerTests
{
    [Fact]
    public void RetrieveTaxRecord_ReturnsExpectedRate_ForKnownMunicipalityAndDate()
    {
        // Get the default data
        var taxList = InitialTaxData.GetDefaultTaxRecords();
        var handler = new TaxHandler(taxList);

        var date = new DateOnly(2025, 05, 25);

        //Add priority
        var taxTypePriority = new[] { "Daily", "Weekly", "Monthly", "Yearly" };

        var taxRecord = taxList
            .Where(record =>
                record.Municipality.Equals("Copenhagen", StringComparison.OrdinalIgnoreCase) &&
                date >= record.FromDate &&
                date <= record.ToDate)
            .OrderBy(record => Array.IndexOf(taxTypePriority, record.TaxType))
            .FirstOrDefault();

        // Check if tax record is found and rate is as expected
        Assert.NotNull(taxRecord);
        Assert.Equal(0.4M, taxRecord.TaxRate);
    }
}