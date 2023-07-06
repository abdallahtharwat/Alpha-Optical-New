using Alpha.DataAccess.Data;
using Alpha.DataAccess.Repository.IRepository;
using Alpha.Models;
using Alpha.Models.Models;
using Alpha.Models.ViewModels;
using ALpha.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace Alpha_Optical.Areas.Admin.Controllers
{
    [Area("Admin")]
        // authorize for route 
    public class ProductController : Controller
    {
        private readonly IUnitofWork _UnitofWork;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public ProductController(IUnitofWork unitofWork, IWebHostEnvironment webHostEnvironment)
        {
            _UnitofWork = unitofWork;
            _WebHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Product> objproductlist = _UnitofWork.Product.GetAll(includeproperties: "Category,Brand,Lenstype").ToList();

            return View(objproductlist);
        }

        [Authorize(Roles = SD.Role_Admin)]
        // get create
        public IActionResult Upsert(int? id)
        {
            // when you want to  pass data from controller to view page || we must retrive from database first and send it to view                                                                
            ProductVM productVM = new()
            {
                CategoryList = _UnitofWork.Category.GetAll().Select(u => new SelectListItem  // (step 3 for forienkey category)  انت بتحيبها من قاعد البيانات و بتبعتها لل فيو    
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }),

                BrandList = _UnitofWork.Brand.GetAll().Select(u => new SelectListItem  // (step 3 for forienkey category)  انت بتحيبها من قاعد البيانات و بتبعتها لل فيو    
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }),

                LenstypeList = _UnitofWork.Lenstype.GetAll().Select(u => new SelectListItem  // (step 3 for forienkey category)  انت بتحيبها من قاعد البيانات و بتبعتها لل فيو    
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }),


                Product = new Product()
            };
        
           if(id ==null || id == 0)
            {
                // if id is zero its create
                return View(productVM);
            }
            else
            {
                // the id is present (its update)
                productVM.Product = _UnitofWork.Product.Get(u => u.Id == id, includeproperties: "productImages");
                return View(productVM);
            }

        }



        // post create
        [HttpPost]
        public IActionResult Upsert(ProductVM productVM , List<IFormFile> files)  //  (obj== anta btstlm el value el fe post method input fe el create view )  when we have the obj here that will have the value of category that needs to be add
        {
                //Validation for sliver side
                if (ModelState.IsValid)
            {

                if (productVM.Product.Id == 0)
                {
                    _UnitofWork.Product.add(productVM.Product);
                    TempData["success"] = "  Created successfully";
                }
                 else
                   {
                    _UnitofWork.Product.Update(productVM.Product);
                    TempData["success"] = "  update successfully";
                    }
                   _UnitofWork.Save();

                string wwwRootPath = _WebHostEnvironment.WebRootPath;  // access to wwwroot folder
                if (files != null)
                {
                    // we can iterate through each file that were uploaded 
                    foreach (IFormFile file in files)
                    {
                        // unique name for image
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string productPath = @"images\products\product-" + productVM.Product.Id; // we need to add the productID
                        string finalPath = Path.Combine(wwwRootPath, productPath); // the location where to have save images

                        // we will have to create this particular product folder in linen(95) if that does not exist
                        if (!Directory.Exists(finalPath))  // if final path is not exists
                            Directory.CreateDirectory(finalPath); // will create that particular  ||  to upload all the files 

                        // change piets to file and  (( Save the photo))
                        using (var fileStream = new FileStream(Path.Combine(finalPath, fileName), FileMode.Create))  // where to have save the file
                        {
                            file.CopyTo(fileStream);      // that will copy the file in the new location|| that we added  in line 76
                        }

                        ProductImage productImage = new()   //save
                        {
                            ImageUrl = @"\" + productPath + @"\" + fileName,
                            ProductId = productVM.Product.Id,
                        };

                        // that way we will not get an exception if product image is null
                        if (productVM.Product.productImages == null)
                            productVM.Product.productImages = new List<ProductImage>();

                        productVM.Product.productImages.Add(productImage);
                    }

                    _UnitofWork.Product.Update(productVM.Product);
                    _UnitofWork.Save();





                    // change photos and delete old photo if Exists
                    //if (!string.IsNullOrEmpty(productVM.Product.ImageUrl))
                    //{
                    //    var oldimagepath =Path.Combine(wwwRootPath, productVM.Product.ImageUrl.TrimStart('\\'));
                    //    if (System.IO.File.Exists(oldimagepath))
                    //     {
                    //        System.IO.File.Delete(oldimagepath);
                    //    }
                    //}

                    //using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))  // where to have save the file
                    //{
                    //    file.CopyTo(fileStream);      // that will copy the file in the new location|| that we added  in line 76
                    //}
                    //productVM.Product.ImageUrl = @"\images\product\" + fileName;
                }



                return RedirectToAction("Index");
            }
            return View();
        }


        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult DeleteImage(int imageId)  // in the parameter here we will receive image ID based on (asp-route-image-id in view)
        {
            var imageToBeDeleted = _UnitofWork.ProductImage.Get(u => u.Id == imageId);  //  based on image ID we will retrieve the images that we have to delete
            int productId = imageToBeDeleted.ProductId; // we need product Id
            if (imageToBeDeleted != null)
            {
                if (!string.IsNullOrEmpty(imageToBeDeleted.ImageUrl))
                {
                    var oldImagePath = Path.Combine(_WebHostEnvironment.WebRootPath, imageToBeDeleted.ImageUrl.TrimStart('\\')); // we can retrieve the old image path and delete it  

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                _UnitofWork.ProductImage.Remove(imageToBeDeleted);
                _UnitofWork.Save();

                TempData["success"] = "Deleted successfully";
            }

            return RedirectToAction(nameof(Upsert), new { id = productId });
        }







        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> objproductlist = _UnitofWork.Product.GetAll(includeproperties: "Category,Brand,Lenstype").ToList();
            return Json(new { data = objproductlist });
        }

        [Authorize(Roles = SD.Role_Admin)]
        [HttpDelete]
        public IActionResult Delete(int? id)
        {

            var producttobedelete = _UnitofWork.Product.Get(u => u.Id == id);
            if (producttobedelete == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            //         // delete image
            //var oldimagepath = Path.Combine(_WebHostEnvironment.WebRootPath, producttobedelete.ImageUrl.TrimStart('\\'));
            //if (System.IO.File.Exists(oldimagepath))
            //{
            //    System.IO.File.Delete(oldimagepath);
            //}



            //// when we delete the product that will delete ( the folder image  it contain images) 
            string productPath = @"images\products\product-" + id;
            string finalPath = Path.Combine(_WebHostEnvironment.WebRootPath, productPath);

            if (Directory.Exists(finalPath))
            {
                string[] filePaths = Directory.GetFiles(finalPath);
                foreach (string filePath in filePaths)
                {
                    System.IO.File.Delete(filePath);
                }

                Directory.Delete(finalPath);
            }


            _UnitofWork.Product.Remove(producttobedelete);
            _UnitofWork.Save();

            return Json(new { success = false, message = "Delete Successful" });
        }


        #endregion


    }
}
