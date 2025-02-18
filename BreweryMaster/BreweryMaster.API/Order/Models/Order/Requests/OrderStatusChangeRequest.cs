namespace BreweryMaster.API.OrderModule.Models
{
    public class OrderStatusChangeRequest
    {
        public int OrderId { get; set; }
        public int OrderStatusId { get; set; }
    }
}
