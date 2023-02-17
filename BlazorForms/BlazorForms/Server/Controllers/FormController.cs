using BlazorForms.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorForms.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormController : ControllerBase
    {
        [HttpGet("GetContactModel")]
        public async Task<ContactModel> GetContactModel()
        {
            await Task.Yield();
            return new ContactModel();
        }
    }
}
