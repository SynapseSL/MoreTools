using Synapse3.SynapseModule;
using Synapse3.SynapseModule.Command;
using Synapse3.SynapseModule.Player;

namespace MoreTools.Commands;

//This is just to prevent code repetition since PlayerService is used a lot
public abstract class PlayerCommand : SynapseCommand
{
    protected PlayerService PlayerService { get; }

    protected PlayerCommand()
    {
        PlayerService = Synapse.Get<PlayerService>();
    }
}