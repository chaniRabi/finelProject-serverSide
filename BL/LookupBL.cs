using AutoMapper;
using DAL;
using DAL.Models;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class LookupBL : ILookupBL
    {
        ILookupDL _lookupDL;
        IMapper _mapper;

        public LookupBL(ILookupDL lookupDL, IMapper mapper)
        {
            _lookupDL = lookupDL;
            _mapper = mapper;
        }

        public async Task<ContctDTO> AddContct(ContctDTO contct)
        {
            Contct c = _mapper.Map<Contct>(contct);
            Contct addContct = await _lookupDL.AddContct(c);
            ContctDTO contctDTO = _mapper.Map<ContctDTO>(addContct);
            return contctDTO;
        }

        public async Task<List<ContctDTO>> GetContcts()
        {
            try { 
            List<Contct> contcts1 = await _lookupDL.GetContcts();
            List<ContctDTO> contcts2 = _mapper.Map<List<ContctDTO>>(contcts1);
            return contcts2;
        }
            catch (Exception ex)
            {
                throw ex;
            }
            }

        public async Task<List<StatusDTO>> GetStatus()
        {
            List<Status> status1 = await _lookupDL.GetStatus();
            List<StatusDTO> status2 = _mapper.Map<List<StatusDTO>>(status1);
            return status2;
        }
    }
}
