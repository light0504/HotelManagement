using System;
using System.Collections.Generic;

namespace HotelManagement.DAL.Entities;

public partial class ServiceDetail
{
    public int ServiceDetailId { get; set; }

    public int ServiceId { get; set; }

    public int RoomNumber { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public DateOnly CreateDate { get; set; }

    public virtual Room RoomNumberNavigation { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
