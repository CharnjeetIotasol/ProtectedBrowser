using ProtectedBrowser.Domain.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Service.Blog
{
    public interface IBlogService
    {
        long BlogInsert(BlogModel model);
        void BlogUpdate(BlogModel model);
        List<BlogModel> BlogSelect(long? blogId, long? categoryId, bool? isActive = null, int? next = null, int? offset = null);
    }
}
