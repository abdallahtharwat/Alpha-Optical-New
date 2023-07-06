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
    public class LenstypeController : Controller
    {
        private readonly IUnitofWork _UnitofWork;
        public LenstypeController(IUnitofWork unitofWork)
        {
            _UnitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            List<Lenstype> objLenstypelist = _UnitofWork.Lenstype.GetAll().ToList();
            return View(objLenstypelist);
        }

        [Authorize(Roles = SD.Role_Admin)]
        // get create
        public IActionResult Create()
        {

            return View();
        }

        // post create
        [HttpPost]
        public IActionResult Create(Lenstype obj)  //  (obj== anta btstlm el value el fe post method input fe el create view )  when we have the obj here that will have the value of category that needs to be add
        {

            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("DisplayOrder", "the Display order can not exactly match the name");
            }

            //Validation for sliver side
            if (ModelState.IsValid)
            {
                _UnitofWork.Lenstype.add(obj);
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
            Lenstype lenstypefromDb = _UnitofWork.Lenstype.Get(u => u.Id == id); ;
            if (lenstypefromDb == null)
            {
                return NotFound();
            }

            return View(lenstypefromDb);
        }

        // post Edit
        [HttpPost]
        public IActionResult Edit(Lenstype obj)
        {

            //Validation for sliver side
            if (ModelState.IsValid)
            {
                _UnitofWork.Lenstype.Update(obj);
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
            Lenstype LenstypefromDb = _UnitofWork.Lenstype.Get(u => u.Id == id);
            if (LenstypefromDb == null)
            {
                return NotFound();
            }

            return View(LenstypefromDb);
        }

        // post Delete
        [HttpPost, ActionName("Delete")]
        public IActionResult Deletepost(int? id)
        {
            // Category? obj = _db.Category.Get(u => u.Id == id);
            Lenstype obj = _UnitofWork.Lenstype.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _UnitofWork.Lenstype.Remove(obj);
            _UnitofWork.Save();
            TempData["success"] = "  Delete successfully";
            return RedirectToAction("Index");


        }

    }
}
