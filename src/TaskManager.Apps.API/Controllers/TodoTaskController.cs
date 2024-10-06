using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Common.Contracts.Commands;
using TaskManager.Application.Common.Contracts.Queries;
using TaskManager.Application.Common.Exceptions;
using TaskManager.Application.TodoTasks.Commands.AddTag;
using TaskManager.Application.TodoTasks.Commands.CreateTodoTask;
using TaskManager.Application.TodoTasks.Queries.GetTodoTaskById;
using TaskManager.Application.TodoTasks.Queries.GetTodoTasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManager.Apps.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodoTaskController : ControllerBase
    {
        private readonly ICommandHandler<CreateTodoTaskCommand, string> _createTodoTaskCommandHandler;
        private readonly ICommandHandler<AddTagCommand, bool> _addTagCommandHandler;

        private readonly IQueryHandler<GetTodoTaskByIdQuery, GetTodoTaskByIdQueryResult> _getTodoTaskByIdQueryResult;
        private readonly IQueryHandler<GetTodoTasksQuery, GetTodoTasksQueryResult> _getTodoTasksQueryResult;

        public TodoTaskController(ICommandHandler<CreateTodoTaskCommand, string> createTodoTaskCommandHandler,
                                  IQueryHandler<GetTodoTaskByIdQuery, GetTodoTaskByIdQueryResult> getTodoTaskByIdQueryResult,
                                  IQueryHandler<GetTodoTasksQuery, GetTodoTasksQueryResult> getTodoTasksQueryResult,
                                  ICommandHandler<AddTagCommand, bool> addTagCommandHandler)
        {
            _createTodoTaskCommandHandler = createTodoTaskCommandHandler;
            _getTodoTaskByIdQueryResult = getTodoTaskByIdQueryResult;
            _getTodoTasksQueryResult = getTodoTasksQueryResult;
            _addTagCommandHandler = addTagCommandHandler;
        }


        // GET: api/<TodoTaskController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var todoTasks = await _getTodoTasksQueryResult.ExecuteAsync(new());
                return Ok(todoTasks);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<TodoTaskController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] string id)
        {
            try
            {
                var todoTask = await _getTodoTaskByIdQueryResult.ExecuteAsync(new GetTodoTaskByIdQuery() 
                { 
                    Id = id
                });

                return Ok(todoTask);
            }
            catch (EntityNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<TodoTaskController>
        /// <summary>
        /// Create a new task
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateTodoTaskCommand command)
        {
            try
            {
                var taskId = await _createTodoTaskCommandHandler.HandleAsync(command, default);
                return Ok(taskId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<TodoTaskController>/5
        /// <summary>
        /// Update existing task
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string command)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<TodoTaskController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{id}/Tag")]
        public async Task<IActionResult> AddTagAsync([FromRoute] string id, [FromBody] string name)
        {
            try
            {
                var result = await _addTagCommandHandler.HandleAsync(new()
                {
                    TodoTaskId = id,
                    Name = name
                });

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
