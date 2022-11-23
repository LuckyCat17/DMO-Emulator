using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yggdrasil.Helpers;
using System.IO;
using Digital_World;
using System.Diagnostics;

namespace Yggdrasil.Database
{
    public class RegionDB
    {
        public static List<Region> RegionList = new List<Region>();

        public static void Load(string fileName)
        {
            if (RegionList.Count > 0) return;
            using (Stream s = File.OpenRead(fileName))
            {
                // Legge i bit dal file
                using (BitReader read = new BitReader(s))
                {
                    //Converte i bit in interi32
                    int count = read.ReadInt();
                    //Per ogni int fa un ciclo
                    for (int i = 0; i < count; i++)
                    {
                        int dcount = read.ReadInt();
                        // Per ogni int fa un ciclo dove si prende la posizione dell'intero e le assegna alle variabili 
                        for (int h = 0; h < dcount; h++)
                        {
                            Region Regi = new Region();
                            //read.Seek((int)read.InnerStream.BaseStream.Position + 62);
                            Regi.Order = h;
                            Regi.MapId = read.ReadInt();
                            Regi.X = read.ReadInt();
                            Regi.Y = read.ReadInt();
                            read.Skip(592);
                            RegionList.Add(Regi);
                        }
                    }
                }
            }
            SysCons.LogDB("MapRegion.bin", "Loaded {0} Regions", RegionList.Count);
        }

        public static Region GetID(int ID, int ID2)
        {
            Region item = null;
            foreach (Region _item in RegionList)
                if (_item.MapId == ID && _item.Order == ID2)
                {
                    item = _item;
                    break;
                }
            return item;
        }

    }
    public class Region
    {
        public int Order;
        public int MapId;
        public int X;
        public int Y;
    }
}
