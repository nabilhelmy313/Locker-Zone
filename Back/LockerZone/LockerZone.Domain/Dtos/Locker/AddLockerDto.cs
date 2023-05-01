namespace LockerZone.Domain.Dtos
{
    public class AddLockerDto
    {
        public int Number { get; set; }
        public double Price { get; set; }
        public DateTime FromDay { get; set; }
        public DateTime ToDay { get; set; }
        public string? Description { get; set; }
    }
}
