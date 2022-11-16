namespace RetailProductManagementBackend.Model;

public class Product
{
    /// <summary>
    /// 
    /// </summary>
    /// <example>10</example>>
    public long Id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <example>Product 1</example>>
    public string Name { get; set; }
    /// <summary>
    ///  
    /// </summary>
    /// <example>100</example>
    public double Price { get; set; }
    /// <summary>
    ///  
    /// </summary>
    /// <example>Books</example>
    public string ProductType { get; set; }
    /// <summary>
    ///  
    /// </summary>
    /// <example>false</example>
    public bool Active { get; set; }
    /// <summary>
    ///  
    /// </summary>
    /// <example>2022-11-01</example>
    public DateTime? CreateDate { get; set; }
    public DateTime? DeleteDate { get; set; }
}