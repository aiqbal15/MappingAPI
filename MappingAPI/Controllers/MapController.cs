using Microsoft.AspNetCore.Mvc;
using MappingUtilities.Handlers;
using DataModels;

namespace MappingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MapController : Controller
    {
        [HttpPost(Name = "MapData")]
        public object Post([FromBody] Object data, [FromQuery] string sourceType = "", [FromQuery] string targetType = "")
        {
            try
            {
                return StatusCode(200, new MapHandler().Map(data, sourceType, targetType));
            }
            catch (Exception ex) 
            {
                return StatusCode(400, 
                    new Error()
                    {
                        ErrorMessage = "Unable to map source data to target.",
                        InternalErrorMessage = ex.Message
                    }
                );
            }
        }
    }
}
