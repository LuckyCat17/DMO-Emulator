using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yggdrasil.Helpers;
using System.IO;
using Digital_World;

namespace Yggdrasil.Database
{
    public class MapMonsterList
    {
        public static Dictionary<int, sINFOMonsterList> MonsterList = new Dictionary<int, sINFOMonsterList>();
        public static void Load(string fileName)
        {
            if (MonsterList.Count > 0) return;
            using (Stream s = File.OpenRead(fileName))
            {
                using (BitReader read = new BitReader(s))
                {
                    int count = read.ReadInt();
                    for (int i = 0; i < count; i++)
                    {
                        read.Seek(4 + i * 476);
                        sINFOMonsterList monsterLi = new sINFOMonsterList();
                        monsterLi.s_dwMapID = read.ReadInt();
                        monsterLi.s_dwMonsterTableID = read.ReadUInt();
                        monsterLi.s_nCenterX = read.ReadInt();
                        monsterLi.s_nCenterY = read.ReadInt();
                        monsterLi.s_nRadius = read.ReadInt();
                        monsterLi.s_nCount = read.ReadInt();
                        monsterLi.s_nResponTime = read.ReadInt();
                        monsterLi.s_nKillgen_MonFTID = read.ReadInt();
                        monsterLi.s_nKillgen_Count = read.ReadInt();
                        monsterLi.s_nKillgen_ViewCnt = read.ReadInt();
                        monsterLi.s_nMoveType = read.ReadInt();
                        //monsterLi.s_bInsRespon = read.ReadInt();
                        MonsterList.Add(monsterLi.s_dwMapID, monsterLi);
                    }
                }
            }
            SysCons.LogDB("MapMonsterList.bin", "Loaded {0} buffs.", MonsterList.Count);
        }

        //int GetModelID() { return sINFOMonsterList.GetModelID(); }
    }

    public class sINFOMonsterList
    {


        public int s_dwMapID;
        public uint s_dwMonsterTableID;
        public int s_nCenterX;
        public int s_nCenterY;
        public int s_nRadius;
        public int s_nCount;
        public int s_nResponTime;

        public int s_nKillgen_MonFTID;
        public int s_nKillgen_Count;
        public int s_nKillgen_ViewCnt;
        public int s_nMoveType;
        public bool s_bInsRespon;
    }

    public enum eMONSTER_MOVE
    {
        MT_NONE = 0,
        MT_NORMAL = 1,
        MT_MOVE = 2,
        MT_HOLD = 3,
    };
}
