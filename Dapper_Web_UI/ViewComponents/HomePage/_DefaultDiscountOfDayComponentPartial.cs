﻿using System;
using Microsoft.AspNetCore.Mvc;

namespace Dapper_Web_UI.ViewComponents.HomePage
{
	public class _DefaultDiscountOfDayComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

