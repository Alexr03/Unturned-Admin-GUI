using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Module
{
    public class HUD2 : MonoBehaviour
    {
        private int progress_A = 0;
        private int progress_B = 0;
        private int progress_C = 0;
        private int progress_D = 0;
        private int progress_E = 0;
        public bool update = false;
        public static HUD2 instance;


        private void Start()
        {
            instance = this;
            //base.channel.build();
            //askToggleHud(true);
        }

        public void tellFlagsUpdate(CSteamID steamID, object[] parameters)
        {
            if (Player.player.channel.checkServer(steamID)) 
            {
                Debug.LogError("CALLED HUD");
                flagsUpdate(parameters);
            }
            else
            {
                Debug.LogError("FAILED SERVER CHECK");
            }
        }

        public void flagsUpdate(params object[] values)
        {
            progress_A = int.Parse(values[0] + "");
            progress_B = int.Parse(values[1] + "");
            progress_C = int.Parse(values[2] + "");
            progress_D = int.Parse(values[3] + "");
            progress_E = int.Parse(values[4] + "");
        }

        public void OnGUI()
        {
            if (update)
            {
                GUI.Box(new Rect(30, 30, 150, 30), "TRUE");
                update = !update;
            } else {
                GUI.Box(new Rect(30,30,150,30), "FALSE");
                update = !update;
            }
            GUI.Box(new Rect(Screen.width / 2 - 100, 50, 200, 100), "A: " + progress_A + " \nB: " + progress_B + "\nC:" + progress_C + "\nD:" + progress_D + "\nE:" + progress_E);
        }
    }
}
