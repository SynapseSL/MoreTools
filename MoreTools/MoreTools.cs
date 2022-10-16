using Neuron.Core.Plugins;
using Synapse3.SynapseModule;
using Synapse3.SynapseModule.Events;

namespace MoreTools;

[Plugin(
    Author = "Dimenzio",
    Description = "Adds various Admin Commands",
    Name = "MoreTools",
    Version = "3.0.0"
)]
public class MoreTools : ReloadablePlugin
{
    public MoreToolsConfig Config { get; private set; }

    public override void EnablePlugin()
    {
        Logger.Info("MoreTools loaded");
    }

    public override void Reload(ReloadEvent _ = null)
    {
        Config = Synapse.Get<MoreToolsConfig>();
    }
}
