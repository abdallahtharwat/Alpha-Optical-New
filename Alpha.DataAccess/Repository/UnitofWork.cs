using Alpha.DataAccess.Data;
using Alpha.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Alpha.DataAccess.Repository
{
    public class UnitofWork : IUnitofWork
    {
        private ApplicationDbContext _db;

        public UnitofWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Brand = new BrandRepository(_db);
            Lenstype = new LenstypeRepository(_db);
            Product = new ProductRepository(_db);
            ProductImage = new ProductImageRepository(_db);
            Company = new CompanyRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            OrderHeader = new OrderHeaderRepository(_db);
            OrderDetail = new OrderDetailRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            header = new HeaderRepository(_db);
            Feature = new FeatureRepository(_db);   
            DetailsSection = new DetailsSectionRepository(_db); 
            OtherFeature = new OtherFeatureRepository(_db);
            AboutUs = new AboutUsRepository(_db);
            OurClient = new OurClientRepository(_db);   


        }



        public ICategoryRepository Category { get; private set; }


        public IBrandRepository Brand { get; private set; }   
       
        public ILenstypeRepository Lenstype { get; private set; }

        public IProductRepository Product { get; private set; }
        public IProductImageRepository ProductImage { get; private set; }
        public ICompanyRepository Company { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IOrderHeaderRepository OrderHeader { get; private set; }
        public IOrderDetailRepository OrderDetail { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IHeaderRepository  header { get; private set; }
        public IFeatureRepository   Feature { get; private set; }
        public IDetailsSectionRepository    DetailsSection { get; private set; }
        public IOtherFeatureRepository   OtherFeature { get; private set; }
        public IAboutUsRepository    AboutUs { get; private set; }
        public IOurClientRepository    OurClient { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
