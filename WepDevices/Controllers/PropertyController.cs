using AutoMapper;
using Microsoft.AspNet.Identity;
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
    public class PropertyController : Controller
    {

        private readonly PropertyServices propertyservice;
        private readonly IMapper mapper;
        private taskdeviceEntities db;
        public PropertyController()
        {
            propertyservice = new PropertyServices();
            mapper = AutoMapperConfig.Mapper;
            db = new taskdeviceEntities();
        }
        // GET: Category
       
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(PropertyModel data)
        {
            if (ModelState.IsValid)
            {
                data.User_Id= User.Identity.GetUserId();
                var propdto = mapper.Map<Property>(data);
                var result = propertyservice.create(propdto);
            }

            return RedirectToAction("Create","Device");
        }
        // GET: Properties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
          
            return View(property);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DeviceNameProperty,Processor,Dimension,MACAddress,IPAddress,AllowUsb,NetWorkSpeed,OperatingSystem,ports,HD,User_Id")] Property property)
        {
            if (ModelState.IsValid)
            {
                property.User_Id = User.Identity.GetUserId();
                db.Entry(property).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create","Device");
            }
            ViewBag.User_Id = new SelectList(db.AspNetUsers, "Id", "Email", property.User_Id);
            return View(property);
        }

        
      


    }
}