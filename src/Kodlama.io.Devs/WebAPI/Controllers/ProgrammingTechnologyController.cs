using Application.Features.ProgrammingLanguages.Command.ProgrammingTechnologies.CreateProgrammingTechnology;
using Application.Features.ProgrammingTechnologies.Command.DeleteProgrammingTechnology;
using Application.Features.ProgrammingTechnologies.Command.UpdateProgrammingTechnology;
using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Features.ProgrammingTechnologies.Models;
using Application.Features.ProgrammingTechnologies.Queries.GetListProgrammingTechnologyQuery;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingTechnologyController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingTechnologyCommand createProgrammingTechnologyCommand)
        {
            CreateProgrammingTechnologyDto result = await Mediator.Send(createProgrammingTechnologyCommand);
            return Created("", result);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingTechnologyCommand updateProgrammingTechnologyCommand)
        {
            UpdateProgrammingTechnologyDto result = await Mediator.Send(updateProgrammingTechnologyCommand);
            return Created("", result);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProgrammingTechnologyCommand deleteProgrammingTechnologyCommand)
        {
            DeleteProgrammingTechnologyDto result = await Mediator.Send(deleteProgrammingTechnologyCommand);
            return Ok("Silindi");
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery]PageRequest pageRequest)
        {
            GetListProgrammingTechnologyQuery getListProgrammingTechnologyQuery = new() { PageRequest = pageRequest };
            ProgrammingTechnologyListModel result = await Mediator.Send(getListProgrammingTechnologyQuery);
            return Ok(result);
        }
    }
}
