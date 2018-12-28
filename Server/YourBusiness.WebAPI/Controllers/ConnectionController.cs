using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace YourBusiness.WebAPI.Controllers
{
    /// <summary>
    /// Controller for managing connections
    /// </summary>
    [Route("your-business/[controller]/[action]")]
    [Produces("application/json")]
    [ApiController]
    public class ConnectionController : ControllerBase
    {
        /// <summary>
        /// Checks the connection.
        /// </summary>
        /// <returns>
        /// The string 'Ping'.
        /// </returns>
        [HttpGet()]
        public async Task<ActionResult<string>> Ping()
        {
            var retVal = string.Empty;

            retVal = await Task.Run(() =>
            {
                return "Ping";
            });

            return retVal;
        }

        /// <summary>
        /// Authenticates the user and receives the access token.
        /// </summary>
        [HttpGet()]
        public void Authenticate()
        {
        }
    }
}