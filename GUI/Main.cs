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
        private Timer reload = new Timer();

        protected override void Load()
        {
            Instance = this;
            Rocket.Core.Logging.Logger.Log("GUI has loaded");

            reload.Interval = 500;
            reload.Elapsed += reload_Elapsed;
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

            object values = new object[progress_A, progress_B, progress_C, progress_D, progress_E];
            Logger.Log(String.Format("Looping, values - A: {O} B: {1} C: {2} D: {3} E: {4}", values));

            base.BroadcastMessage("flagsUpdate", values);
        }

        

        protected override void Unload()
        {
            Logger.Log("Unloading " + this.Name);
        }
    }
}
