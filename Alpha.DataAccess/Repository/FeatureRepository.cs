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
    public class FeatureRepository  : IFeatureRepository
    {
        private ApplicationDbContext _context;
        public FeatureRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Addasync(Feature AboutUs)
        {
            try
            {
                _context.features.Add(AboutUs);
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
                var featuretest = await _context.features.Where(e => e.Id == id).FirstOrDefaultAsync();
                if (featuretest != null)
                {
                    _context.features.Remove(featuretest);
                    await _context.SaveChangesAsync();
                    return true;

                }

            }
            catch (Exception)
            {


            }
            return false;
        }



        public async Task<IEnumerable<Feature>> GetAllF(Expression<Func<Feature, bool>>? filter = null, string? includeproperties = null)
        {
            IQueryable<Feature> query = _context.features;
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

        public async Task<IEnumerable<Feature>> GetAllasync()
        {
            return await _context.features.ToListAsync();
        }

        public async Task<Feature?> Getasync(int id)
        {
            return await _context.features.Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> FeatureAnyAsync(int id)
        {
            return await _context.features.Where(e => e.Id == id).AnyAsync();
        }

        public async Task<bool> Updateasync(Feature AboutUs)
        {
            try
            {
                _context.features.Update(AboutUs);
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
                var featuretest = await _context.features.FirstOrDefaultAsync(e => e.Id == id);
                if (featuretest != null)
                {
                    var item2 = new Feature
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
