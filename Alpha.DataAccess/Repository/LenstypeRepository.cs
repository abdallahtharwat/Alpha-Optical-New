using Alpha.DataAccess.Data;
using Alpha.DataAccess.Repository.IRepository;
using Alpha.Models;
using Alpha.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.DataAccess.Repository
{
    public class LenstypeRepository : Repository<Lenstype>, ILenstypeRepository
    {
        private ApplicationDbContext _db;
        public LenstypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

     

        public void Update(Lenstype obj)
        {
            _db.lenstypes.Update(obj);
        }
    }
}
