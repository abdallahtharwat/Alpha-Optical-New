using Alpha.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.DataAccess.Repository.IRepository
{
    public interface IOurClientRepository
    {



        public Task<bool> Addasync(OurClient AboutUs);
       
        public Task<OurClient?> Getasync(int id);
        public Task<IEnumerable<OurClient>> GetAllasync();
        public Task<IEnumerable<OurClient>> GetAllF(Expression<Func<OurClient, bool>>? filter = null, string? includeproperties = null);

        public Task<bool> Updateasync(OurClient AboutUs);
        public Task<bool> HeadersAnyAsync(int id);
        public Task<bool> Deleteasync(int id);


        public Task<bool> Duplicateasync(int id);
    }
}
