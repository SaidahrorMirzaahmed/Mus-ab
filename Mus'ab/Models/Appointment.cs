namespace Mus_ab.Models;

public class Appointment
{
    public int Id { get; set; }
    public int BarberId { get; set; }
    public int UserId { get; set; }
    public string OrderTime { get; set; }
    public decimal AdditionalPrice { get; set; } = 0;
    public string AdditionalFeatures { get; set; } = "standart";
}
