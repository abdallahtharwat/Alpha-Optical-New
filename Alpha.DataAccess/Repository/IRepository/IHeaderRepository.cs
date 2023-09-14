using Alpha.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.DataAccess.Repository.IRepository
{
    public interface IHeaderRepository
    {



        public Task<bool> Addasync(Header AboutUs);
       
        public Task<Header> Getasync();

        Header Get(Expression<Func<Header, bool>> filter, string? includeproperties = null, bool tracked = false);
        public Task<IEnumerable<Header>> GetAllasync();
        public Task<IEnumerable<Header>> GetAllF(Expression<Func<Header, bool>>? filter = null, string? includeproperties = null);

        public Task<bool> Updateasync(Header AboutUs);
        public Task<bool> HeadersAnyAsync(int id);
        public Task<bool> Deleteasync(int id);



    }
}
