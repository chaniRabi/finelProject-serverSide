using System;
using System.Collections.Generic;

namespace Entities.DTO;

public partial class OrderDTO
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public double? TotalCost { get; set; }

    public DateOnly? Date { get; set; }

    public int? StatusId { get; set; }

}
