using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ToDoList.Api.Contracts;

namespace ToDoList.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ToDoListController : ControllerBase
    {
        private readonly IToDoListService _toDoListService;

        public ToDoListController(IToDoListService toDoListService)
        {
            _toDoListService = toDoListService;
        }

        #region Get All Items 
        /// <summary>
        /// This Endpoint should get the items that is related to the logged User
        /// </summary>
        /// <remarks>
        /// Sample Request 
        /// 
        ///     GET /GetItems/
        /// </remarks>
        /// <returns>List of ToDoItems</returns>
        [HttpGet("GetItems")]
        public async Task<IActionResult> GetItems()
        {
            if(string.IsNullOrEmpty(User?.Identity?.Name))
                return Problem("No Logged User Found");

            var result = await _toDoListService.GetItems(User?.Identity?.Name);
                return Ok(result);
        }
        #endregion

    }
}
