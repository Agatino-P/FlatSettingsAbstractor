using System.Reflection;

namespace FlatSettings.Api.PlaceHolderForNonApiProjects.BaseSettings;

public abstract record SettingsRecordBase()
{
    protected virtual string PrefixKey => "base.Prefix";

    protected void PopulateWithReflection(IConfiguration configuration)
    {
        string? prefix = configuration[PrefixKey] ?? "";

        PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (PropertyInfo p in properties)
        {
            // Only work with strings, can be changed as needed
            if (p.PropertyType != typeof(string)) { continue; }

            // If not writable then cannot null it; if not readable then cannot check it's value
            if (!p.CanWrite || !p.CanRead) { continue; }

            // Get and set methods have to be public. Should probably check more deep, but it's just a demo
            if (p.GetGetMethod(false) == null) { continue; }
            if (p.GetSetMethod(false) == null) { continue; }

            p.SetValue(this, configuration[$"{prefix}{p.Name}"]);
        }

    }


}
