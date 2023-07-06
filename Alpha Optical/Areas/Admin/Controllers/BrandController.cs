using Alpha.DataAccess.Data;
using Alpha.DataAccess.Repository.IRepository;
using Alpha.Models;
using Alpha.Models.Models;
using ALpha.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Alpha_Optical.Areas.Admin.Controllers
{
    [Area("Admin")]
           // authorize for route 
    public class BrandController : Controller
    {
        private readonly IUnitofWork _UnitofWork;
        public BrandController(IUnitofWork unitofWork)
        {
            _UnitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            List<Brand> objBrandlist = _UnitofWork.Brand.GetAll().ToList();
            return View(objBrandlist);
        }

        [Authorize]
        // get create
        public IActionResult Create()
        {

            return View();
        }

        // post create
        [HttpPost]
        public IActionResult Create(Brand obj)  //  (obj== anta btstlm el value el fe post method input fe el create view )  when we have the obj here that will have the value of category that needs to be add
        {

            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("DisplayOrder", "the Display order can not exactly match the name");
            }

            //Validation for sliver side
            if (ModelState.IsValid)
            {
                _UnitofWork.Brand.add(obj);
                _UnitofWork.Save();
                TempData["success"] = "  Create successfully";
                return RedirectToAction("Index");
            }
            return View();
        }


        [Authorize(Roles = SD.Role_Admin)]
        // get Edit
        public IActionResult Edit(int? id)
        {

            // how to create edit btton
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //Category? categoryfromDb = _db.Categories.Get(u => u.Id == id);
            Brand BrandfromDb = _UnitofWork.Brand.Get(u => u.Id == id); ;
            if (BrandfromDb == null)
            {
                return NotFound();
            }

            return View(BrandfromDb);
        }

        // post Edit
        [HttpPost]
        public IActionResult Edit(Brand obj)
        {

            //Validation for sliver side
            if (ModelState.IsValid)
            {
                _UnitofWork.Brand.Update(obj);
                _UnitofWork.Save();
                TempData["success"] = "  Update successfully";
                return RedirectToAction("Index");
            }
            return View();
        }



        [Authorize(Roles = SD.Role_Admin)]
        // get Delete
        public IActionResult Delete(int? id)
        {

            // how to create edit btton
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //  Category? categoryfromDb = _UnitofWork.Category.Get(u => u.Id == id);
            Brand BrandfromDb = _UnitofWork.Brand.Get(u => u.Id == id);
            if (BrandfromDb == null)
            {
                return NotFound();
            }

            return View(BrandfromDb);
        }

        // post Delete
        [HttpPost, ActionName("Delete")]
        public IActionResult Deletepost(int? id)
        {
            // Category? obj = _db.Category.Get(u => u.Id == id);
            Brand obj = _UnitofWork.Brand.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _UnitofWork.Brand.Remove(obj);
            _UnitofWork.Save();
            TempData["success"] = "  Delete successfully";
            return RedirectToAction("Index");


        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Brand> objBrandlist = _UnitofWork.Brand.GetAll().ToList();
            return Json(new { data = objBrandlist });
        }




        #endregion


    }
}
