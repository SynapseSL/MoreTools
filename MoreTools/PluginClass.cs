using Synapse.Api.Plugin;

namespace MoreTools
{
    [PluginInformation(
        Name = "MoreTools",
        Author = "Dimenzio",
        Description = "A Plugin which adds a ton of Tools and command to the game",
        LoadPriority = int.MinValue,
        SynapseMajor = 2,
        SynapseMinor = 0,
        SynapsePatch = 1,
        Version = "v.1.0.0"
        )]
    public class PluginClass : AbstractPlugin { }
}
