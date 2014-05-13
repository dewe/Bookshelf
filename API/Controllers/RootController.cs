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
                bookshelf_url = "http://bshelf.apphb.com/books",
                books_url = "http://bshelf.apphb.com/books/{isbn}",
                loan_url = "http://bshelf.apphb.com/books/{isbn}/loan",
                documentation_url = "http://docs.bshelf.apiary.io",
                source_code_url = "https://github.com/dewe/bookshelf",
                design_comments_url = "https://github.com/dewe/bookshelf/blob/master/Comments.md"
            };
        }
    }
}