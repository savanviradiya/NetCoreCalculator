﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreCalculator.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Operation model)
        {
            switch(model.OperationType)
            {
                case(OperationType.Addition):
                    model.Result = model.NumberA + model.NumberB;
                    break;
                case (OperationType.Subtraction):
                    model.Result = model.NumberA - model.NumberB;
                    break;
                case (OperationType.Multiplication):
                    model.Result = model.NumberA * model.NumberB;
                    break;
                case (OperationType.division):
                    model.Result = model.NumberA / model.NumberB;
                    break;
            }
            
            
            //if (model.OperationType == OperationType.Addition)
            //    model.Result = model.NumberA + model.NumberB;
            return View(model);

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
