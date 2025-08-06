namespace TravelUpApp_AI_ML.Models
{
    public class UserBehavior
    {
        public string UserId { get; set; } = string.Empty;
        public double SessionDuration { get; set; }
        public int PagesVisited { get; set; }
        public string SearchOrigin { get; set; }= string.Empty;
        public string SearchDestination { get; set; } = string.Empty;
        public bool TravelDatesFlexible { get; set; }
        public string DeviceType { get; set; } = string.Empty;
        public bool ClickedOffer { get; set; }
        public bool BookingMade { get; set; }
    }

}
