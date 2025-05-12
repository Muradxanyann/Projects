enum OrderStatus {Pending, OnTheWay, Deliveried, PaymentRejected} ;
class Order{
    public int Id{get;set;}
    public int userId{get;set;}

    public OrderStatus Status {get;set;}

    public Order(int id, int userId, OrderStatus status){
        this.Id = id;
        this.userId = userId;
        this.Status = status;
    }


}