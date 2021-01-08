using NETBoilerplate.Shared.Entity;
using NETBoilerplate.Shared.Service;

namespace NETBoilerplate.Server.Controllers
{
    public class ContentController : CommonController<Content>
    {
        private readonly IContentService _contentService;
        public ContentController(IContentService contentService) : base(contentService)
        {
            _contentService = contentService;
        }
    }
}
