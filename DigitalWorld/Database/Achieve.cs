using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yggdrasil.Helpers;
using System.IO;
using Digital_World;

namespace Yggdrasil.Database
{
    public class Achieve
    {
		public static Dictionary<int, AchieveSINFO> achieves = new Dictionary<int, AchieveSINFO>();

		public static void Load(string fileName)
		{
			if (achieves.Count > 0) return;
			using (Stream s = File.OpenRead(fileName))
			{
				using (BitReader read = new BitReader(s))
				{
					int count = read.ReadInt();
					for (int i = 0; i < count; i++)
					{
						//read.Seek(4 + i * 476);
						AchieveSINFO achieve = new AchieveSINFO();
						achieve.s_nQuestID = read.ReadInt();
						achieve.s_nIcon = read.ReadInt();
						achieve.s_nPoint = read.ReadUShort();
						achieve.s_szName  = read.ReadZString(Encoding.ASCII);
						achieve.s_szComment = read.ReadZString(Encoding.ASCII); ;
						achieve.s_szTitle = read.ReadZString(Encoding.ASCII);
						//achieve.s_bDisplay = read.ReadByte() bool;
						achieve.s_nGroup = read.ReadInt();
						achieve.s_nSubGroup = read.ReadInt();
						achieve.s_nType = read.ReadInt();
						achieve.s_nBuffCode = read.ReadInt();

						if (!achieves.ContainsKey(achieve.s_nQuestID))
						{
							achieves.Add(achieve.s_nQuestID, achieve);
						}
						
					}
				}
			}
			SysCons.LogDB("Achieve.bin", "Loaded {0} buffs.", achieves.Count);
		}
	}

	public class AchieveSINFO
    {
		//DWORD s_nQuestID;
		//DWORD s_nIcon;
		public int s_nQuestID;
		public int s_nIcon;
		public ushort s_nPoint;
		public bool s_bDisplay;

		//TCHAR s_szName[FT_ACHIEVE_NAME];
		//TCHAR s_szComment[FT_ACHIEVE_COMMENT];
		//TCHAR s_szTitle[FT_ACHIEVE_TITLE];
		public string s_szName;
		public string s_szComment;
		public string s_szTitle;

		public int s_nGroup;
		public int s_nSubGroup;
		public int s_nType;
		public int s_nBuffCode;
	}
}
