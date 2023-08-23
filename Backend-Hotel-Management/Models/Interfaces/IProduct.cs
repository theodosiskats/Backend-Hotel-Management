namespace Backend_Hotel_Management.Models.Interfaces;

public interface IProduct
{
    string CategoryName { get; set; }
    int Capacity { get; set; }
    decimal PricePerNight { get; set; }
}