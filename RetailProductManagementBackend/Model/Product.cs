namespace RetailProductManagementBackend.Model;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public string ProductType { get; set; }
    public bool Active { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? DeleteDate { get; set; }
}