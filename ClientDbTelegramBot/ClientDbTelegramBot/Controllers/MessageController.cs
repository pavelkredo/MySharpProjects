using System.Web.Http;
using System.Web.Http.Results;
using Telegram.Bot.Types;
using ClientDbTelegramBot.Models;
using System.Threading.Tasks;

namespace ClientDbTelegramBot.Controllers
{
    [Route("api/message/update")]
    public class MessageController : ApiController
    {
        [HttpGet]
        public string Get()
        {
            return "Method GET unuvalable";
        }

        [HttpPost]
        public async Task<OkResult> Post([FromBody]Update update)
        {
            if (update == null)
            {
                return Ok();
            }

            var commands = Bot.Commands;
            var message = update.Message;
            var client = await Bot.GetBotClientAsync();

            DialogInformation.isClientUpdate = true;

            foreach (var command in commands)
            {
                if (command.Contains(message))
                {
                    await command.Execute(message, client);
                    break;
                }
            }

            return Ok();
        }
    }
}
