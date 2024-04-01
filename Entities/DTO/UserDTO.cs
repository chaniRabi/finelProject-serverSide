using System;
using System.Collections.Generic;

namespace Entities.DTO;

public partial class UserDTO
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Password { get; set; }

    public string? TipeUser { get; set; }

    public string? Address { get; set; }

}
