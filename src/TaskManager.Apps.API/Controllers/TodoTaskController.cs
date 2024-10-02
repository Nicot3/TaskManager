using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Common.Contracts.Commands;
using TaskManager.Application.Common.Contracts.Queries;
using TaskManager.Application.TodoTasks.Commands.CreateTodoTask;
using TaskManager.Application.TodoTasks.Queries.GetTodoTaskById;
using TaskManager.Domain.TodoTasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManager.Apps.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodoTaskController : ControllerBase
    {
        private readonly ICommandHandler<CreateTodoTaskCommand, string> _createTodoTaskCommandHandler;
        private readonly IQueryHandler<GetTodoTaskByIdQuery, GetTodoTaskByIdQueryResult> _getTodoTaskByIdQueryResult;

        public TodoTaskController(ICommandHandler<CreateTodoTaskCommand, string> createTodoTaskCommandHandler,
                                  IQueryHandler<GetTodoTaskByIdQuery, GetTodoTaskByIdQueryResult> getTodoTaskByIdQueryResult)
        {
            _createTodoTaskCommandHandler = createTodoTaskCommandHandler;
            _getTodoTaskByIdQueryResult = getTodoTaskByIdQueryResult;
        }


        // GET: api/<TodoTaskController>
        [HttpGet]
        public async Task<IEnumerable<TodoTask>> GetAsync()
        {
            throw new NotImplementedException();
        }

        // GET api/<TodoTaskController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            try
            {
                var todoTask = await _getTodoTaskByIdQueryResult.ExecuteAsync(new GetTodoTaskByIdQuery() 
                { 
                    Id = id
                });

                return Ok(todoTask);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<TodoTaskController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTodoTaskCommand command)
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
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<TodoTaskController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
