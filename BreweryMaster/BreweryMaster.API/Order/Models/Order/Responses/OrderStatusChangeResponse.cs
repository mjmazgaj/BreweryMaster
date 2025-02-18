namespace BreweryMaster.API.OrderModule.Models
{
    public class OrderStatusChangeResponse
    {
        public int OrderId { get; set; }
        public int OrderStatusId { get; set; }
        public string OrderStatus { get; set; } = string.Empty;
        public DateTime ChangedOnDateTime { get; set; }
        public DateOnly ChangedOnDateOnly { get; set; }
    }
}
