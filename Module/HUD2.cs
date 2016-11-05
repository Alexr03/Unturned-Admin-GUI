using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Module
{
    public class HUD2 : PlayerCaller
    {
        private int progress_A = 0;
        private int progress_B = 0;
        private int progress_C = 0;
        private int progress_D = 0;
        private int progress_E = 0;


        private void Start()
        {
            //base.channel.build();
            //askToggleHud(true);
        }


        public void flagsUpdate(CSteamID steamID, params object[] values)
        {
            if (base.channel.checkServer(steamID))
            {
                progress_A = int.Parse(values[0] + "");
                progress_B = int.Parse(values[1] + "");
                progress_C = int.Parse(values[2] + "");
                progress_D = int.Parse(values[3] + "");
                progress_E = int.Parse(values[4] + "");
            }
        }

        public void OnGUI()
        {
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height - 50, 200, 100), "A: " + progress_A + " \n B: " + progress_B + "\n C:" + progress_C + "\n D:" + progress_D + "\n E:" + progress_E);
        }
    }
}
