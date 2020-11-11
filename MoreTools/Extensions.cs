using Synapse;
using Synapse.Api;
using System.Collections.Generic;

namespace MoreTools
{
    public static class Extensions
    {
        public static bool TryGetPlayers(string arg, Player sender, out List<Player> playerList)
        {
            var players = new List<Player>();
            var args = arg.Split('.');

            foreach (var parameter in args)
            {
                if (string.IsNullOrEmpty(parameter)) continue;
                if (string.IsNullOrWhiteSpace(parameter)) continue;

                switch (parameter.ToUpper())
                {
                    case "ME":
                        if (!players.Contains(sender))
                            players.Add(sender);
                        continue;

                    case "ADMIN":
                    case "STAFF":
                        foreach (var player in Server.Get.Players)
                            if (player.ServerRoles.RemoteAdmin)
                                if (!players.Contains(player))
                                    players.Add(player);
                        continue;

                    case "*":
                    case "ALL":
                        foreach (var player2 in Server.Get.Players)
                            if (!players.Contains(player2))
                                players.Add(player2);
                        continue;

                    default:
                        var player3 = Server.Get.GetPlayer(parameter);
                        if (player3 == null) continue;
                        if (!players.Contains(player3))
                            players.Add(player3);
                        continue;
                }
            }

            playerList = players;

            return players.Count != 0;
        }
    }
}
