using Synapse.Command;

namespace MoreTools.Commands
{
    [CommandInformation(
        Name = "Window",
        Aliases = new string[] { "reportwindow" },
        Description = "Opens the Report Window with a a Custom Message",
        Permission = "moretools.window",
        Platforms = new Platform[] { Platform.RemoteAdmin, Platform.ServerConsole },
        Usage = "Window players Message"
        )]
    public class Window : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            if (context.Arguments.Count < 2)
                return new CommandResult
                {
                    Message = "Missing Parameter. Usage: Window players Message",
                    State = CommandResultState.Error
                };

            if (!Extensions.TryGetPlayers(context.Arguments.At(0), context.Player, out var players))
                return new CommandResult
                {
                    Message = "No Player was found",
                    State = CommandResultState.Error
                };

            var message = string.Join(" ", context.Arguments.Segment(1));

            foreach (var player in players)
                player.OpenReportWindow(message);

            return new CommandResult
            {
                Message = "Message was send",
                State = CommandResultState.Ok
            };
        }
    }
}
