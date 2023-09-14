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
    public class OurClientRepository : IOurClientRepository
    {

        private ApplicationDbContext _context;
        public OurClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Addasync(OurClient AboutUs)
        {
            try
            {
                _context.ourClients.Add(AboutUs);
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
                var featuretest = await _context.ourClients.Where(e => e.Id == id).FirstOrDefaultAsync();
                if (featuretest != null)
                {
                    _context.ourClients.Remove(featuretest);
                    await _context.SaveChangesAsync();
                    return true;

                }

            }
            catch (Exception)
            {


            }
            return false;
        }



        public async Task<IEnumerable<OurClient>> GetAllF(Expression<Func<OurClient, bool>>? filter = null, string? includeproperties = null)
        {
            IQueryable<OurClient> query = _context.ourClients;
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

        public async Task<IEnumerable<OurClient>> GetAllasync()
        {
            return await _context.ourClients.ToListAsync();
        }

        public async Task<OurClient?> Getasync(int id)
        {
            return await _context.ourClients.Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> HeadersAnyAsync(int id)
        {
            return await _context.ourClients.Where(e => e.Id == id).AnyAsync();
        }

        public async Task<bool> Updateasync(OurClient AboutUs)
        {
            try
            {
                _context.ourClients.Update(AboutUs);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> Duplicateasync(int id)
        {
            try
            {
                var ourclient = await _context.ourClients.FirstOrDefaultAsync(e => e.Id == id);
                if (ourclient != null)
                {
                    var item2 = new OurClient 
                    {

                        Title = ourclient.Title,
                        Description = ourclient.Description,
                        Image = ourclient.Image,
                        //hiddenImageUrl = ourclient.hiddenImageUrl,
                    };

                    await _context.AddAsync(item2);
                    await _context.SaveChangesAsync();
                    return true;

                }



            }
            catch (Exception)
            {


            }

            return false;
        }








    }
}
