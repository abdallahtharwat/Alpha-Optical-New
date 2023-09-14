using Alpha.DataAccess.Data;
using Alpha.DataAccess.Repository.IRepository;
using Alpha.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.DataAccess.Repository
{
    public class AboutUsRepository : IAboutUsRepository
    {

        private ApplicationDbContext _context;
        public AboutUsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Addasync(AboutUs AboutUs)
        {
            try
            {
                _context.AboutUs.Add(AboutUs);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }
        public async Task<bool> Deleteasync(int id)
        {
            try
            {
                var featuretest = await _context.AboutUs.Where(e => e.Id == id).FirstOrDefaultAsync();
                if (featuretest != null)
                {
                    _context.AboutUs.Remove(featuretest);
                    await _context.SaveChangesAsync();
                    return true;

                }

            }
            catch (Exception)
            {


            }
            return false;
        }



        public async Task<IEnumerable<AboutUs>> GetAllF(Expression<Func<AboutUs, bool>>? filter = null, string? includeproperties = null)
        {
            IQueryable<AboutUs> query = _context.AboutUs;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeproperties))
            {
                foreach (var includeprop in includeproperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeprop);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<AboutUs>> GetAllasync()
        {
            return await _context.AboutUs.ToListAsync();
        }

        public async Task<AboutUs?> Getasync(int id)
        {
            return await _context.AboutUs.Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> HeadersAnyAsync(int id)
        {
            return await _context.AboutUs.Where(e => e.Id == id).AnyAsync();
        }

        public async Task<bool> Updateasync(AboutUs AboutUs)
        {
            try
            {
                _context.AboutUs.Update(AboutUs);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


    }
}
