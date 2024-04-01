﻿using Entities.DTO;

namespace BL
{
    public interface ILookupBL
    {
      public  Task<List<ContctDTO>> GetContcts();
      public  Task<List<StatusDTO>> GetStatus();
    }
}