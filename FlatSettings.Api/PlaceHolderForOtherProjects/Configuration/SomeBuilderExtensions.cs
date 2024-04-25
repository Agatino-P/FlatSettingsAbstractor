using FlatSettings.Api.PlaceHolderForOtherProjects.Ports;
using FlatSettings.Api.PlaceHolderForOtherProjects.Services;

namespace FlatSettings.Api.PlaceHolderForOtherProjects.Configuration;

public static class SomeBuilderExtensions
{
    public static WebApplicationBuilder AddSomeService(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton(VSettings.Create(builder.Configuration));
        builder.Services.AddScoped<ISomeServiceUsingVSettings, SomeServiceUsingVSettings>();

        return builder;
    }
}
