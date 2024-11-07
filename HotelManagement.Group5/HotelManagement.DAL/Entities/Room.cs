using System;
using System.Collections.Generic;

namespace HotelManagement.DAL.Entities;

public partial class Room
{
    public int RoomNumber { get; set; }

    public string RoomStatus { get; set; } = null!;

    public virtual ICollection<ServiceDetail> ServiceDetails { get; set; } = new List<ServiceDetail>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
