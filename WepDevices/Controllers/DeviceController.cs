using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WepDevices.App_Start;
using WepDevices.Data;
using WepDevices.Models;
using WepDevices.Services;

namespace WepDevices.Controllers
{
    [Authorize]
    public class DeviceController : Controller
    {
        private readonly PropertyServices propertyservice;

        private readonly CategoryServices categoryservices;
        private readonly DeviceServices deviceServices;
        private readonly IMapper mapper;
        private taskdeviceEntities db;
        public DeviceController()
        {
            deviceServices = new DeviceServices();
            categoryservices = new CategoryServices();
               propertyservice = new PropertyServices();
            mapper = AutoMapperConfig.Mapper;
            db = new taskdeviceEntities();
        }
        // GET: Device
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            var deviceModel = new DeviceModel();
            InitSelectList(ref deviceModel);
            return View(deviceModel);
        }
        [HttpPost]
        public ActionResult Create(DeviceModel deviceData)
        {
            InitSelectList(ref deviceData);
            if (ModelState.IsValid)
            {
                 var deviceDto = mapper.Map<Device>(deviceData);
                    deviceDto.Category = null;
                deviceDto.Property = null;
                var result = deviceServices.create(deviceDto);
                return RedirectToAction("IndexDevices", "Home");
            }
                return View(deviceData);
        }

        private void InitSelectList(ref DeviceModel deviceModel)
        {
            var mappedCategoriesList = GetCategories();
            deviceModel.Categories = new SelectList(mappedCategoriesList, "Id", "Name");


            var mappedTrainersList = GetProperties();

            deviceModel.properties = new SelectList(mappedTrainersList, "Id", "DeviceNameProperty");
        }
        private IEnumerable<CategoryModel> GetCategories()
        {
            var categories = categoryservices.ReadAll();
            return mapper.Map<IEnumerable<CategoryModel>>(categories);
        }
        private IEnumerable<PropertyModel> GetProperties()
        {
            var propreties = propertyservice.ReadAll();
            return mapper.Map<IEnumerable<PropertyModel>>(propreties);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Device property = db.Devices.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            ViewBag.Property_Id = new SelectList(db.Properties, "Id", "DeviceNameProperty");
            ViewBag.Category_Id = new SelectList(db.Categories, "Id", "Name");

            return View(property);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,SerialNo,Aqusationdate,Memo,Category_Id,Property_Id")] Device property)
        {
            if (ModelState.IsValid)
            {
                property.Aqusationdate = DateTime.Now;
                db.Entry(property).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexDevices","Home");
            }
            //ViewBag.User_Id = new SelectList(db.AspNetUsers, "Id", "Email", property.User_Id);
            ViewBag.Property_Id = new SelectList(db.Properties, "Id", "DeviceNameProperty", property.Id);
           ViewBag.Category_Id = new SelectList(db.Categories, "Id", "Name", property.Id);
            return View(property);
        }

    }
}