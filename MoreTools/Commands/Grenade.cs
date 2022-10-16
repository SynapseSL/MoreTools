using Neuron.Core.Meta;
using Neuron.Modules.Commands;
using Neuron.Modules.Commands.Command;
using Synapse3.SynapseModule.Command;
using Synapse3.SynapseModule.Item;

namespace MoreTools.Commands;

[Automatic]
[SynapseRaCommand(
    CommandName = "Grenade",
    Aliases = new[] { "gn" },
    Description = "Spawns grenades at the player location",
    Permission = "moretools.grenade",
    Platforms = new[] { CommandPlatform.RemoteAdmin, CommandPlatform.ServerConsole },
    Parameters = new[] { "Players", "(Amount)" }
)]
public class Grenade : PlayerCommand
{
    public override void Execute(SynapseContext context, ref CommandResult result)
    {
        if (context.Arguments.Length < 1)
        {
            result.Response = "Usage: grenade players (optional amount)";
            result.StatusCode = CommandStatusCode.Error;
            return;
        }

        if (context.Arguments.Length < 2)
            context.Arguments = new[] { context.Arguments[0], "1" };

        if (!PlayerService.TryGetPlayers(context.Arguments[0], out var players, context.Player))
        {
            result.Response = "No Player was found";
            result.StatusCode = CommandStatusCode.NotFound;
            return;
        }

        if (!int.TryParse(context.Arguments[1], out var amount))
        {
            result.Response = "Invalid Amount";
            return;
        }

        foreach (var player in players)
            for (int i = 0; i < amount; i++)
            {
                var item = new SynapseItem(ItemType.GrenadeHE, player.Position);
                item.Throwable.Fuse(player);
            }

        result.Response = "Grenade was spawned";
    }
}
