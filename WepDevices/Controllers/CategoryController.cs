using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WepDevices.App_Start;
using WepDevices.Data;
using WepDevices.Models;
using WepDevices.Services;

namespace WepDevices.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {


        private readonly CategoryServices categoryservice;
        private readonly IMapper mapper;
        private taskdeviceEntities db;
        public CategoryController()
        {
            categoryservice = new CategoryServices();
            mapper = AutoMapperConfig.Mapper;
            db = new taskdeviceEntities();
        }
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CategoryModel data)
        {
            if (ModelState.IsValid) {
                var categorydto = mapper.Map<Category>(data);
                var result = categoryservice.create(categorydto);
            }
           
            return View(data);
        }
    }
}