namespace WinFormsApp1.Models;

public class Car
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string RegistrationNumber { get; set; }
    public int OwnerId { get; set; }
    public Owner Owner { get; set; }
    public List<CarService> CarServices { get; set; }

    public string DisplayName => $"{Brand} {Model} ({RegistrationNumber})";

    public override string ToString()
    {
        return $"{Brand} {Model} ({RegistrationNumber})";
    }
}

public class Owner
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Phone { get; set; }
    public List<Car> Cars { get; set; }

    public override string ToString()
    {
        return $"{FullName}";
    }
}

public class Service
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public List<CarService> CarServices { get; set; }
}

public class CarService
{
    public int CarId { get; set; }
    public int ServiceId { get; set; }
    public DateTime DateOfService { get; set; }
    public int Mileage { get; set; }
    public Car Car { get; set; }
    public Service Service { get; set; }
}