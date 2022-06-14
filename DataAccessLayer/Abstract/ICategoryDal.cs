using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    interface ICategoryDal
    {

        List<Category> LisAllCategory();
        void AddBlog(Category category);
        void DeleteBlog(Category category);
        void UpdateBlog(Category category);
        Category GetById(int id);
    }
}
