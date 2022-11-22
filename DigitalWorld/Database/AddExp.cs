using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yggdrasil.Helpers;
using System.IO;
using Digital_World;
namespace Yggdrasil.Database
{
    public class AddExp
    {
        public static Dictionary<int, sAddExp> AddExpList = new Dictionary<int, sAddExp>();
        public static void Load(string fileName)
        {
            if (AddExpList.Count > 0) return;
            using (Stream s = File.OpenRead(fileName))
            {
                using (BitReader read = new BitReader(s))
                {
                    int count = read.ReadInt();
                    for (int i = 0; i < count; i++)
                    {
                        read.Seek(4 + i * 476);
                        sAddExp addExp = new sAddExp();
                        addExp.s_nID = read.ReadUShort();
                        addExp.s_nSkillID = read.ReadUShort();
                        addExp.s_nIconID = read.ReadInt();
                        addExp.s_szTitle = read.ReadZString(Encoding.ASCII);
                        addExp.s_szComment = read.ReadZString(Encoding.ASCII);

                        if (!AddExpList.ContainsKey(addExp.s_nID))
                        {
                            AddExpList.Add(addExp.s_nID, addExp);
                        }
                    }
                }
            }
            
            SysCons.LogDB("AddExp.bin", "Loaded {0} Exp.", AddExpList.Count);
        }

        //public bool IsData(int nID) { return (AddExpList.find(nID) != m_mapExp.end()); }

        //public Dictionary<int, sAddExp> GetData(int nID) 
        //{
        //    assert_cs(IsData(nID));
        //    return AddExpList.Values.f(addExp.s_nID, addExp); 
        //}

    }

    public class sAddExp
    {
        public ushort s_nID;
        public ushort s_nSkillID;
        public int s_nIconID;

        public string s_szTitle;
        public string s_szComment; 

    }
}
