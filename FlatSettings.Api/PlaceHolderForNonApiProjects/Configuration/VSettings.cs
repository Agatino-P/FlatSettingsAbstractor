using FlatSettings.Api.PlaceHolderForNonApiProjects.BaseSettings;

namespace FlatSettings.Api.PlaceHolderForNonApiProjects.Configuration;

public record VSettings(string V1, string V2, string V3) : SettingsRecordBase
{
    protected override string PrefixKey => "VSetting.Prefix";

    //The code here below is provided as an example of two options
    //
    //Reflection version might be handy if there are no sublevels
    //  most likely not practical for non trivial scanarios
    //  Anyhow it was fun to write it :-)
    private readonly bool useReflection = false;
    
    public VSettings(IConfiguration configuration) : this("", "", "")
    {
        if (useReflection)
        {
            PopulateWithReflection(configuration);
        }

        if (!useReflection)
        {
            string? prefix = configuration[PrefixKey] ?? "";
            V1 = configuration[$"{prefix}V1"]!;
            V2 = configuration[$"{prefix}V2"]!;
            V3 = configuration[$"{prefix}V2"]!;
        }
    }
}
