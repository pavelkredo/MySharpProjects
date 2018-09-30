using ClientDbTelegramBot.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ClientDbTelegramBot.Models.Commands
{
    public abstract class Command
    {
        protected ClientController clientDbController = new ClientController();

        public abstract string Name { get; }

        public abstract bool Contains(Message message);

        public abstract Task Execute(Message message, TelegramBotClient client);
    }
}