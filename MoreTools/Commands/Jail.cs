using Synapse.Api;
using Synapse.Command;
using System.Linq;
using System;

namespace MoreTools.Commands
{
    [CommandInformation(
        Name = "Jail",
        Aliases = new string[] { },
        Description = "A Command for jailing Players",
        Permission = "moretools.jail",
        Platforms = new Platform[] { Platform.RemoteAdmin, Platform.ServerConsole },
        Usage = "jail players"
        )]
    public class Jail : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            var result = new CommandResult();

            if (!context.Player.HasPermission("moretools.jail"))
            {
                result.Message = "You dont have Permission to execute this Command (moretools.jail)";
                result.State = CommandResultState.NoPermission;
                return result;
            }

            if(context.Arguments.Count < 1)
            {
                result.Message = "Missing Parameter! Usage: Jail players";
                result.State = CommandResultState.Error;
                return result;
            }

            if(!Extensions.TryGetPlayers(context.Arguments.First(),context.Player,out var players))
            {
                result.Message = "No Player was found!";
                result.State = CommandResultState.Error;
                return result;
            }

            foreach (var player in players)
                player.Jail.JailPlayer(context.Player);
                

            result.Message = "Players are jailed";
            result.State = CommandResultState.Ok;
            return result;
        }
    }
}
