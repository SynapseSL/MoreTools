﻿using Synapse.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreTools
{
    public class PluginConfig : AbstractConfigSection
    {

        public bool allowExplosive207 = true;

        [Description("How many SCP-207 will be needed to explode?")]
        public int scp207ExplosionAmount = 5;

        [Description("How many grenades will be spawned for the explosion?")]
        public int scp207NadeAmount = 3;
    }
}