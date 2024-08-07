using BL;
using DAL.Models;
using Entities.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ShineStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private ILookupBL lookupBL;
        public LookupController(ILookupBL lookupBL)
        {
            this.lookupBL = lookupBL;
        }

        [HttpGet]
        [Route("GetContcts")]

        public async Task<List<ContctDTO>> GetContcts()
        {
            try
            {
                var Contct = await lookupBL.GetContcts();
                return Contct;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        [HttpGet]
        [Route("Status")]
        public async Task<List<StatusDTO>> GetStatus()
        {
            var Status = await lookupBL.GetStatus();
            return Status;
        }

        [HttpPost]
        [Route("AddContct")]
        public async Task<ContctDTO> AddContct(ContctDTO contct)
        {
            try
            {
                var Contct = await lookupBL.AddContct(contct);
                return Contct;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
    }
}
