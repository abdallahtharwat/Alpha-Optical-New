using Alpha.DataAccess.Data;
using Alpha.DataAccess.Repository.IRepository;
using Alpha.Models;
using Alpha.Models.Models;
using ALpha.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alpha_Optical.Areas.Admin.Controllers
{
    [Area("Admin")]
           // authorize for route 
    public class OtherFeatureController : Controller
    {
        private readonly IUnitofWork _UnitofWork;
        public OtherFeatureController(IUnitofWork unitofWork)
        {
            _UnitofWork = unitofWork;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _UnitofWork.OtherFeature.GetAllasync());
        }


        // get create
        public IActionResult Create()
        {

            return View();
        }


        // post create
        [HttpPost]
        public async Task<IActionResult> Create(OtherFeature header)  //  (obj== anta btstlm el value el fe post method input fe el create view )  when we have the obj here that will have the value of category that needs to be add
        {


            //Validation for sliver side
            if (ModelState.IsValid)
            {

                try
                {
                    var featuretest = await _UnitofWork.OtherFeature.Addasync(header);
                    if (featuretest)
                    {
                        TempData["success"] = "  Create successfully";
                        return RedirectToAction("Index");
                    }

                }
                catch (Exception)
                {


                }


            }
            return View();
        }



        // get Edit
        public async Task<IActionResult> Edit(int id)
        {

            // how to create edit btton
            if (id == 0)
            {
                return NotFound();
            }

            var featuretest = await _UnitofWork.OtherFeature.Getasync(id);
            if (featuretest == null)
            {
                return NotFound();
            }

            return View(featuretest);
        }

        // post Edit
        [HttpPost]
        public async Task<IActionResult> Edit(int id, OtherFeature header)
        {

            if (id != header.Id)
            {
                return NotFound();
            }

            //Validation for sliver side
            if (ModelState.IsValid)
            {

                try
                {
                    var featuretest = await _UnitofWork.OtherFeature.Updateasync(header);
                    if (featuretest)
                    {
                        TempData["success"] = "  Update successfully";
                        return RedirectToAction("Index");
                    }


                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await IsAExist(header.Id)))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                }

            }
            return View(header);
        }

        public async Task<bool> IsAExist(int id)
        {
            return await _UnitofWork.OtherFeature.OtherFeatureAnyAsync(id);
        }



        public async Task<JsonResult> JsonDelete(int? id)
        {
            if (id == null)
            {
                return Json("Failed");

            }
            var result = await _UnitofWork.OtherFeature.Deleteasync(id.Value);
            if (result)
            {

                return Json("Removed");
            }
            return Json("Failed");
        }

        public async Task<JsonResult> JsonDuplicate(int? id)
        {
            if (id == null)
            {
                return Json("Failed");

            }
            var result = await _UnitofWork.OtherFeature.Duplicateasync(id.Value);
            if (result)
            {

                //_UnitofWork.Save();
                TempData["success"] = "  duplicate successfully";
                return Json("Duplicated");
            }
            return Json("Failed");

        }











    }
}
