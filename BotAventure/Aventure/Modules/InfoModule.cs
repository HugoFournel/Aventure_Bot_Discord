using Aventure.Model;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aventure
{
	[Group("intro")]
	public class IntroModule : ModuleBase<SocketCommandContext>
    {
		/// <summary>
		/// Say an introduction message
		/// </summary>
		/// <returns></returns>
		[Command("say")]
		[Summary("Dis bonjour.")]
		public Task Say()
			=> ReplyAsync(Settings.getIntroMessage() ?? "Salut les aventuriers!");

		[Command("set")]
		[Summary("Dis bonjour.")]
		public async Task SetIntroMessage([Summary("The introduction message")] string message)
		{
			Settings.setIntroMessage(message);
			await  ReplyAsync("Message d'introduction défini sur : "+Settings.getIntroMessage());
		}
	}

	
}
