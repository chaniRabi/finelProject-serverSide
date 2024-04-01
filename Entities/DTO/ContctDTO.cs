using System;
using System.Collections.Generic;

namespace Entities.DTO;

public partial class ContctDTO
{
    public int Id { get; set; }

    public DateOnly? Date { get; set; }

    public string? Massages { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }
}
