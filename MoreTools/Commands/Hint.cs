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
            var result = new CommandResult();

            if (!context.Player.HasPermission("moretools.hint"))
            {
                result.Message = "You dont have Permission to execute this Command (moretools.hint)";
                result.State = CommandResultState.NoPermission;
                return result;
            }

            if (context.Arguments.Count < 2)
            {
                result.Message = "Missing Parameter! Usage: hint time message";
                result.State = CommandResultState.Error;
                return result;
            }

            if (!float.TryParse(context.Arguments.FirstElement(), out var time))
            {
                result.Message = "Invalid parameter for time";
                result.State = CommandResultState.Error;
                return result;
            }

            var msg = string.Join(" ", context.Arguments.Segment(1));
            foreach (var ply in Synapse.Server.Get.Players)
                ply.GiveTextHint(msg, time);
            result.Message = "Hint was send";
            result.State = CommandResultState.Ok;

            return result;
        }
    }
}
