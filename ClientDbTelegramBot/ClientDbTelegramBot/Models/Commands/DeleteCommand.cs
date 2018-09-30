using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ClientDbTelegramBot.Models.Commands
{
    public class DeleteCommand : Command
    {
        private static int step = 0;

        public override string Name => "delete";

        public override bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
            {
                return false;
            }

            if (message.Text.Contains(this.Name) || DialogInformation.currentDialog == "delete")
            {
                DialogInformation.currentDialog = "delete";
                return true;
            }

            return false;
        }

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;

            var clientId = -1;

            if (step == 0 && DialogInformation.isClientUpdate)
            {
                await botClient.SendTextMessageAsync(chatId, "Введите айди клиента", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
                step++;
                DialogInformation.isClientUpdate = false;
            }
            else if (step == 1 && DialogInformation.isClientUpdate)
            {
                clientId = Convert.ToInt32(message.Text);

                clientDbController.DeleteClient(clientId);

                await botClient.SendTextMessageAsync(chatId, "Клиент успешно удален",
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);

                step = 0;
                DialogInformation.isClientUpdate = false;
                DialogInformation.currentDialog = null;
            }
        }
    }
}