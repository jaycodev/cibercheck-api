using System;
using System.Collections.Generic;

namespace CiberCheck.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string Name { get; set; } = null!;

    public string? Code { get; set; }

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
}
