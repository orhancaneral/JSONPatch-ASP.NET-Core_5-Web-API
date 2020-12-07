using JsonPatchWebApi.Models;
using JsonPatchWebApi.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JsonPatchWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IDataService _dataService;

        public EmployeeController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_dataService.GetPeople());

        [HttpGet("{id}")]
        public IActionResult GetBy(Guid id) => Ok(_dataService.GetBy(id));

        [HttpPatch("update/{id}")]
        public IActionResult Patch(Guid id, [FromBody] JsonPatchDocument<Person> personPatch)
        {
            if (personPatch != null)
            {
                var person = _dataService.GetBy(id);

                if (person != null)
                {
                    personPatch.ApplyTo(person);
                    return Ok(person);
                }
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult Add(Person person) => Ok(_dataService.Add(person));
    }
}