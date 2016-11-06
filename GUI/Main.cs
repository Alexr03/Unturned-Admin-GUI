using Rocket.Core.Plugins;
using Rocket.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rocket.Unturned.Player;
using Rocket.API.Extensions;
using System.Timers;
using Rocket.Core.Logging;
using SDG.Unturned;
using Steamworks;

namespace GUI
{
    public class Main : RocketPlugin
    {
        public static Main Instance;

        private int progress_A = 0;
        private int progress_B = 0;
        private int progress_C = 0;
        private int progress_D = 0;
        private int progress_E = 0;
        private Timer reload;
        private List<CSteamID> players = new List<CSteamID>();

        protected override void Load()
        {
            Instance = this;
            Rocket.Core.Logging.Logger.Log("GUI has loaded");

            reload = new Timer();
            reload.Interval = 500;
            reload.Elapsed += reload_Elapsed;
            reload.Enabled = true;

            U.Events.OnPlayerConnected += Events_OnPlayerConnected;
            U.Events.OnPlayerDisconnected += Events_OnPlayerDisconnected;
        }

        void Events_OnPlayerDisconnected(UnturnedPlayer player)
        {
            players.Remove(player.CSteamID);
        }

        void Events_OnPlayerConnected(UnturnedPlayer player)
        {
            players.Add(player.CSteamID);
            player.Player.gameObject.TryAddComponent<Module.HUD2>();
        }

        private void reload_Elapsed(object sender, ElapsedEventArgs e)
        {
            Update_Values();
        }

        private void Update_Values()
        {
            progress_A = new Random().Next(200) - 100;
            progress_B = new Random().Next(200) - 100;
            progress_C = new Random().Next(200) - 100;
            progress_D = new Random().Next(200) - 100;
            progress_E = new Random().Next(200) - 100;

            Logger.Log("Looping, values - A: " + progress_A + " B: " + progress_B + " C: " + progress_C + " D: " + progress_D + "E: " + progress_E);

            //base.BroadcastMessage("tellFlagsUpdate", new object[progress_A, progress_B, progress_C, progress_D, progress_E]);
            //base.SendMessage("tellFlagsUpdate", new object[progress_A, progress_B, progress_C, progress_D, progress_E]);

            foreach (CSteamID player in players)
            {
                Player plr_player= PlayerTool.getPlayer(player);
                plr_player.channel.send("tellFlagsUpdate", ESteamCall.OWNER, ESteamPacket.UPDATE_RELIABLE_BUFFER, new object[progress_A, progress_B, progress_C, progress_D, progress_E]);
            }

        }

        

        protected override void Unload()
        {
            Logger.Log("Unloading " + this.Name);
        }
    }
}
