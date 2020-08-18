using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WepDevices.Data;

namespace WepDevices.Services
{
    public interface IPropertyServices
    {
        Property create(Property property);
        List<Property> ReadAll();
        int Updateproperty(Property updatedproperty);
        Property ReadById(int id);

    }
    public class PropertyServices : IPropertyServices
    {
        private readonly taskdeviceEntities db;
        public PropertyServices()
        {
            db = new taskdeviceEntities();
        }
        public Property create(Property property)
        {
            db.Properties.Add(property);
            int savingresult = db.SaveChanges();
            if (savingresult > 0)
            {
                return property;
            }
            return null;
        }
        public List<Property> ReadAll()
        {
            return db.Properties.ToList();
        }

        public Property ReadById(int id)
        {
            return db.Properties.Find(id);
        }

        public int Updateproperty(Property updatedproperty)
        {
        
            db.Properties.Attach(updatedproperty);
            db.Entry(updatedproperty).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
    }
}