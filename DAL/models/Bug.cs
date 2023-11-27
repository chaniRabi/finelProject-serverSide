using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Bug
{
    public int Id { get; set; }

    public int? Amount { get; set; }

    public int CustomerId { get; set; }

    public int ProductId { get; set; }

    public virtual User Customer { get; set; } = null!;
}
