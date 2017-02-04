using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skrub_Bot
{
    class Skrub_Bot
    {
        DiscordClient discord;

        public Skrub_Bot()
            {
                discord = new DiscordClient(x =>
                {
                    x.LogLevel = LogSeverity.Info;
                    x.LogHandler = Log;
                });


                discord.UsingCommands(x =>
                {
                    x.PrefixChar = '!';
                    x.AllowMentionPrefix = true;
                });
                
                // commands
                var commands = discord.GetService<CommandService>();


                commands.CreateCommand("Commands")
                    .Do(async (e) =>
                    {
                        await e.Channel.SendMessage("The available commands for me are: **`!Commands`** **`!Bot`** **`!Skrubs`**" +
                            " **`!Pix`** and **`!Skrub`**");
                    });


                


                commands.CreateCommand("Pix")
                    .Do(async (e) =>
                    {
                        await e.Channel.SendMessage("No-one really knows what Pix is. We don't even know how" +
                            " he got into Sparta in the first place. What we do know however is: He's a Scouser :nauseated_face:" +
                            " and can only communicate through Burping and Morse code by tapping his Mic. He is also" +
                            " **__the biggest Skrub__** of all.");
                    });
                

                commands.CreateCommand("Bot")
                    .Do(async (e) =>
                    {
                        await e.Channel.SendMessage("**Hello!** My name is __Skrub Bot__ and I was created, designed, programmed and perfected" +
                            " by the coolest person in the world, **__Boz!__**. Im here to expose the biggest Skrubs" +
                            " in the world! For help please contact an Admin (By using the @Admin tag) or use !command to discover commands for me!");                                                                           
                    });


                commands.CreateCommand("skrubs")
                        .Do(async (e) =>
                        {
                            await e.Channel.SendMessage("Everyone in the Skrub Server group (use @Skrub) but mainly Pix.");
                        });



                commands.CreateCommand("Skrub")
                        .Do(async (e) =>
                        {
                        await e.Channel.SendMessage("Pix is a Skrub");
                        });
                
                

                // Bot token to the server
                discord.ExecuteAndWait(async () =>
                {
                    await discord.Connect("Mjc2NzU3MjMyNjY4OTAxMzc2.C3T6JQ.PPrOl1s_dhNzKxZvWjJcZeYF3IM", TokenType.Bot);
                });
            }


        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message); 
        }
    }
}
