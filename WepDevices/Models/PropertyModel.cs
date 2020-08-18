using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WepDevices.Models
{
    public class PropertyModel
    {
        public int Id { get; set; }
        public string User_Id { get; set; }
        public string DeviceNameProperty { get; set; }
        public string HD { get; set; }
        public string Processor { get; set; }
        public string Dimension { get; set; }
        public string MACAddress { get; set; }
        public string IPAddress { get; set; }
        public string AllowUsb { get; set; }
        public string NetWorkSpeed { get; set; }
        public string OperatingSystem { get; set; }
        public string ports { get; set; }

    }
}