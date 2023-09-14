using Alpha.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.DataAccess.Repository.IRepository
{
    public interface IDetailsSectionRepository
    {



        public Task<bool> Addasync(DetailsSection AboutUs);
       
        public Task<DetailsSection?> Getasync(int id);
        public Task<IEnumerable<DetailsSection>> GetAllasync();
        public Task<IEnumerable<DetailsSection>> GetAllF(Expression<Func<DetailsSection, bool>>? filter = null, string? includeproperties = null);

        public Task<bool> Updateasync(DetailsSection AboutUs);
        public Task<bool> HeadersAnyAsync(int id);
        public Task<bool> Deleteasync(int id);



    }
}
