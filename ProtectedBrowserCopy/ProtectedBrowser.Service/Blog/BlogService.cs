using ProtectedBrowser.DBRepository.Blog;
using ProtectedBrowser.Domain.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Service.Blog
{
    public class BlogService : IBlogService
    {
        public BlogDBService _blogDBService;
        public BlogService()
        {
            _blogDBService = new BlogDBService();
        }
        public long BlogInsert(BlogModel model)
        {
            return _blogDBService.BlogInsert(model);
        }
        public void BlogUpdate(BlogModel model)
        {
            _blogDBService.BlogUpdate(model);
        }
        public List<BlogModel> BlogSelect(long? blogId, long? categoryId, bool? isActive = null, int? next = null, int? offset = null)
        {
            return _blogDBService.BlogSelect(blogId, categoryId, isActive, next, offset);
        }
    }
}
