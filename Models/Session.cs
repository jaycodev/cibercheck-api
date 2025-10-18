using System;
using System.Collections.Generic;

namespace CiberCheck.Models;

public partial class Session
{
    public int SessionId { get; set; }

    public int SectionId { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public string? Topic { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual Section Section { get; set; } = null!;
}
