namespace MultiShop.Order.Domain.Entities;

public class OrderDetail
{
    public int OrderDetailID { get; set; }
    public string ProductID { get; set; }//string because we  use mongodb to store products   
    public int OrderingID { get; set; }
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public int ProductAmount { get; set; }
    public decimal ProductTotalPrice { get; set; }
    public Ordering Ordering { get; set; }
    
}