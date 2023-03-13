namespace MP5.DTO;

public class AddBetDTO
{
    public string Category { get; set; }
    public double Rate { get; set; }
    public string BetType { get; set; }
    public string? EventName { get; set; }
    public string? SportName { get; set; }
}