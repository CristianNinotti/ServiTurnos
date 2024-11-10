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
    [Authorize(Policy = "CustomerOrProfessionalOrSuperAdmin")]
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
    [Authorize(Policy = "CustomerOrProfessionalOrSuperAdmin")]
    public ActionResult<ProfessionalResponse?> GetProfessionalById([FromRoute] int id)
    {
        var response = _professionalService.GetProfessionalById(id);

        if (response is null)
        {
            return NotFound("Professional not found");
        }

        return Ok(response);
    }

    [HttpGet("profession/{professionId}")]
    [Authorize(Policy = "CustomerOrProfessionalOrSuperAdmin")]
    public IActionResult GetProfessionalByProfession(int professionId)
    {
        // Convierte el ID numérico al enum Profession
        if (!Enum.IsDefined(typeof(Profession), professionId))
        {
            return BadRequest("El valor de profesión no es válido.");
        }

        var profession = (Profession)professionId;
        Console.WriteLine("Profesión recibida en el backend: " + profession); // Verificar el valor recibido

        var result = _professionalService.GetProfessionalByProfession(profession);
        return Ok(result);
    }

    [HttpPost]
    public IActionResult CreateProfessional([FromBody] ProfessionalRequest professional)
    {
        _professionalService.CreateProfessional(professional);
        return Ok("Profesional creado con éxito");
    }

    [HttpPut("{id}")]
    [Authorize(Policy = "ProfessionalOrSuperAdmin")]
    public ActionResult<bool> UpdateProfessional([FromRoute] int id, [FromBody] ProfessionalRequest professional)
    {
        return Ok(_professionalService.UpdateProfessional(id, professional));
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = "ProfessionalOrSuperAdmin")]
    public ActionResult<bool> DeleteProfessional([FromRoute] int id)
    {
        return Ok(_professionalService.DeleteProfessional(id));
    }
}