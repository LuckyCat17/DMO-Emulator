using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yggdrasil.Helpers;
using System.IO;
using Digital_World;

namespace Yggdrasil.Database
{
    public class MapList
    {
        public static Dictionary<int, sInfoMapList> MapListList = new Dictionary<int, sInfoMapList>();
        public static void Load(string fileName)
        {
            if (MapListList.Count > 0) return;
            using (Stream s = File.OpenRead(fileName))
            {
                using (BitReader read = new BitReader(s))
                {
                    int count = read.ReadInt();
                    for (int i = 0; i < count; i++)
                    {
                        read.Seek(4 + i * 476);
                        sInfoMapList infoMapList = new sInfoMapList();
                        infoMapList.s_nFatigue_DeBuff = read.ReadUShort();
                        infoMapList.s_nMapRegionID = read.ReadUShort();
                        infoMapList.s_nFatigue_Type = read.ReadUShort();
                        infoMapList.s_nFatigue_StartTime = read.ReadUShort();
                        infoMapList.s_nHeight = read.ReadInt();
                        infoMapList.s_cMapName = read.ReadString(150, false);
                        infoMapList.s_nCamera_Max_Level = read.ReadUShort();
                        infoMapList.s_nFatigue_AddTime = read.ReadUShort();
                        infoMapList.s_cMapPath = read.ReadString(150, false);
                        //infoMapList.s_bXgConsumeType = read.ReadString(150, false);
                        infoMapList.s_nWidth = read.ReadInt();
                        infoMapList.s_cBGSound = read.ReadString(150, false);
                        infoMapList.s_szMapDiscript = read.ReadString(150, false);
                        infoMapList.s_dwResurrectionMapID = read.ReadUInt();
                        infoMapList.s_dwMapID = read.ReadUInt();
                        //infoMapList.s_bBattleTagUse = read.ReadString(150, false);
                        infoMapList.s_szMapDiscript_Eng = read.ReadString(150, false);
                        infoMapList.s_nFatigue_AddPoint = read.ReadShort();
                        MapListList.Add(infoMapList.s_nMapRegionID, infoMapList);
                    }
                }
            }
            SysCons.LogDB("MapList.bin", "Loaded {0} MapLists.", MapListList.Count);
        }
    }

    public class sInfoMapList
    {
		public ushort s_nFatigue_DeBuff;
		public ushort s_nMapRegionID;                      // ¼­¹ö¿ÍÀÇ Åë½Å¿¡¼­ ¾µ MapID
		public ushort s_nFatigue_Type;
		public ushort s_nFatigue_StartTime;
		public int s_nHeight;
		public string s_cMapName;
		public ushort s_nCamera_Max_Level;
		public ushort s_nFatigue_AddTime;
		public string s_cMapPath;
		public bool s_bXgConsumeType;
		public int s_nWidth;
		public string s_cBGSound;
		public string s_szMapDiscript;
		public uint s_dwResurrectionMapID;
		public uint s_dwMapID;
		public bool s_bBattleTagUse;
		public string s_szMapDiscript_Eng;
		public short s_nFatigue_AddPoint;
	}
}
