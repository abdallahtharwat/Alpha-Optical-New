using Alpha.DataAccess.Data;
using Alpha.DataAccess.Repository.IRepository;
using Alpha.Models;
using ALpha.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Alpha_Optical.Areas.Admin.Controllers
{
    [Area("Admin")]
           // authorize for route 
    public class CategoryController : Controller
    {
        private readonly IUnitofWork _UnitofWork;
        public CategoryController(IUnitofWork unitofWork)
        {
            _UnitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            List<Category> objcategorylist = _UnitofWork.Category.GetAll().ToList();
            return View(objcategorylist);
        }

        [Authorize(Roles = SD.Role_Admin)]
        // get create
        public IActionResult Create()
        {

            return View();
        }

        // post create
        [HttpPost]
        public IActionResult Create(Category obj)  //  (obj== anta btstlm el value el fe post method input fe el create view )  when we have the obj here that will have the value of category that needs to be add
        {

            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("DisplayOrder", "the Display order can not exactly match the name");
            }

            //Validation for sliver side
            if (ModelState.IsValid)
            {
                _UnitofWork.Category.add(obj);
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
            Category categoryfromDb = _UnitofWork.Category.Get(u => u.Id == id); ;
            if (categoryfromDb == null)
            {
                return NotFound();
            }

            return View(categoryfromDb);
        }

        // post Edit
        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            //Validation for sliver side
            if (ModelState.IsValid)
            {
                _UnitofWork.Category.Update(obj);
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
            Category categoryfromDb = _UnitofWork.Category.Get(u => u.Id == id);
            if (categoryfromDb == null)
            {
                return NotFound();
            }

            return View(categoryfromDb);
        }

        // post Delete
        [HttpPost, ActionName("Delete")]
        public IActionResult Deletepost(int? id)
        {
            // Category? obj = _db.Category.Get(u => u.Id == id);
            Category obj = _UnitofWork.Category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _UnitofWork.Category.Remove(obj);
            _UnitofWork.Save();
            TempData["success"] = "  Delete successfully";
            return RedirectToAction("Index");


        }






        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Category> objcategorylist = _UnitofWork.Category.GetAll().ToList();
            return Json(new { data = objcategorylist });
        }


   

        #endregion









    }
}
