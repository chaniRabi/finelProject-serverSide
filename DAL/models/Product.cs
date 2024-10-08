﻿using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Product
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string? Name { get; set; }

    public double? Price { get; set; }

    public string? Image { get; set; }

    public string? Description { get; set; }

    public int? Quantity { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrdersProduct> OrdersProducts { get; set; } = new List<OrdersProduct>();

    public virtual ICollection<ProductInCart> ProductInCarts { get; set; } = new List<ProductInCart>();
}
