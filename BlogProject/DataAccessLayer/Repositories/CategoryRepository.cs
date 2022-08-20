using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
  public  class CategoryRepository : ICategoryDal
    {
        Context c = new Context();
        public void AddBlog(Category category)
        {
            c.Add(category);
            c.SaveChanges();
        }

        public void DeleteBlog(Category category)
        {
            c.Remove(category);
            c.SaveChanges();
        }

        public Category GetById(int id)
        {
            return c.Categories.Find(id);
        }

        public List<Category> LisAllCategory()
        {
            return c.Categories.ToList();
        }

        public void UpdateBlog(Category category)
        {
            c.Update(category);
            c.SaveChanges();
        }
    }
}
