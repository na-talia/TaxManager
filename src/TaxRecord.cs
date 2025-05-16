public class TaxRecord
{
    public required string Municipality { get; set; }
    public required DateOnly FromDate { get; set; }
    public required DateOnly ToDate { get; set; }
    public required decimal TaxRate { get; set; }
    public required string TaxType { get; set; }
}
