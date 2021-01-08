using AdvancedSoftware.DataAccess.Entity;
using AdvancedSoftware.DataAccess.Execution;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace NETBoilerplate.Server.Controllers
{
    [Authorize]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    [Route("api/[controller]")]
    public class CommonController<T> : ODataController where T : class, IEntityBase
    {
        private readonly IService<T> _service;

        public CommonController(IService<T> service)
        {
            _service = service;
        }
        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_service.AsDbSet());
        }
        [HttpGet("{key}")]
        [EnableQuery]
        public IActionResult Get([FromODataUri] int key)
        {
            return Ok(_service.AsDbSet().FirstOrDefault(y => y.Id == key));
        }
        [HttpPost]
        [EnableQuery]
        public async Task<IActionResult> Post([FromBody] JObject entity)
        {
            var data = entity.ToObject<T>();
            await _service.AddAsync(data);
            return Created(data);
        }
        [HttpPut]
        [EnableQuery]
        public IActionResult Put(int key, [FromBody] JObject entity)
        {
            var data = entity.ToObject<T>();
            _service.Update(data);
            return Created(data);
        }
        [HttpDelete]
        public IActionResult Delete([FromODataUri] int key)
        {
            _service.Delete(key);
            return Ok();
        }
    }
}
