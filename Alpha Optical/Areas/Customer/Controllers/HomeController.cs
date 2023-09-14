using Alpha.DataAccess.Repository.IRepository;
using Alpha.Models;
using Alpha.Models.Models;
using Alpha.Models.ViewModels;
using ALpha.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Security.Claims;

namespace Alpha_Optical.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitofWork _UnitofWork;
        public HomeController(ILogger<HomeController> logger, IUnitofWork UnitofWork)
        {
            _logger = logger;
            _UnitofWork = UnitofWork;
        }
        public async Task< IActionResult> Index()
        {

            var product = _UnitofWork.Product.GetAll(includeproperties: "Category,Brand,Lenstype,productImages").Select(u => new Product  // (step 3 for forienkey category)  انت بتحيبها من قاعد البيانات و بتبعتها لل فيو    
            {
                Title = u.Title,
                Description = u.Description,
                Color = u.Color,
                ISBN = u.ISBN,
                ListPrice = u.ListPrice,
                Price = u.Price,
                Price5 = u.Price5,
                Price10 = u.Price10,
                CategoryId = u.CategoryId,
                LenstypeId = u.LenstypeId,
                BrandId = u.BrandId,
                productImages = u.productImages,
                Category = u.Category,
                Brand = u.Brand,
                Lenstype = u.Lenstype,

                Id = u.Id,
            });


            var q =  await _UnitofWork.header.Getasync();

            var header = new Header   // (step 3 for forienkey category)  انت بتحيبها من قاعد البيانات و بتبعتها لل فيو    
            {
                Title = q.Title,
                Description = q.Description,
                Id = q.Id,
                Image = q.Image,
            };

            var m = await _UnitofWork.AboutUs.Getasync(1);

            //var aboutus = new AboutUs
            //{
            //    Title = m.Title,
            //    Description = m.Description,
            //    Id = m.Id,
            //    Image = m.Image,
            //};

            var z = await _UnitofWork.DetailsSection.Getasync(1);

            var detailsSection = new DetailsSection   // (step 3 for forienkey category)  انت بتحيبها من قاعد البيانات و بتبعتها لل فيو    
            {
                Title = z.Title,
                Description = z.Description,
                Id = z.Id,
                Image = z.Image,
            };

            var features = await _UnitofWork.Feature.GetAllasync();
             if(features is null)
             {
                return NotFound();
             }

            var otherfeatures = await _UnitofWork.OtherFeature.GetAllasync();
            if (otherfeatures is null)
            {
                return NotFound();
            }

            var ourclient = await _UnitofWork.OurClient.GetAllasync();
            if(ourclient is null)
            {
                NotFound();
            }




            HomePageVM headerVM = new()
            {
                products = product,
                header = header,
                DetailsSection = detailsSection,
                AboutUs = m,
                features = features.ToList(),
                otherFeatures = otherfeatures.ToList(),
                ourClients = ourclient.ToList(),

            };



            //IEnumerable<Product> Productlist = _UnitofWork.Product.GetAll(includeproperties: "Category,Brand,Lenstype,productImages");
            return View(headerVM);
        }

        // get 
        public IActionResult Details(int productid)
        {
            //get product and productid and count from database to pass to view
            ShoppingCart cart = new()
            {
                Product = _UnitofWork.Product.Get(u => u.Id == productid, includeproperties: "Category,Brand,Lenstype,productImages"),
                Count = 1,
                ProductId = productid
            };
            return View(cart);
        }

        [HttpPost]
        [Authorize]  // when we add a item in cart we must be login first
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            // when we push cart button we need Userid and productid
            var claimsIdentity = (ClaimsIdentity)User.Identity;   // right here we have the userid  -- There is a special claim with the name of name identifier that will have user ID of the logged in user.
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value; // When a user logs in, we have to access dot value and that way the user ID will be populated.
            shoppingCart.ApplicationUserId = userId;  

            // we must do that because we donot need to duplicate product when we add  a new item and if user has already have a product on shoppingcart
            // get shopping cart from database and make sure the userid == ApplicationUserId and produc id == productid
            ShoppingCart cartFromDb = _UnitofWork.ShoppingCart.Get(u => u.ApplicationUserId == userId &&
           u.ProductId == shoppingCart.ProductId);
            if (cartFromDb != null)
            {
                //shopping cart exists
                cartFromDb.Count += shoppingCart.Count;
                _UnitofWork.ShoppingCart.Update(cartFromDb);
                _UnitofWork.Save();
            }
            else
            {
                //add cart record
                _UnitofWork.ShoppingCart.add(shoppingCart);
                _UnitofWork.Save();

                HttpContext.Session.SetInt32(SD.SessionCart,    // how to makr shoppingcart icon to count
                     _UnitofWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId).Count());

            }

            TempData["success"] = "Cart updated successfully";

            return RedirectToAction(nameof(Index));
        }








        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}