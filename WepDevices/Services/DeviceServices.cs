using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WepDevices.Data;

namespace WepDevices.Services
{

    public interface IDeviceServices
    {
        Device create(Device device);

    }
    public class DeviceServices : IDeviceServices
    {
        private readonly taskdeviceEntities db;
        public DeviceServices()
        {
            db = new taskdeviceEntities();
        }

        public Device create(Device device)
        {
            
            device.Aqusationdate = DateTime.Now;
            db.Devices.Add(device);
            int savingresult = db.SaveChanges();
            if (savingresult > 0)
            {
                return device;
            }
            return null;
        }
    }







}