using System.Collections.Generic;

namespace Cnblogs.Fluss.Web.Models
{
    public class HomeBlogPage : BaseBlogPage
    {
        public HomeBlogPage(int pageIndex, IEnumerable<BlogPostViewModel> posts)
        {
            PageIndex = pageIndex;
            Posts = posts;
        }

        public int PageIndex { get; }
        public IEnumerable<BlogPostViewModel> Posts { get; }
    }
}