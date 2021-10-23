using System.Collections.Generic;
using Synapse.Api;

namespace MoreTools
{
    public static class Extensions
    {
        //This was moved into the Synapse API and Im to lazy to change all the references
        public static bool TryGetPlayers(string arg, Player sender, out List<Player> playerList) => SynapseController.Server.TryGetPlayers(arg, out playerList, sender);
    }
}
