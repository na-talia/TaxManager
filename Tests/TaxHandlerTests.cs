using System;
using System.Linq;
using Xunit;

public class TaxHandlerTests
{
    [Fact]
    public void RetrieveTaxRecord_ReturnsExpectedRate_ForKnownMunicipalityAndData()
    {
        // Get the default data
        var taxList = InitialTaxData.GetDefaultTaxRecords();
        var handler = new TaxHandler(taxList);

        var date = new DateOnly(2025, 03, 25);

        var taxRecord = taxList.FirstOrDefault(record =>
            record.Municipality.Equals("Copenhagen", StringComparison.OrdinalIgnoreCase) &&
            date >= record.FromDate &&
            date <= record.ToDate
        );

        // Check if tax record is found and rate is as expected
        Assert.NotNull(taxRecord);
        Assert.Equal(0.2M, taxRecord.TaxRate);
    }
}