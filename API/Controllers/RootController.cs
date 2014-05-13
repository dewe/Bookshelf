using System.Web.Http;

namespace API.Controllers
{
    public class RootController : ApiController
    {
        [Route("")]
        public object Get()
        {
            return new
            {
                api_root_url = "http://bshelf.apphb.com",
                books_url = "http://bshelf.apphb.com/books/{isbn}",
                loan_url = "http://bshelf.apphb.com/books/{isbn}/loan",
                documentation_url = "http://docs.bshelf.apiary.io",
                source_code_url = "https://github.com/dewe/Bookshelf",
                design_comments_url = "https://github.com/dewe/Bookshelf/blob/master/Comments.md"
            };
        }
    }
}