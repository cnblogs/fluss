using Cnblogs.Fluss.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cnblogs.Fluss.Web.Controllers
{
    public class BlogController : Controller
    {
        [Route("")]
        public IActionResult Home()
        {
            var page = new HomeBlogPage() { PageTitle = "首页" };
            return View(page);
        }

        [Route("p/{postId}.html")]
        public IActionResult PostDetail(int postId)
        {
            var page = new PostDetailBlogPage { PageTitle = "Test Post" };
            return View(page);
        }
    }
}