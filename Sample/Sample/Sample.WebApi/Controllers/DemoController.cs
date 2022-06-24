using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sample.WebApi.Controllers
{
    
    [Authorize("ApiScope")]//指定控制器
    [ApiController]
    [Route("[controller]/[action]")]
    public class DemoController:ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(from claim in User.Claims select new  { claim.Type , claim.Value});
        }
    }
}
