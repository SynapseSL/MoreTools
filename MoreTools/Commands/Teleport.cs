using Synapse.Command;

namespace MoreTools.Commands
{
    [CommandInformation(
        Name = "Teleport",
        Aliases = new string[] { "tp" },
        Description = "brings players to a specific player",
        Permission = "moretools.tp",
        Platforms = new Platform[] { Platform.RemoteAdmin, Platform.ServerConsole },
        Usage = "tp players player"
        )]
    public class Teleport : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            var result = new CommandResult();

            if (!context.Player.HasPermission("moretools.tp"))
            {
                result.Message = "You dont have Permission to execute this Command (moretools.tp)";
                result.State = CommandResultState.NoPermission;
                return result;
            }

            if (context.Arguments.Count < 2)
            {
                result.Message = "Missing Parameters! Usage: tp players player";
                result.State = CommandResultState.Error;
                return result;
            }

            if (!Extensions.TryGetPlayers(context.Arguments.FirstElement(), context.Player, out var players))
            {
                result.Message = "No Player was found";
                result.State = CommandResultState.Error;
                return result;
            }

            var player = SynapseController.Server.GetPlayer(context.Arguments.At(1));
            if(player == null)
            {
                result.Message = "No player to tp to was found";
                result.State = CommandResultState.Error;
                return result;
            }

            foreach (var ply in players)
                ply.Position = player.Position;

            result.Message = "All players have been brought to the player";
            result.State = CommandResultState.Ok;
            return result;
        }
    }
}
