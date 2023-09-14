using Alpha.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.DataAccess.Repository.IRepository
{
    public interface IAboutUsRepository
    {



        public Task<bool> Addasync(AboutUs AboutUs);
       
        public Task<AboutUs?> Getasync(int id);
        public Task<IEnumerable<AboutUs>> GetAllasync();
        public Task<IEnumerable<AboutUs>> GetAllF(Expression<Func<AboutUs, bool>>? filter = null, string? includeproperties = null);

        public Task<bool> Updateasync(AboutUs AboutUs);
        public Task<bool> HeadersAnyAsync(int id);
        public Task<bool> Deleteasync(int id);



    }
}
