using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Schema;
using SimpleBotCore.Logic;
using SimpleBotCore.Logic.Repository;

namespace SimpleBotCore.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        SimpleBotUser _bot = new SimpleBotUser();
        
        public MessagesController(SimpleBotUser bot)
        {
            this._bot = bot;
        }

        [HttpGet]
        public string Get()
        {
            return "Hello World";
        }

        // POST api/messages
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Activity activity)
        {
            if (activity != null && activity.Type == ActivityTypes.Message)
            {
                await HandleActivityAsync(activity);
            }

            // HTTP 202
            return Accepted();
        }

        // Estabelece comunicacao entre o usuario e o SimpleBotUser
        async Task HandleActivityAsync(Activity activity)
        {
            string text = activity.Text;
            string userFromId = activity.From.Id;
            string userFromName = activity.From.Name;

            var message = new SimpleMessage(userFromId, userFromName, text);

            try
            {
                var _repository = new SimpleMessageRepository();
                _repository.Insert(message);

                // verificar quantas mensagens ja foram gravadas na base
                // $"{message.User} disse '{message.Text} quant:' {countMessage} ";
                //var _result = _repository.Find("{'Id':" + message.Id + "}");
                var _result = _repository.Find($"{message.Id}");

                var _countMessages = _result.Count();

                string response = _bot.Reply(message, _countMessages);

                await ReplyUserAsync(activity, response);
            }
            catch
            {
                throw;
            }
        }

        // Responde mensagens usando o Bot Framework Connector
        async Task ReplyUserAsync(Activity message, string text)
        {
            var connector = new ConnectorClient(new Uri(message.ServiceUrl));
            var reply = message.CreateReply(text);

            await connector.Conversations.ReplyToActivityAsync(reply);
        }
    }
}
