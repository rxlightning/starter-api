using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientController
{
    private readonly IPatientService _patientService;
    private readonly ILoginService _loginService;

    public PatientController(IPatientService patientService, ILoginService loginService)
    {
        _patientService = patientService;
        _loginService = loginService;
    }
    
    [ProducesResponseType(200)]
    [HttpGet("{patientId}")]
    public IActionResult GetPatient([FromHeader]string authorization, string patientId)
    {
        if (_loginService.IsValidToken(authorization))
        {
            var patient = _patientService.GetPatient(patientId);
            return new OkObjectResult(patient);
        }

        return new UnauthorizedResult();
    }
    
    [ProducesResponseType(200)]
    [HttpGet("List")]
    public IActionResult GetPatientList([FromHeader]string authorization)
    {
        if (_loginService.IsValidToken(authorization))
        {
            var patients = _patientService.GetPatientList();
            return new OkObjectResult(patients);
        }
        return new UnauthorizedResult();
    }
}