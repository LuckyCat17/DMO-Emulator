﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yggdrasil.Helpers;
using System.IO;
using Digital_World;

namespace Yggdrasil.Database
{

    public class NPC
    {
        public static Dictionary<int, NPCs> npcs = new Dictionary<int, NPCs>();

        public static void Load(string fileName)
        {
            using (Stream s = File.OpenRead(fileName))
            {
                if (npcs.Count > 0) return;
                using (BitReader read = new BitReader(s))
                {
                    int count = read.ReadInt();
                    for (int i = 0; i < 2; i++)
                    {
                        NPCs npcl = new NPCs();
                        npcl.NpcID = read.ReadInt();
                        npcl.MapID = read.ReadInt();
                        int u1 = read.ReadInt();
                        int u2 = read.ReadInt();
                        int u3 = read.ReadInt();
                        npcl.Model = read.ReadInt();
                        npcl.NPCTag = read.ReadZString(Encoding.Unicode, 64);
                        npcl.NPCName = read.ReadZString(Encoding.Unicode, 64);
                        npcl.NPCDesc = read.ReadZString(Encoding.Unicode, 1024);
                        int u4 = read.ReadInt();
                        npcl.Items = new int[u4];
                        for (int g = 0; g < u4; g++)
                        {
                            npcl.Items[g] = read.ReadInt();
                        }
                        
                        npcs.Add(npcl.NpcID, npcl);
                    }
                }
            }

            SysCons.LogDB("NPC.bin", "Loaded {0} NPC", npcs.Count);
        }
    }

    public class NPCs
    {
        public string NPCTag;
        public string NPCName;
        public string NPCDesc;
        public int MapID;
        public int NpcID;
        public int Model;
        public int[] Items;
        public short[] u1;
        public short[] u2;
        public short[] u3;
    }

    
}
