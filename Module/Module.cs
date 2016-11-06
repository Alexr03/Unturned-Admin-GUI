using Rocket.API.Extensions;
using SDG.Framework.Modules;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
using UnityEngine;

namespace Module
{
    class Module : PlayerCaller, IModuleNexus
    {

        public void initialize()
        {
            SDG.Unturned.Player.onPlayerCreated += (SDG.Unturned.Player player) =>
            {
                player.transform.gameObject.TryAddComponent<HUD2>();
            };
        }

        public void shutdown()
        {
        }
    }
}
