﻿using Synapse.Command;
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
            var result = new CommandResult();

            if (!context.Player.HasPermission("moretools.invisible"))
            {
                result.Message = "You dont have Permission to execute this Command (moretools.invisble)";
                result.State = CommandResultState.NoPermission;
                return result;
            }

            if (context.Arguments.Count < 1)
            {
                result.Message = "Missing Parameter! Usage: show players";
                result.State = CommandResultState.Error;
                return result;
            }

            if (!Extensions.TryGetPlayers(context.Arguments.First(), context.Player, out var players))
            {
                result.Message = "No Player was found";
                result.State = CommandResultState.Error;
                return result;
            }

            foreach (var player in players)
                player.Invisible = true;

            result.Message = "The Players are now Visible again";
            result.State = CommandResultState.Ok;
            return result;
        }
    }
}