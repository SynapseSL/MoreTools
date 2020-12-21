using Synapse.Command;

namespace MoreTools.Commands
{
    [CommandInformation(
        Name = "Redirect",
        Aliases = new string[] { "rd" },
        Description = "Forces the player to join on a other Server on the same machine with a different port",
        Permission = "moretools.redirect",
        Platforms = new Platform[] { Platform.RemoteAdmin, Platform.ServerConsole },
        Usage = "Redirect players port"
        )]
    public class Redirect : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            if (context.Arguments.Count < 2)
                return new CommandResult
                {
                    Message = "Missing Parameter. Usage: Redirect players port",
                    State = CommandResultState.Error
                };

            if (!Extensions.TryGetPlayers(context.Arguments.At(0), context.Player, out var players))
                return new CommandResult
                {
                    Message = "No Player was found",
                    State = CommandResultState.Error
                };

            if (!ushort.TryParse(context.Arguments.At(1), out var port))
                return new CommandResult
                {
                    Message = "Invalid Port",
                    State = CommandResultState.Error
                };

            foreach (var player in players)
                player.SendToServer(port);

            return new CommandResult
            {
                Message = "Players was redirected to the other Server",
                State = CommandResultState.Ok
            };
        }
    }
}
