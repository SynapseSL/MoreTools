using Synapse.Command;

namespace MoreTools.Commands
{
    [CommandInformation(
        Name = "Teleport",
        Aliases = new string[] { "tp" },
        Description = "brings players to a specific player",
        Permission = "moretools.tp",
        Platforms = new Platform[] { Platform.RemoteAdmin, Platform.ServerConsole },
        Usage = "tp players player",
        Arguments = new[] { "Players", "Player" }
        )]
    public class Teleport : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            if (context.Arguments.Count < 2)
                return new CommandResult
                {
                    Message = "Missing Parameters! Usage: tp players player",
                    State = CommandResultState.Error
                };

            if (!Extensions.TryGetPlayers(context.Arguments.FirstElement(), context.Player, out var players))
                return new CommandResult
                {
                    Message = "No Player was found",
                    State = CommandResultState.Error
                };

            var player = SynapseController.Server.GetPlayer(context.Arguments.At(1));
            if (player == null)
                return new CommandResult
                {
                    Message = "No player to tp to was found",
                    State = CommandResultState.Error
                };

            foreach (var ply in players)
                ply.Position = player.Position;

            return new CommandResult
            {
                Message = "All players have been tp't to the player",
                State = CommandResultState.Ok
            };
        }
    }
}
