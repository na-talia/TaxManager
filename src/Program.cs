var tax = new TaxRecord
{
    Municipality = "Copenhagen",
    FromDate = new DateOnly(2025, 01, 01),
    ToDate = new DateOnly(2025, 12, 31),
    TaxRate = 0.2,
    TaxType = "Yearly"
};

Console.WriteLine($"{tax.Municipality} from {tax.FromDate} to {tax.ToDate} has a {tax.TaxType} tax of {tax.TaxRate}.");
