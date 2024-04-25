
using System.Collections.Generic;
using System.Reflection;

namespace FlatSettings.Api.PlaceHolderForOtherProjects.Configuration;

public record VSettings(string V1, string V2, string V3)
{
    private const string prefixKey = "VSetting.Prefix";

    public static VSettings Create(IConfiguration configuration)
    {

        string? prefix = configuration[prefixKey] ?? "";
        PropertyInfo[] properties = typeof(VSettings).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        VSettings vSettings = new("", "", "");

        foreach (PropertyInfo p in properties)
        {
            // Only work with strings, can be changed as needed
            if (p.PropertyType != typeof(string)) { continue; }

            // If not writable then cannot null it; if not readable then cannot check it's value
            if (!p.CanWrite || !p.CanRead) { continue; }

            // Get and set methods have to be public. Should probably check more deep, but it's just a demo
            if (p.GetGetMethod(false) == null) { continue; }
            if (p.GetSetMethod(false) == null) { continue; }

            p.SetValue(vSettings, configuration[$"{prefix}{p.Name}"]);
        }

        return vSettings;
    }
}