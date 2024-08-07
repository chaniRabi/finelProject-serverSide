using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public double? TotalCost { get; set; }

    public DateOnly? Date { get; set; }

    public int? StatusId { get; set; }

    public virtual ICollection<OrdersProduct> OrdersProducts { get; set; } = new List<OrdersProduct>();

    public virtual Status? Status { get; set; }

    public virtual User User { get; set; } = null!;
}
