using Synapse.Command;
using System.Linq;

namespace MoreTools.Commands
{
    [CommandInformation(
        Name = "Jail",
        Aliases = new string[] { },
        Description = "A Command for jailing Players",
        Permission = "moretools.jail",
        Platforms = new Platform[] { Platform.RemoteAdmin, Platform.ServerConsole },
        Usage = "jail players",
        Arguments = new[] { "Players" }
        )]
    public class Jail : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            if (context.Arguments.Count < 1)
                return new CommandResult
                {
                    Message = "Missing Parameter! Usage: Jail players",
                    State = CommandResultState.Error
                };

            if (!Extensions.TryGetPlayers(context.Arguments.First(), context.Player, out var players))
                return new CommandResult
                {
                    Message = "No Player was found!",
                    State = CommandResultState.Error
                };

            foreach (var player in players)
                player.Jail.JailPlayer(context.Player);

            return new CommandResult
            {
                Message = "Players are jailed",
                State = CommandResultState.Ok
            };
        }
    }
}
