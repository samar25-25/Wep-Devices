using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WepDevices.Data;
using WepDevices.Models;

namespace WepDevices.Controllers
{
    public class HomeController : Controller
    {
        private taskdeviceEntities sd = new taskdeviceEntities();
        public ActionResult Index()
        {
            return View();
        }


        //public ActionResult DeviceIndex()
        //{
        //    List<Category> categoryName = sd.Categories.ToList();
        //    List<Device> deviceName = sd.Devices.ToList();
        //    List<Property> propertyName = sd.Properties.ToList();





        //    var multipletables = from c in categoryName
        //                         join st in deviceName on
        //                         c.Id equals st.Category_Id 
        //                          into
        //                         table1
        //                         from st in table1.DefaultIfEmpty()
        //                         join ct in propertyName on st.Property_Id
        //                         equals ct.Id into table2
        //                         from ct in table2.DefaultIfEmpty()
        //                         select new MultipleClass
        //                         {
        //                             devicedetails = st,
        //                             categorydetails = c,
        //                             properties = ct
        //                         };
        //    return View( multipletables);

        //}
        public ActionResult IndexDevices()
        {
            List<Category> categoryName = sd.Categories.ToList();
            List<Device> deviceName = sd.Devices.ToList();
            List<Property> propertyName = sd.Properties.ToList();
            
            
                var userId = User.Identity.GetUserName();
                ViewData["jointables"] = from c in deviceName
                                         join st in categoryName on c.Category_Id equals
                                         st.Id into table1
                                         from st in table1.DefaultIfEmpty()
                                         join x in deviceName on c.Property_Id equals
                                         x.Id 
                                         into table2
                                         
                                         from x in table2.DefaultIfEmpty()
                                         
                                         select new MultipleClass { devicedetails = c, categorydetails = st };
               
                return View(ViewData["jointables"]);
            
           
        }











        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}