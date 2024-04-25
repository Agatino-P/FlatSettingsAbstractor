using FlatSettings.Api.PlaceHolderForNonApiProjects.Ports;
using FlatSettings.Api.PlaceHolderForNonApiProjects.Services;

namespace FlatSettings.Api.PlaceHolderForNonApiProjects.Configuration;

public static class SomeBuilderExtensions
{
    public static WebApplicationBuilder AddSomeService(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton(new VSettings(builder.Configuration));
        builder.Services.AddScoped<ISomeServiceUsingVSettings, SomeServiceUsingVSettings>();

        return builder;
    }
}
