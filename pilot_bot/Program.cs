using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;
using airbot.Services.Requests;

namespace airbot
{
    class Program
    {
        private static awcRequests awc = new awcRequests();
        private static owmRequests owm = new owmRequests();
        private static tgRequests tg = new tgRequests();
        static ITelegramBotClient botClient;
        static void Main(string[] args)
        {
            botClient = new TelegramBotClient("945925385:AAE5_3LuEWroIq39TkYvkYVHbEG25eAlJJQ");

            var me = botClient.GetMeAsync().Result;

            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            Thread.Sleep(int.MaxValue);
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Message.Text))
            {
                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text:   "Invalid message, type a valid command."
                );
            }
            else if (e.Message.Text.Equals("/start", StringComparison.InvariantCultureIgnoreCase))
            {
                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text:   "Welcome! Do you need aeronautical weather info?\n" +
                            "Follow the steps to get these info:\n\n" +
                            "PS.: Before type a ICAO code, remove the [ ].\n\n" +
                            "To get METAR info: \n" +
                            "/metar [ICAO]\n\n" +
                            "(Example: '/metar KJFK')\n\n\n\n"
                );
            }
            else if (e.Message.Text.Equals("/help", StringComparison.InvariantCultureIgnoreCase))
            {
                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text:   "Can i help you?\n" +
                            "Type /start and view tutorial to search " +
                            "weather info."
                );
            }
            else if (e.Message.Text.Contains("/metar", StringComparison.InvariantCultureIgnoreCase))
            {
                if (e.Message.Text.Length == 6)
                {
                    await botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text:   "You don't typed a ICAO code, repeat command " +
                                "and add the ICAO code. Or type /help if you " +
                                "need help."
                    );
                }
                else
                {
                    await botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text: $"{e.Message.Text.Substring(6, 5)}"
                    );

                    Console.WriteLine(awc.getMetar(e.Message.Text.Substring(6, 5).Replace(" ", "").ToUpper()));
                }
            }
            else
            {
                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text:   "I don't know these command, type /help or /start."
                );
            }
        }
    }
}
