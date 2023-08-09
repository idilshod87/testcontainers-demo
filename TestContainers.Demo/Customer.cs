namespace TestContainers.Demo;

public class Customer
{
    public required int Id { get; set; }

    public required string Name { get; set; }

    public Address? Address { get; set; }
}

public class Address
{
    public string? Country { get; set; }

    public string? City { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }
}