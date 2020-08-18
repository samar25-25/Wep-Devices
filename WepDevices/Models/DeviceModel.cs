using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WepDevices.Models
{
    public class DeviceModel
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
        [Display(Name = "Serial No")]
        public string SerialNo { get; set; }
        [Display(Name = "Created Date")]
        public DateTime Aqusationdate { get; set; }
       
        public string Memo { get; set; }
        [Display(Name = "Device Category")]
        public int Category_Id { get; set; }
        [Display(Name = "Properties Refrence")]
        public int Property_Id { get; set; }

        //public virtual Category Category { get; set; }
        //public virtual Property Property { get; set; }


        public string Category_Name { get; set; }
        public string Property { get; set; }
        public SelectList Categories { get; set; }
        public SelectList properties { get; set; }
    }
}