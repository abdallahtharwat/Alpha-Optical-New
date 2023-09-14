using Alpha.DataAccess.Data;
using Alpha.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.DataAccess.Repository.IRepository
{
    public class HeaderRepository : IHeaderRepository
    {

        private ApplicationDbContext _context;
        public HeaderRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<bool> Addasync(Header AboutUs)
        {
            try
            {
                _context.headers.Add(AboutUs);
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
                var featuretest = await _context.headers.Where(e => e.Id == id).FirstOrDefaultAsync();
                if (featuretest != null)
                {
                    _context.headers.Remove(featuretest);
                    await _context.SaveChangesAsync();
                    return true;

                }

            }
            catch (Exception)
            {


            }
            return false;
        }



        public async Task<IEnumerable<Header>> GetAllF(Expression<Func<Header, bool>>? filter = null, string? includeproperties = null)
        {
            IQueryable<Header> query = _context.headers;
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

        public async Task<IEnumerable<Header>> GetAllasync()
        {
            return await _context.headers.ToListAsync();
        }

        public async Task<Header> Getasync()
        {
            return await _context.headers.FirstOrDefaultAsync();
        }

        public async Task<bool> HeadersAnyAsync(int id)
        {
            return await _context.headers.Where(e => e.Id == id).AnyAsync();    
        }

        public async Task<bool> Updateasync(Header AboutUs)
        {
            try
            {
                 _context.headers.Update(AboutUs);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Header Get(Expression<Func<Header, bool>> filter, string? includeproperties = null, bool tracked = false)
        {
            IQueryable<Header> query = _context.headers;
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

            return  query.FirstOrDefault();
        }
    }
}
