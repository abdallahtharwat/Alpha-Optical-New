using Alpha.DataAccess.Data;
using Alpha.DataAccess.Repository.IRepository;
using Alpha.Models;
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
    public class DetailsSectionRepository :  IDetailsSectionRepository
    {
        private ApplicationDbContext _context;
        public DetailsSectionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Addasync(DetailsSection AboutUs)
        {
            try
            {
                _context.detailsSections.Add(AboutUs);
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
                var featuretest = await _context.detailsSections.Where(e => e.Id == id).FirstOrDefaultAsync();
                if (featuretest != null)
                {
                    _context.detailsSections.Remove(featuretest);
                    await _context.SaveChangesAsync();
                    return true;

                }

            }
            catch (Exception)
            {


            }
            return false;
        }



        public async Task<IEnumerable<DetailsSection>> GetAllF(Expression<Func<DetailsSection, bool>>? filter = null, string? includeproperties = null)
        {
            IQueryable<DetailsSection> query = _context.detailsSections;
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

        public async Task<IEnumerable<DetailsSection>> GetAllasync()
        {
            return await _context.detailsSections.ToListAsync();
        }

        public async Task<DetailsSection?> Getasync(int id)
        {
            return await _context.detailsSections.Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> HeadersAnyAsync(int id)
        {
            return await _context.detailsSections.Where(e => e.Id == id).AnyAsync();
        }

        public async Task<bool> Updateasync(DetailsSection AboutUs)
        {
            try
            {
                _context.detailsSections.Update(AboutUs);
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
