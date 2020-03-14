using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Aventure.Model
{
    public static class Settings
    {
        static string introMessage;
        static Dictionary<string,string> commandList;

        public static void setIntroMessage(string newMessage)
        {
            introMessage = newMessage;
        }

        public static string getIntroMessage()
        {
            return introMessage;
        }

        //initiate command list
        public static void initCommandList()
        {
            commandList = new Dictionary<string, string>();
            commandList.Add("-*intro say*","*Ecris le message d'introduction*");
            commandList.Add("-*intro set*","*Permet de définir le message d'introduction*, Exemple: !intro set [\"Votre message\"]");
            commandList.Add("-*d*", "*Lance un dé du nombre de faces demandées*, Exemple: !d [\"Nombre de faces\"]");
            commandList.Add("-*user*", "*Donne les informations sur l'utilisateur*, Exemple: !user [\"Votre utilisateur\"]");
        }

        public static Dictionary<string, string> getCommandList()
        {
            return commandList;
        }
    }
}
