using Synapse.Command;

namespace MoreTools.Commands
{
    [CommandInformation(
        Name = "Hint",
        Aliases = new string[] { "HintDisplay","hd" },
        Description = "A Command to give all Players a Hint Message",
        Permission = "moretools.hint",
        Platforms = new Platform[] { Platform.RemoteAdmin, Platform.ServerConsole },
        Usage = "hint time message"
        )]
    public class Hint : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            if (context.Arguments.Count < 2)
                return new CommandResult
                {
                    Message = "Missing Parameter! Usage: hint time message",
                    State = CommandResultState.Error
                };

            if (!float.TryParse(context.Arguments.FirstElement(), out var time))
                return new CommandResult
                {
                    Message = "Invalid parameter for time",
                    State = CommandResultState.Error
                };

            var msg = string.Join(" ", context.Arguments.Segment(1));
            foreach (var ply in Synapse.Server.Get.Players)
                ply.GiveTextHint(msg, time);

            return new CommandResult
            {
                Message = "Hint was send",
                State = CommandResultState.Ok
            };
        }
    }
}
