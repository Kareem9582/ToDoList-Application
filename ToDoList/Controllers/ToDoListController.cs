using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ToDoList.Api.Contracts;
using ToDoList.Api.Models;
using ToDoList.Domain.Objects;

namespace ToDoList.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
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
            if (string.IsNullOrEmpty(User?.Identity?.Name))
                return Problem("No Logged User Found");

            var result = await _toDoListService.GetItems(User?.Identity?.Name);
            return Ok(result);
        }
        #endregion

        #region Get Item By Id 
        /// <summary>
        /// This Endpoint should get Item by Id
        /// </summary>
        /// <remarks>
        /// Sample Request 
        /// 
        ///     GET /GetItem/{:id}
        /// </remarks>
        /// <param name="id">Id of the item Selected</param>
        /// <returns>To do Item list created by the logged user</returns>
        [HttpGet("GetItem/{id}")]
        public async Task<IActionResult> GetItemById([FromRoute] Guid id)
        {
            if (string.IsNullOrEmpty(User?.Identity?.Name))
                return Problem("No Logged User Found");

            var result = await _toDoListService.GetItemById(id, User?.Identity?.Name);
            return Ok(result);
        }
        #endregion

        #region Insert Item

        /// <summary>
        /// This Endpoint To Insert Item
        /// </summary>
        /// <remarks>
        /// Sample Request 
        /// 
        ///     POST 
        /// </remarks>
        /// <param name="item">The Item that will be created</param>
        /// <returns>201</returns>
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertItemModel item)
        {
            if (string.IsNullOrEmpty(User?.Identity?.Name))
                return Problem("No Logged User Found");

            var result = await _toDoListService.Insert(item.Title, item.Description, User?.Identity?.Name);
            if (result == 1)
                return Created();
            return Problem("Unkown Problem Happend");
        }

        #endregion

        #region Update Item

        /// <summary>
        /// This Endpoint To Update Item
        /// </summary>
        /// <remarks>
        /// Sample Request 
        /// 
        ///     PUT /
        /// </remarks>
        /// <param name="item">The Item that will be updated</param>
        /// <returns>201</returns>
        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] UpdateItemModel item)
        {
            if (string.IsNullOrEmpty(User?.Identity?.Name))
                return Problem("No Logged User Found");

            var result = await _toDoListService.Update(item.Id, item.Title, item.Description,item.IsCompleted,item.CompletionDate, User?.Identity?.Name);
            if (result == 1)
                return StatusCode((int)HttpStatusCode.Accepted);
            else if (result == 0)
                return NotFound("No Item found with this Id");

            return Problem("Unkown Problem Happend");
        }

        #endregion

        #region Delete Item

        /// <summary>
        /// This Endpoint To Delete Item
        /// </summary>
        /// <remarks>
        /// Sample Request 
        /// 
        ///     PUT /
        /// </remarks>
        /// <param name="id">The Item that will be Deleted</param>
        /// <returns>201</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (string.IsNullOrEmpty(User?.Identity?.Name))
                return Problem("No Logged User Found");

            var result = await _toDoListService.Delete(id, User?.Identity?.Name);
            if (result == 1)
                return StatusCode((int)HttpStatusCode.Accepted);
            else if (result == 0)
                return NotFound("No Item found with this Id");

            return Problem("Unkown Problem Happend");
        }

        #endregion

        #region Complete Task
        /// <summary>
        /// Mark Task as Complete
        /// </summary>
        /// <remarks>
        /// Sample Request 
        /// 
        ///     PUT /Complete/{id}
        /// </remarks>
        /// <param name="id">The Item that will be marked as completed</param>
        /// <returns>201</returns>
        [HttpPut("Complete/{id}")]
        public async Task<IActionResult> MarkAsComplete([FromRoute] Guid id)
        {
            if (string.IsNullOrEmpty(User?.Identity?.Name))
                return Problem("No Logged User Found");

            var result = await _toDoListService.MarkAsComplete(id, User?.Identity?.Name);
            if (result == 1)
                return StatusCode((int)HttpStatusCode.Accepted);
            else if (result == 0)
                return NotFound("No Item found with this Id");
            
            return Problem("Unknown Problem Happend");
        }
        #endregion

        #region Search
        /// <summary>
        /// Search For Items with certain critceria 
        /// </summary>
        /// <remarks>
        /// Sample Request 
        /// 
        ///     PUT /Search/
        /// </remarks>
        /// <param name="Filter">The Search Filter</param>
        /// <returns>List of items that Matches the search</returns>
        [HttpPost("Search")]
        public async Task<IActionResult> Search([FromBody] Filter filter)
        {
            if (string.IsNullOrEmpty(User?.Identity?.Name))
                return Problem("No Logged User Found");

            var result = await _toDoListService.Search(filter, User?.Identity?.Name);
            return Ok(result);
        }
        #endregion

        /// <summary>
        /// This endpoint will throw an exception
        /// </summary>
        /// <returns></returns>
        [HttpGet("CallException")]
        public Task<IActionResult> CallException()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
