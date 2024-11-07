using System;
using System.Collections.Generic;

namespace HotelManagement.DAL.Entities;

public partial class Task
{
    public int TaskId { get; set; }

    public int MemberId { get; set; }

    public int RoomNumber { get; set; }

    public DateTime DateCreate { get; set; }

    public string MemberName { get; set; } = null!;

    public string TaskStatus { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;

    public virtual Room RoomNumberNavigation { get; set; } = null!;
}
