using ProtectedBrowser.Domain.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Service.Category
{
    public interface ICategoryService
    {
        /// <summary>
        /// use for insert user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        long CategoryInsert(CategoryModel model);
        /// <summary>
        /// Method for update category
        /// </summary>
        /// <param name="model"></param>
        void CategoryUpdate(CategoryModel model);

        /// <summary>
        /// use for select all category or select category by id 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<CategoryModel> CategorySelect(long? categoryId, bool? isActive = null, int? next = null, int? offset = null);
    }
}
