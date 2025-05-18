public static class InitialTaxData
{
    /* Assumption: Using hardcoded tax records.
       This can be replaced with a database in the future. */
    public static List<TaxRecord> GetDefaultTaxRecords() =>
    [
        new()
        {
            Municipality = "Copenhagen",
            FromDate = new DateOnly(2025, 01, 01),
            ToDate = new DateOnly(2025, 12, 31),
            TaxRate = 0.2M,
            TaxType = "Yearly"
        },
        new()
        {
            Municipality = "Copenhagen",
            FromDate = new DateOnly(2025, 05, 01),
            ToDate = new DateOnly(2025, 05, 31),
            TaxRate = 0.4M,
            TaxType = "Monthly"
        },
        new()
        {
            Municipality = "Copenhagen",
            FromDate = new DateOnly(2025, 01, 01),
            ToDate = new DateOnly(2025, 01, 01),
            TaxRate = 0.1M,
            TaxType = "Daily"
        },
        new()
        {
            Municipality = "Copenhagen",
            FromDate = new DateOnly(2025, 12, 25),
            ToDate = new DateOnly(2025, 12, 25),
            TaxRate = 0.1M,
            TaxType = "Daily"
        }
    ];
}
