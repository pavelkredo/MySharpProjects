using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ClientDbTelegramBot.Models.Commands
{
    public class RegistrationCommand : Command
    {
        private static int step = 0;

        private Client newClient = new Client();

        public override string Name => "registration";

        public override bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
            {
                return false;
            }

            if (message.Text.Contains(this.Name) || DialogInformation.currentDialog == "registration")
            {
                DialogInformation.currentDialog = "registration";
                return true;
            }

            return false;
        }

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;

            if (step == 0 && DialogInformation.isClientUpdate)
            {
                await botClient.SendTextMessageAsync(chatId, "Введите фамилию", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
                step++;
                DialogInformation.isClientUpdate = false;
            }
            else if (step == 1 && DialogInformation.isClientUpdate)
            {
                newClient.Surname = message.Text;
                await botClient.SendTextMessageAsync(chatId, "Введите имя", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);

                step++;
                DialogInformation.isClientUpdate = false;
            }
            else if (step == 2 && DialogInformation.isClientUpdate)
            {
                newClient.Name = message.Text;
                await botClient.SendTextMessageAsync(chatId, "Введите отчество", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);

                step++;
                DialogInformation.isClientUpdate = false;
            }
            else if (step == 3 && DialogInformation.isClientUpdate)
            {
                newClient.Patronymic = message.Text;
                await botClient.SendTextMessageAsync(chatId, "Введите дату рождения", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);

                step++;
                DialogInformation.isClientUpdate = false;
            }
            else if (step == 4 && DialogInformation.isClientUpdate)
            {
                newClient.Birthday = message.Text;

                clientDbController.CreateClient(newClient);

                await botClient.SendTextMessageAsync(chatId, "Пользователь успешно зарегистрирован", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);

                step = 0;
                DialogInformation.isClientUpdate = false;
                DialogInformation.currentDialog = null;
            }
        }
    }
}