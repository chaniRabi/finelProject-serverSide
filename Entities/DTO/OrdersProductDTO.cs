using System;
using System.Collections.Generic;

namespace Entities.DTO;

public partial class OrdersProductDTO
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int OrderId { get; set; }

    public int? Amount { get; set; }

    public virtual OrderDTO Order { get; set; } = null!;

    public virtual ProductDTO Product { get; set; } = null!;
}
