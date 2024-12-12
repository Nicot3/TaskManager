using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Common.Contracts.Commands;
using TaskManager.Application.Common.Contracts.Queries;
using TaskManager.Application.Common.Exceptions;
using TaskManager.Application.TodoTasks.Commands.AddTag;
using TaskManager.Application.TodoTasks.Commands.CreateTodoTask;
using TaskManager.Application.TodoTasks.Commands.DeleteTodoTask;
using TaskManager.Application.TodoTasks.Queries.GetIncompleteTodoTasks;
using TaskManager.Application.TodoTasks.Queries.GetTodoTaskById;
using TaskManager.Application.TodoTasks.Queries.GetTodoTasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManager.Apps.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodoTaskController : ControllerBase
    {
        private readonly ICommandHandler<CreateTodoTaskCommand, string> _createTodoTaskCommand;
        private readonly ICommandHandler<AddTagCommand, bool> _addTagCommand;
        private readonly ICommandHandler<DeleteTodoTaskCommand> _deleteTodoTaskCommand;

        private readonly IQueryHandler<GetTodoTaskByIdQuery, GetTodoTaskByIdQueryResult> _getTodoTaskByIdQuery;
        private readonly IQueryHandler<GetTodoTasksQuery, GetTodoTasksQueryResult> _getTodoTasksQuery;
        private readonly IQueryHandler<GetIncompleteTodoTasksQuery, GetIncompleteTodoTasksQueryResult> _getIncompleteTodoTasksQuery;

        public TodoTaskController(ICommandHandler<CreateTodoTaskCommand, string> createTodoTaskCommand,
                                  IQueryHandler<GetTodoTaskByIdQuery, GetTodoTaskByIdQueryResult> getTodoTaskByIdQuery,
                                  IQueryHandler<GetTodoTasksQuery, GetTodoTasksQueryResult> getTodoTasksQuery,
                                  IQueryHandler<GetIncompleteTodoTasksQuery, GetIncompleteTodoTasksQueryResult> getIncompleteTodoTasksQuery,
                                  ICommandHandler<AddTagCommand, bool> addTagCommand,
                                  ICommandHandler<DeleteTodoTaskCommand> deleteTodoTaskCommand)
        {
            _createTodoTaskCommand = createTodoTaskCommand;
            _getTodoTaskByIdQuery = getTodoTaskByIdQuery;
            _getTodoTasksQuery = getTodoTasksQuery;
            _getIncompleteTodoTasksQuery = getIncompleteTodoTasksQuery;
            _addTagCommand = addTagCommand;
            _deleteTodoTaskCommand = deleteTodoTaskCommand;
        }


        // GET: api/<TodoTaskController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var todoTasks = await _getTodoTasksQuery.ExecuteAsync(new());
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
                var todoTask = await _getTodoTaskByIdQuery.ExecuteAsync(new GetTodoTaskByIdQuery() 
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

        // GET api/<TodoTaskController>/incomplete
        [HttpGet("incomplete")]
        public async Task<IActionResult> GetIncompletedAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var incompleteTodoTasks = await _getIncompleteTodoTasksQuery.ExecuteAsync(new GetIncompleteTodoTasksQuery(), cancellationToken);
                return Ok(incompleteTodoTasks);
            }
            catch (Exception e)
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
                var taskId = await _createTodoTaskCommand.HandleAsync(command, default);
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
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _deleteTodoTaskCommand.HandleAsync(new DeleteTodoTaskCommand() { TodoTaskId = id });
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
                throw;
            }
        }

        [HttpPost("{id}/Tag")]
        public async Task<IActionResult> AddTagAsync([FromRoute] string id, [FromBody] string name)
        {
            try
            {
                var result = await _addTagCommand.HandleAsync(new()
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
