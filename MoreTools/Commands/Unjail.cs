using Synapse.Command;
using System.Linq;

namespace MoreTools.Commands
{
    [CommandInformation(
        Name = "UnJail",
        Aliases = new string[] { },
        Description = "A Command for unjailing Players",
        Permission = "moretools.jail",
        Platforms = new Platform[] { Platform.RemoteAdmin, Platform.ServerConsole },
        Usage = "unjail players",
        Arguments = new[] { "Players" }
        )]
    public class UnJail : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            if (context.Arguments.Count < 1)
                return new CommandResult
                {
                    Message = "Missing Parameter! Usage: Unjail players",
                    State = CommandResultState.Error
                };

            if (!Extensions.TryGetPlayers(context.Arguments.First(), context.Player, out var players))
                return new CommandResult
                {
                    Message = "No Player was found!",
                    State = CommandResultState.Error
                };

            foreach (var player in players)
                player.Jail.UnJailPlayer();

            return new CommandResult
            {
                Message = "Players are unjailed",
                State = CommandResultState.Ok
            };
        }
    }
}
