using System;
using System.Collections.Generic;

namespace CiberCheck.Models;

public partial class Attendance
{
    public int StudentId { get; set; }

    public int SessionId { get; set; }

    public string Status { get; set; } = null!;

    public string? Notes { get; set; }

    public virtual Session Session { get; set; } = null!;

    public virtual User Student { get; set; } = null!;
}
