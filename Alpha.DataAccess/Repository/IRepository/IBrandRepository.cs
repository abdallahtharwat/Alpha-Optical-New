﻿using Alpha.Models;
using Alpha.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.DataAccess.Repository.IRepository
{
    public interface IBrandRepository : IRepository<Brand>
    {

        void Update(Brand obj);

     

    }
}
