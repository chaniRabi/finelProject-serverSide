﻿using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class OrdersProduct
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int OrderId { get; set; }

    public int Amount { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
