﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebClient.Controllers
{
    public class AuthController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
    }
}