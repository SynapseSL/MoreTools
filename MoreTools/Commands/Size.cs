using Synapse.Api;
using Synapse.Command;
using System.Linq;

namespace MoreTools.Commands
{
    [CommandInformation(
        Name = "Size",
        Aliases = new string[] { "Scale" },
        Description = "A Command to change the size of Players",
        Permission = "moretools.size",
        Platforms = new Platform[] { Platform.RemoteAdmin, Platform.ServerConsole },
        Usage = "size players x y z",
        Arguments = new[] { "Players", "X Size", "Y Size", "Z Size"}
        )]
    public class Size : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            if (context.Arguments.Count < 4)
                return new CommandResult
                {
                    Message = "Missing Parameters! size players x y z",
                    State = CommandResultState.Error
                };

            if (!Extensions.TryGetPlayers(context.Arguments.First(), context.Player, out var players))
                return new CommandResult
                {
                    Message = "No Player was found",
                    State = CommandResultState.Error
                };

            if (!float.TryParse(context.Arguments.ElementAt(1), out var x))
                return new CommandResult
                {
                    Message = "Invalid parameter for x",
                    State = CommandResultState.Error
                };

            if (!float.TryParse(context.Arguments.ElementAt(2), out var y))
                return new CommandResult
                {
                    Message = "Invalid parameter for y",
                    State = CommandResultState.Error
                };

            if (!float.TryParse(context.Arguments.ElementAt(3), out var z))
                return new CommandResult
                {
                    Message = "Invalid parameter for z",
                    State = CommandResultState.Error
                };

            foreach (var player in players)
                player.Scale = new UnityEngine.Vector3(x, y, z);

            return new CommandResult
            {
                Message = "The Size of all Players was changed",
                State = CommandResultState.Ok
            };
        }
    }
}
