using Application.Interfaces;
using Domain.Enum;
using Application.Models.Request;
using Application.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Services;

namespace Web.Controllers;

[Route("api/professional")]
[ApiController]
public class ProfessionalController : ControllerBase
{
    private readonly IProfessionalService _professionalService;

    public ProfessionalController(IProfessionalService professionalService)
    {
        _professionalService = professionalService;
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetAllProfessional()
    {
        var response = _professionalService.GetAllProfessional();

        if (response.Count is 0)
        {
            return NotFound("Professional not found");
        }

        return Ok(response);
    }

    [HttpGet("{id}")]
    public ActionResult<ProfessionalResponse?> GetProfessionalById([FromRoute] int id)
    {
        var response = _professionalService.GetProfessionalById(id);

        if (response is null)
        {
            return NotFound("Professional not found");
        }

        return Ok(response);
    }

    [HttpGet("profession")]
    public IActionResult GetProfessionalByProfession(Profession profession)
    {
        return Ok(_professionalService.GetProfessionalByProfession(profession));
    }

    [HttpPost]
    public IActionResult CreateProfessional([FromBody] ProfessionalRequest professional)
    {
        _professionalService.CreateProfessional(professional);
        return Ok();
    }

    [HttpPut("{id}")]
    public ActionResult<bool> UpdateProfessional([FromRoute] int id, [FromBody] ProfessionalRequest professional)
    {
        return Ok(_professionalService.UpdateProfessional(id, professional));
    }

    [HttpDelete("{id}")]
    public ActionResult<bool> DeleteProfessional([FromRoute] int id)
    {
        return Ok(_professionalService.DeleteProfessional(id));
    }
}