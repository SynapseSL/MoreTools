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
        Usage = "size players x y z"
        )]
    public class Size : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            var result = new CommandResult();

            if (!context.Player.HasPermission("moretools.size"))
            {
                result.Message = "You dont have Permission to execute this Command (moretools.size)";
                result.State = CommandResultState.NoPermission;
                return result;
            }

            if (context.Arguments.Count < 4)
            {
                result.Message = "Missing Parameters! size players x y z";
                result.State = CommandResultState.NoPermission;
                return result;
            }

            if(!Extensions.TryGetPlayers(context.Arguments.First(),context.Player,out var players))
            {
                result.Message = "No Player was found";
                result.State = CommandResultState.Error;
                return result;
            }

            if(!float.TryParse(context.Arguments.ElementAt(1),out var x))
            {
                result.Message = "Invalid parameter for x";
                result.State = CommandResultState.Error;
                return result;
            }

            if (!float.TryParse(context.Arguments.ElementAt(2), out var y))
            {
                result.Message = "Invalid parameter for y";
                result.State = CommandResultState.Error;
                return result;
            }

            if (!float.TryParse(context.Arguments.ElementAt(3), out var z))
            {
                result.Message = "Invalid parameter for z";
                result.State = CommandResultState.Error;
                return result;
            }

            foreach (var player in players)
                player.Scale = new UnityEngine.Vector3(x, y, z);

            result.Message = "The Size off all Players was changed";
            result.State = CommandResultState.Ok;
            return result;
        }
    }
}
