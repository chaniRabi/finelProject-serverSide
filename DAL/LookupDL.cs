using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LookupDL : ILookupDL
    {
        public ShinestockContext _context;

        public LookupDL(ShinestockContext context) { _context = context; }

        public async Task<Contct> AddContct(Contct contct)
        {
            try
            {
                await _context.Contcts.AddAsync(contct);
                await _context.SaveChangesAsync();
                return contct;
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<List<Contct>> GetContcts()
        {
            try
            {
                var Contcts = await _context.Contcts.ToListAsync();
                return Contcts;
            }
            catch (Exception ex) { throw ex; }
        }
        public async Task<List<Status>> GetStatus()
        {
            try
            {
                var Status = await _context.Statuses.ToListAsync();
                return Status;
            }
            catch (Exception ex) { throw ex; }
        }

    }
}
