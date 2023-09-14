using Alpha.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.DataAccess.Repository.IRepository
{
    public interface IOtherFeatureRepository
    {

        public Task<bool> Addasync(OtherFeature AboutUs);
       
        public Task<OtherFeature?> Getasync(int id);
        public Task<IEnumerable<OtherFeature>> GetAllasync();
        public Task<IEnumerable<OtherFeature>> GetAllF(Expression<Func<OtherFeature, bool>>? filter = null, string? includeproperties = null);

        public Task<bool> Updateasync(OtherFeature AboutUs);
        public Task<bool> OtherFeatureAnyAsync(int id);
        public Task<bool> Deleteasync(int id);

        public Task<bool> Duplicateasync(int id);



    }
}
