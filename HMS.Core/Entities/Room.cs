
namespace HMS.Core.Entities;

public class Room : BaseEntity
{
    public int RoomId { get; set; }

    public string RoomNumber { get; set; } = string.Empty;
    public string RoomType { get; set; } = string.Empty;
    public int FloorNumber { get; set; }
    public decimal ChargesPerDay { get; set; }
    public string RoomStatus { get; set; } = "Available";

    public virtual ICollection<Admission> Admissions { get; set; } = new List<Admission>()
}
