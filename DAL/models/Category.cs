using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Category
{
    public int Id { get; set; }

    public string NameCategor { get; set; } = null!;

    public string? PathToImage { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
