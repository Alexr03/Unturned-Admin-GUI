using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Module
{
    public class HUD_Players : MonoBehaviour
    {
        public Rect Menu = new Rect(310f, 10f, 350f, 350f);

        private bool menuOn;

        private bool ban;

        private bool kick = true;

        private bool spy;

        private bool tp;

        private string search = "";

        private Vector2 Scroll;

        private string Action()
        {
            if (this.ban)
            {
                return "Ban";
            }
            if (this.kick)
            {
                return "Kick";
            }
            if (this.tp)
            {
                return "Tp";
            }
            return "Spy";
        }

        public void OnGUI()
        {
            if (Provider.isConnected && !Provider.isLoading && this.menuOn)
            {
                this.Menu = GUILayout.Window(2, this.Menu, new GUI.WindowFunction(this.windowContent), "Player Menu");
            }
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.F2))
            {
                this.menuOn = !this.menuOn;
            }
        }

        public void windowContent(int id)
        {
            CSteamID cSteamID;
            GUILayout.Label("Search:", new GUILayoutOption[0]);
            this.search = GUILayout.TextField(this.search, new GUILayoutOption[0]);

            if (GUILayout.Button(string.Concat("Action: ", this.Action())))
            {
                if (this.ban)
                {
                    this.ban = !this.ban;
                    this.kick = !this.kick;
                    this.tp = !this.tp;
                }
                else if (!this.kick)
                {
                    this.spy = !this.spy;
                    this.ban = !this.ban;
                }
                else
                {
                    this.kick = !this.kick;
                    this.spy = !this.spy;
                }
            }
            this.Scroll = GUILayout.BeginScrollView(this.Scroll, new GUILayoutOption[0]);
            for (int i = 0; i < Provider.clients.Count; i++)
            {
                SteamPlayer item = Provider.clients[i];
                if (string.IsNullOrEmpty(this.search))
                {
                    if (GUILayout.Button(item.player.name, GUILayout.ExpandWidth(true)))
                    {
                        if (this.spy)
                        {
                            cSteamID = item.playerID.steamID;
                            ChatManager.sendChat(EChatMode.LOCAL, string.Concat("/spy ", cSteamID.ToString()));
                        }
                        else if (this.ban)
                        {
                            string[] str = new string[] { "/oban ", null };
                            cSteamID = item.playerID.steamID;
                            str[1] = cSteamID.ToString();
                            ChatManager.sendChat(EChatMode.LOCAL, string.Concat(str));
                        }
                        else if (this.kick)
                        {
                            cSteamID = item.playerID.steamID;
                            ChatManager.sendChat(EChatMode.LOCAL, string.Concat("/okick ", cSteamID.ToString()));
                        }

                        else if (this.tp)
                        {
                            cSteamID = item.playerID.steamID;
                            ChatManager.sendChat(EChatMode.LOCAL, string.Concat("/tp ", cSteamID.ToString()));
                        }
                    }
                }
                else if ((item.playerID.characterName.Contains(this.search) || item.playerID.playerName.Contains(this.search) || item.playerID.steamID.ToString().Contains(this.search)) && GUILayout.Button(string.Concat(item.playerID.characterName, "[", item.playerID.playerName, "]"), new GUILayoutOption[0]))
                {
                    if (this.spy)
                    {
                        cSteamID = item.playerID.steamID;
                        ChatManager.sendChat(EChatMode.LOCAL, string.Concat("/spy ", cSteamID.ToString()));
                    }
                    else if (this.ban)
                    {
                        string[] str1 = new string[] { "/oban ", null };
                        cSteamID = item.playerID.steamID;
                        str1[1] = cSteamID.ToString();
                        ChatManager.sendChat(EChatMode.LOCAL, string.Concat(str1));
                    }
                    else if (this.kick)
                    {
                        cSteamID = item.playerID.steamID;
                        ChatManager.sendChat(EChatMode.LOCAL, string.Concat("/okick ", cSteamID.ToString()));
                    }
                    else if (this.tp)
                    {
                        cSteamID = item.playerID.steamID;
                        ChatManager.sendChat(EChatMode.LOCAL, string.Concat("/tp ", cSteamID.ToString()));
                    }
                }
            }
            GUILayout.EndScrollView();
            GUI.DragWindow();
        }
    }

}