using Discord;
using Discord.WebSocket;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Aventure
{
    class Program
    {
        private DiscordSocketClient _client;

        public static void Main(string[] args)
        => new Program().MainAsync().GetAwaiter().GetResult();

        
        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();

            _client.Log += Log;

            //Token
            var token = File.ReadAllText("C:/Users/Hugo/Documents/Git/.discord_bot_token/token.txt");


            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            CommandHandler commander = new CommandHandler(_client, new Discord.Commands.CommandService());
            DataSource.initListPlayer();
            await commander.InstallCommandsAsync();
            // Block this task until the program is closed.
            await Task.Delay(-1);
            
        }
    }
}
