﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using ClientDbTelegramBot.Models.Commands;
using ClientDbTelegramBot.Controllers;

namespace ClientDbTelegramBot.Models
{
    public static class Bot
    {
        private static TelegramBotClient botClient;
        private static List<Command> commandsList;

        public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();

        public static async Task<TelegramBotClient> GetBotClientAsync()
        {
            if (botClient != null)
            {
                return botClient;
            }

            commandsList = new List<Command>()
            {
                new RegistrationCommand(),
                new InformationCommand()
            };

            botClient = new TelegramBotClient(AppSettings.Key);
            var hook = string.Format(AppSettings.Url, "api/message/update");
            await botClient.SetWebhookAsync(hook);

            return botClient;
        }
    }
}