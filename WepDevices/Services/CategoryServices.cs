using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WepDevices.Data;

namespace WepDevices.Services
{
   

    public interface ICategoryServices
    {
        Category create(Category category);
        List<Category> ReadAll();
    }
    public class CategoryServices : ICategoryServices
    {
        private readonly taskdeviceEntities db;
        public CategoryServices()
        {
            db = new taskdeviceEntities();
        }

        public Category create(Category category)
        {
            db.Categories.Add(category);
            int savingresult = db.SaveChanges();
            if (savingresult > 0)
            {
                return category;
            }
            return null;
        }

        public List<Category> ReadAll()
        {
            return db.Categories.ToList();
        }
    }



}