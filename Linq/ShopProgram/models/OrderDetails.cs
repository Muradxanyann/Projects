class OrderDetails 
{
    public int Id { get; set; }
    public int orderId { get; set; }
    public int productId { get; set; }

    public int count {get;set;}

    public OrderDetails(int id, int orderId, int productId, int count){
        this.Id = id;
        this.orderId = orderId;
        this.productId = productId;
        this.count = count;
    }

   
}