using System;
using System.Collections.Generic;

namespace Entities.DTO;

public partial class ProductDTO
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string? Name { get; set; }

    public double? Prise { get; set; }

    public virtual CategoryDTO Category { get; set; } = null!;

}
