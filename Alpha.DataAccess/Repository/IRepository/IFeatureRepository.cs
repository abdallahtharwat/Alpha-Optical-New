using Alpha.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.DataAccess.Repository.IRepository
{
    public interface IFeatureRepository
    {

        public Task<bool> Addasync(Feature AboutUs);
       
        public Task<Feature?> Getasync(int id);
        public Task<IEnumerable<Feature>> GetAllasync();
        public Task<IEnumerable<Feature>> GetAllF(Expression<Func<Feature, bool>>? filter = null, string? includeproperties = null);

        public Task<bool> Updateasync(Feature AboutUs);
        public Task<bool> FeatureAnyAsync(int id);
        public Task<bool> Deleteasync(int id);

        public Task<bool> Duplicateasync(int id);



    }
}
