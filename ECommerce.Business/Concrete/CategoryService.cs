using ECommerce.Business.Abstract;
using ECommerce.DataAccess.Abstraction;
using ECommerce.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryService(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            var categories = await _categoryDal.GetList();

            categories.Insert(0, new Category { CategoryId = 0, CategoryName = "All Categories" });

            return categories;
        }
    }
}
