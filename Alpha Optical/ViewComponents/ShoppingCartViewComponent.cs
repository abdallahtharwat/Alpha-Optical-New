﻿using Alpha.DataAccess.Repository.IRepository;
using ALpha.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Alpha_Optical.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    {

        private readonly IUnitofWork _unitOfWork;
        public ShoppingCartViewComponent(IUnitofWork UnitofWork)
        {

            _unitOfWork = UnitofWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim != null)
            {

                if (HttpContext.Session.GetInt32(SD.SessionCart) == null)
                {
                    HttpContext.Session.SetInt32(SD.SessionCart,
                    _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value).Count());
                }

                return View(HttpContext.Session.GetInt32(SD.SessionCart));
            }
            else
            {
                HttpContext.Session.Clear();
                return View(0);
            }

        }

    }
}
