namespace BreweryMaster.API.Order.Models.ProspectOrder
{
    public class ProspectOrder
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public DateOnly OrderCompletionDate { get; set; }
        public BeerType OrderID { get; set; }
    }
}
