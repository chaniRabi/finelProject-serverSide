using System;
using System.Collections.Generic;

namespace Entities.DTO;

public partial class ProductInCartDTO
{
    public int Id { get; set; }

    public int? Amount { get; set; }

    public int CustomerId { get; set; }

    public int ProductId { get; set; }

    //public virtual UserDTO Customer { get; set; } = null!;
}
