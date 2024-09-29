using Microsoft.AspNetCore.Mvc;
using TaskManager.Domain.TodoTasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManager.Apps.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodoTaskController : ControllerBase
    {
        private readonly ITodoTaskRepository _todoTaskRepository;

        public TodoTaskController(ITodoTaskRepository todoTaskRepository)
        {
            _todoTaskRepository = todoTaskRepository;
        }


        // GET: api/<TodoTaskController>
        [HttpGet]
        public async Task<IEnumerable<TodoTask>> GetAsync()
        {
            return await _todoTaskRepository.GetAllAsync();
        }

        // GET api/<TodoTaskController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TodoTaskController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TodoTaskController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TodoTaskController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
