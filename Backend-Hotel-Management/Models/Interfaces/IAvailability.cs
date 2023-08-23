namespace Backend_Hotel_Management.Models.Interfaces;

public interface IAvailability
{
    public string Id { get; set; }
    public string ProductCategory { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string ProductId { get; set; }

}