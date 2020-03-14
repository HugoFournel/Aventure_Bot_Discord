using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aventure.Modules
{
    [Group("player")]
    public class GameModule : ModuleBase<SocketCommandContext>
    {
        [Command("add")]
        [Summary("Ajoute un joueur au bot prenom")]
        public async Task addPlayer([Summary("Le prénom du personnage")] string firstname)
        {
            DataSource.addPlayerToList(new Model.Player(firstname));
            await ReplyAsync("Personnage ajouté!");
        }

        [Command("get")]
        [Summary("Retourne la fiche du personnage")]
        public async Task getPlayer([Summary("Le prénom du personnage")]string firstname)
        {
            Model.Player rep = null;
            foreach(Model.Player player in DataSource.getListPlayers())
            {
                if(player.FirstName.Equals(firstname))
                {
                    rep = player;
                }
            }
            string buildReply = "";
            if (rep != null)
            {
                buildReply = "\n```   \n";
                buildReply += "!!! 𝕱𝖎𝖈𝖍𝖊 𝖕𝖊𝖗𝖘𝖔𝖓𝖓𝖆𝖌𝖊 !!!\n";
                buildReply += "• 𝕻𝖊𝖗𝖘𝖔𝖓𝖓𝖆𝖌𝖊 :  ";
                buildReply += rep.FirstName + " " + rep.Name;
                buildReply += "\n";
                buildReply += "• 𝓐𝖌𝖊 : ";
                buildReply += rep.Age;
                buildReply += "\n";
                buildReply += "• 𝓐𝖗𝖒𝖊 : ";
                buildReply += rep.Weapon;
                buildReply += "\n";
                buildReply += "• 𝕯𝖊𝖘𝖈𝖗𝖎𝖕𝖙𝖎𝖔𝖓 : ";
                buildReply += "\n";
                buildReply += " " + rep.Description + "";
                buildReply += " ```";
            }
            else
            {
                buildReply = "Pas de personnage trouvé!";
            }
            await ReplyAsync(buildReply) ;
        }

        [Command("name")]
        [Summary("Le nom du personnage")]
        public async Task setName([Summary("Prénom du personnage")]string firstname, [Summary("Nom que vous donnez")]string name)
        {
            foreach (Model.Player p in DataSource.getListPlayers())
            {
                if (p.FirstName.Equals(firstname))
                {
                    p.Name = name;
                }
            }
            var list = DataSource.getListPlayers();
            await ReplyAsync("Nom ajouté !  ");
        }


        [Command("age")]
        [Summary("L'age du personnage")]
        public async Task setAge([Summary("Prénom du personnage")]string firstname, [Summary("Age que vous donnez")]int age)
        {
            foreach (Model.Player p in DataSource.getListPlayers())
            {
                if (p.FirstName.Equals(firstname))
                {
                    p.Age = age;
                }
            }
            var list = DataSource.getListPlayers();
            await ReplyAsync("Age ajouté !  ");
        }

        [Command("weapon")]
        [Summary("L'arme du personnage")]
        public async Task setWeapon([Summary("Prénom du personnage")]string firstname, [Summary("Arme que vous donnez")]string weapon)
        {
            foreach (Model.Player p in DataSource.getListPlayers())
            {
                if (p.FirstName.Equals(firstname))
                {
                    p.Weapon = weapon;
                }
            }
            var list = DataSource.getListPlayers();
            await ReplyAsync("Arme ajoutée !  ");
        }

        [Command("description")]
        [Summary("Le nom du personnage")]
        public async Task setDesc([Summary("Prénom du personnage")]string firstname, [Summary("Description que vous donnez")]string desc)
        {
            foreach (Model.Player p in DataSource.getListPlayers())
            {
                if (p.FirstName.Equals(firstname))
                {
                    p.Description = desc;
                }
            }
            var list = DataSource.getListPlayers();
            await ReplyAsync("Description ajoutée !  ");
        }
        [RequireOwner()]
        [Command("delete")]
        [Summary("Supprime le personnage")]
        public async Task delete([Summary("Prénom du personnage")]string firstname)
        {
            foreach (Model.Player p in DataSource.getListPlayers())
            {
                if (p.FirstName.Equals(firstname))
                {
                    DataSource.getListPlayers().Remove(p);
                }
            }
            var list = DataSource.getListPlayers();
            await ReplyAsync("Personnage supprimé !  ");
        }

    }
}
