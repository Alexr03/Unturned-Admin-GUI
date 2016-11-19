using SDG.Unturned;
using System;
using UnityEngine;

namespace Module
{
    public class HUD_ServerSettings : MonoBehaviour
    {
        public Rect Menu = new Rect(610f, 10f, 300f, 300f);

        public bool MenuOn;

        public void OnGUI()
        {
            if (Provider.isConnected && !Provider.isLoading && this.MenuOn)
            {
                this.Menu = GUILayout.Window(3, this.Menu, new GUI.WindowFunction(this.windowContent), "Server Settings Menu");
            }
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.F3))
            {
                this.MenuOn = !this.MenuOn;
            }
        }

        public void windowContent(int id)
        {
            var Label_style = new GUIStyle(GUI.skin.button);
            Label_style.normal.textColor = Color.red;
            Label_style.stretchWidth = true;
            Label_style.fontSize = 20;

            GUILayout.Label("Time / Weather:", Label_style);

            if (GUILayout.Button("Day"))
            {
                ChatManager.sendChat(EChatMode.GROUP, "/day");
            }
            if (GUILayout.Button("Night"))
            {
                ChatManager.sendChat(EChatMode.GROUP, "/night");
            }
            if (GUILayout.Button("Storm"))
            {
                ChatManager.sendChat(EChatMode.GROUP, "/storm");
            }

            GUILayout.Label("Misc:", Label_style);

            if (GUILayout.Button("AirDrop"))
            {
                ChatManager.sendChat(EChatMode.GROUP, "/airdrop");
            }
            if (GUILayout.Button("Save"))
            {
                ChatManager.sendChat(EChatMode.GROUP, "/save");
            }

            GUI.DragWindow();
        }
    }
}