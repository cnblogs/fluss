using System.Collections.Generic;

namespace Cnblogs.Fluss.Web.Models
{
    public class HomeBlogPage : BaseBlogPage
    {
        public HomeBlogPage(int pageIndex, IEnumerable<BlogPostViewModel> posts, BlogSiteViewModel blogSiteViewModel)
        {
            PageIndex = pageIndex;
            Posts = posts;
            BlogSiteViewModel = blogSiteViewModel;
        }

        public BlogSiteViewModel BlogSiteViewModel { get; }
        public int PageIndex { get; }
        public IEnumerable<BlogPostViewModel> Posts { get; }
    }
}