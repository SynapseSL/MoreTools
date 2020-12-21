using Synapse.Command;
using System.Linq;

namespace MoreTools.Commands
{
    [CommandInformation(
        Name = "Show",
        Aliases = new string[] { },
        Description = "A Command to make Players Visible again",
        Permission = "moretools.invisible",
        Platforms = new Platform[] { Platform.RemoteAdmin, Platform.ServerConsole },
        Usage = "show players"
        )]
    public class Show : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            if (context.Arguments.Count < 1)
                return new CommandResult
                {
                    Message = "Missing Parameter! Usage: show players",
                    State = CommandResultState.Error
                };

            if (!Extensions.TryGetPlayers(context.Arguments.First(), context.Player, out var players))
                return new CommandResult
                {
                    Message = "No Player was found",
                    State = CommandResultState.Error
                };

            foreach (var player in players)
                player.Invisible = true;

            return new CommandResult
            {
                Message = "The Players are now Visible again",
                State = CommandResultState.Ok
            };
        }
    }
}
