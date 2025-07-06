using System;
using System.Collections.Generic;

namespace TourMate.TourService.Repositories.Models;

public partial class Tour
{
    public int ServiceId { get; set; }

    public string ServiceName { get; set; } = null!;

    public float Price { get; set; }

    public TimeOnly Duration { get; set; }

    public string Content { get; set; } = null!;

    public string Image { get; set; } = null!;

    public int TourGuideId { get; set; }

    public DateOnly CreatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string Title { get; set; } = null!;

    public string TourDesc { get; set; } = null!;
}
