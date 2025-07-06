using System;
using System.Collections.Generic;

namespace TourMate.TourService.Repositories.Models;

public partial class Invoice
{
    public int InvoiceId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int TourGuideId { get; set; }

    public string PeopleAmount { get; set; } = null!;

    public string Status { get; set; } = null!;

    public float Price { get; set; }

    public string Note { get; set; } = null!;

    public int CustomerId { get; set; }

    public int AreaId { get; set; }

    public string TourDesc { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string CustomerPhone { get; set; } = null!;

    public string TourName { get; set; } = null!;
}
