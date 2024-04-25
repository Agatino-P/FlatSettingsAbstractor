using FlatSettings.Api.PlaceHolderForOtherProjects.Configuration;
using FlatSettings.Api.PlaceHolderForOtherProjects.Ports;
using Microsoft.AspNetCore.Mvc;

namespace FlatSettings.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class SettingsController : ControllerBase
{
    private readonly ISomeServiceUsingVSettings serviceUsingVSettings;
    private readonly ILogger<SettingsController> _logger;

    public SettingsController(ISomeServiceUsingVSettings serviceUsingVSettings, ILogger<SettingsController> logger)
    {
        this.serviceUsingVSettings = serviceUsingVSettings;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetSettings()
    {
        return Ok(serviceUsingVSettings.MakeSomethingWithSettings());
    }
}
