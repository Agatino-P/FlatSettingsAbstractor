using FlatSettings.Api.PlaceHolderForNonApiProjects.Configuration;
using FlatSettings.Api.PlaceHolderForNonApiProjects.Ports;

namespace FlatSettings.Api.PlaceHolderForNonApiProjects.Services;

public class SomeServiceUsingVSettings : ISomeServiceUsingVSettings
{
    private readonly VSettings vSettings;

    public SomeServiceUsingVSettings(VSettings vSettings)
    {

        this.vSettings = vSettings;
    }
    public string MakeSomethingWithSettings() => $"This are my settings, in reverse order {vSettings.V3}, {vSettings.V2}, {vSettings.V1}";
}
