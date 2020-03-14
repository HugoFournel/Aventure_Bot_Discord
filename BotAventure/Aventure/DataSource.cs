using Aventure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aventure
{
    public static class DataSource
    {
        static List<Player> listPlayers;

        public static void initListPlayer()
        {
            BinarySerialize item = new BinarySerialize();
            List<Player> data = null;//item.UnSerialize();

            if(data != null)
            {
                listPlayers = data;
            }
            else
            {
                listPlayers = new List<Player>();
            }
        }

        public static void addPlayerToList(Player p)
        {
            listPlayers.Add(p);
        }

        public static List<Player> getListPlayers()
        {
            return listPlayers;
        }
    }
}
