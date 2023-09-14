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
    public class OtherFeatureRepository : IOtherFeatureRepository
    {
        private ApplicationDbContext _context;
        public OtherFeatureRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Addasync(OtherFeature AboutUs)
        {
            try
            {
                _context.otherFeatures.Add(AboutUs);
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
                var featuretest = await _context.otherFeatures.Where(e => e.Id == id).FirstOrDefaultAsync();
                if (featuretest != null)
                {
                    _context.otherFeatures.Remove(featuretest);
                    await _context.SaveChangesAsync();
                    return true;

                }

            }
            catch (Exception)
            {


            }
            return false;
        }



        public async Task<IEnumerable<OtherFeature>> GetAllF(Expression<Func<OtherFeature, bool>>? filter = null, string? includeproperties = null)
        {
            IQueryable<OtherFeature> query = _context.otherFeatures;
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

        public async Task<IEnumerable<OtherFeature>> GetAllasync()
        {
            return await _context.otherFeatures.ToListAsync();
        }

        public async Task<OtherFeature?> Getasync(int id)
        {
            return await _context.otherFeatures.Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> OtherFeatureAnyAsync(int id)
        {
            return await _context.otherFeatures.Where(e => e.Id == id).AnyAsync();
        }

        public async Task<bool> Updateasync(OtherFeature AboutUs)
        {
            try
            {
                _context.otherFeatures.Update(AboutUs);
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
                var featuretest = await _context.otherFeatures.FirstOrDefaultAsync(e => e.Id == id);
                if (featuretest != null)
                {
                    var item2 = new OtherFeature
                    {

                        Title = featuretest.Title,
                        Description = featuretest.Description,
                        Icon = featuretest.Icon,
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
