using System.Security.Cryptography.X509Certificates;
using FlatSettings.Api.PlaceHolderForOtherProjects.Configuration;
using FlatSettings.Api.PlaceHolderForOtherProjects.Ports;

namespace FlatSettings.Api.PlaceHolderForOtherProjects.Services;

public class SomeServiceUsingVSettings : ISomeServiceUsingVSettings
{
    private readonly VSettings vSettings;

    public SomeServiceUsingVSettings(VSettings vSettings)
    {

        this.vSettings = vSettings;
    }
    public string MakeSomethingWithSettings() => $"This are my settings, in reverse order {vSettings.V3}, {vSettings.V2}, {vSettings.V1}";
}
