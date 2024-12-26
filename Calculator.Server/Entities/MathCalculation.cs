namespace Calculator.Server.Entities;

public class MathCalculation
{
    public Guid Id { get; set; }
    public string Math { get; set; }
    public string Result { get; set; }
    public DateTime DateTime { get; set; }
}
