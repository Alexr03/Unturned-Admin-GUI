using Rocket.Core.Plugins;
using Rocket.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rocket.Unturned.Player;
using Rocket.API.Extensions;

namespace GUI
{
    public class Main : RocketPlugin
    {
        public static Main Instance;

        protected override void Load()
        {
            Instance = this;
            Rocket.Core.Logging.Logger.Log("GUI has loaded");

            U.Events.OnPlayerConnected += Connected;
        }

        private void Connected(UnturnedPlayer player)
        {

        }

        protected override void Unload()
        {
            U.Events.OnPlayerConnected -= Connected;
        }

        private void FixedUpdate()
        {
        }
    }
}
