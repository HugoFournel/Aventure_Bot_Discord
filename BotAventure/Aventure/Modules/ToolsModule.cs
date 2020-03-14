using Aventure.Model;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aventure
{
	public class UtilsModule : ModuleBase<SocketCommandContext>
	{
		/// <summary>
		/// Simulates a roll of dice.
		/// </summary>
		/// <param name="num">The number of faces the dice have</param>
		/// <returns></returns>
		[Command("d")]
		[Summary("Lance un dé à X faces")]
		public async Task DiceRoll([Summary("Le nombre de faces")] int num)
		{
			//Init a random
			var randomGenerator = new Random();
			//Display random
			await ReplyAsync(((int)randomGenerator.Next(0, num)).ToString());
		}

		/// <summary>
		/// Display specified user infos
		/// </summary>
		/// <param name="user">The user you want info</param>
		/// <returns></returns>
		[Command("userinfo")]
		[Summary
		("Renvoie les informations sur l'utilisateur")]
		[Alias("user", "whois")]
		public async Task UserInfo(
			[Summary("L'utilisateur concerné")]
		SocketUser user = null)
		{
			//Gets user info
			var userInfo = user ?? Context.Client.CurrentUser;
			//Display infos
			await ReplyAsync($"{userInfo.Username}#{userInfo.Discriminator}");
		}

		[Command("help")]
		[Summary("Renvoie les commandes du bot")]
		[Alias("command")]
		public async Task commandList()
		{
			Settings.initCommandList();
			string rep="Liste des commandes : \n";
			foreach(var command in Settings.getCommandList().Keys)
			{
				rep += "\n";
				rep += "**"+command + "** : ";
				rep += Settings.getCommandList()[command];
			}
			await ReplyAsync(rep);
		}

		[Command("save")]
		[Summary("Save players")]
		public async Task savePlayers()
		{
			//var item = new BinarySerialize();
			//item.Serialize(DataSource.getListPlayers());
			await ReplyAsync("Donnée sauvegardée!");
		}
	}
}
