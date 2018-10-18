using ProtectedBrowser.DBRepository.Category;
using ProtectedBrowser.Domain.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Service.Category
{
    public class CategoryService : ICategoryService
    {
        public CategoryDBService _categoryDBService;
        public CategoryService()
        {
            _categoryDBService = new CategoryDBService();
        }
        public long CategoryInsert(CategoryModel model)
        {
            return _categoryDBService.CategoryInsert(model);
        }

        public void CategoryUpdate(CategoryModel model)
        {
            _categoryDBService.CategoryUpdate(model);
        }

        public List<CategoryModel> CategorySelect(long? categoryId, bool? isActive = null, int? next = null, int? offset = null)
        {
            return _categoryDBService.CategorySelect(categoryId, isActive, next, offset);
        }
    }
}
