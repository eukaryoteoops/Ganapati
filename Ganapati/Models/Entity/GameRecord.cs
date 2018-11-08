namespace Ganapati.Models.Entity
{
    public class GameRecord
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int Point1 { get; set; }
        public int Point2 { get; set; }
        public int HostPoint1 { get; set; }
        public int HostPoint2 { get; set; }
        public string PlayedOn { get; set; }
    }
}