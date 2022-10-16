using Neuron.Modules.Commands;
using Neuron.Modules.Commands.Command;
using Synapse3.SynapseModule.Command;

namespace MoreTools.Commands
{
    [SynapseRaCommand(
        CommandName = "Teleport",
        Aliases = new[] { "tp" },
        Description = "brings players to a specific player",
        Permission = "moretools.tp",
        Platforms = new [] { CommandPlatform.RemoteAdmin,CommandPlatform.ServerConsole },
        Parameters = new[] { "Players", "Player" }
        )]
    public class Teleport : PlayerCommand
    {
        public override void Execute(SynapseContext context, ref CommandResult result)
        {
            if (context.Arguments.Length < 2)
            {
                result.Response = "Missing Parameters! Usage: tp players player";
                result.StatusCode = CommandStatusCode.BadSyntax;
                return;
            }

            if (!PlayerService.TryGetPlayers(context.Arguments[0], out var players, context.Player))
            {
                result.Response = "No Player was found";
                result.StatusCode = CommandStatusCode.NotFound;
                return;
            }

            var player = PlayerService.GetPlayer(context.Arguments[1]);
            if (player == null)
            {
                result.Response = "No player to tp to was found";
                result.StatusCode = CommandStatusCode.NotFound;
                return;
            }

            foreach (var ply in players)
                ply.Position = player.Position;

            result.Response = "All players have been teleported to the player";
        }
    }
}
