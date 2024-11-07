using System;
using System.Collections.Generic;

namespace HotelManagement.DAL.Entities;

public partial class Service
{
    public int ServiceId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public int Status { get; set; }

    public virtual ICollection<ServiceDetail> ServiceDetails { get; set; } = new List<ServiceDetail>();
}
