﻿using System;
using System.Collections.Generic;

namespace Entities.DTO;

public partial class ProductDTO
{
    public int Id { get; set; }

    public double? Price { get; set; }

    public int CategoryId { get; set; }

    public string? Name { get; set; }

    public string? Image { get; set; }

    public string? Description { get; set; }

    public int? Quantity { get; set; }

    //public virtual CategoryDTO? Category { get; set; } = null!;

}
