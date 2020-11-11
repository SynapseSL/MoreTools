using Synapse.Api.Plugin;

namespace MoreTools
{
    [PluginInformation(
        Name = "MoreTools",
        Author = "Dimenzio",
        Description = "A Plugin which adds a ton off Tools for Admins to the game",
        LoadPriority = int.MinValue,
        SynapseMajor = SynapseController.SynapseMajor,
        SynapseMinor = SynapseController.SynapseMinor,
        SynapsePatch = SynapseController.SynapsePatch,
        Version = "v.1.0.0"
        )]
    public class PluginClass : AbstractPlugin { }
}
