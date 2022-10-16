using System.Collections.Generic;
using Neuron.Core.Meta;
using Syml;
using Synapse3.SynapseModule.Config;
using Synapse3.SynapseModule.Map.Rooms;
using UnityEngine;

namespace MoreTools;

[Automatic]
[DocumentSection("MoreTools")]
public class MoreToolsConfig : IDocumentSection
{
    public List<SerializedPlayerState> JailStates { get; set; } = new()
    {
        new SerializedPlayerState()
        {
            Position = new RoomPoint("Surface", new Vector3(53.68f, 19.42f, -44.23f), Vector3.zero),
            RoleType = RoleType.Tutorial,
            RoleID = (uint)RoleType.Tutorial
        }
    };
}