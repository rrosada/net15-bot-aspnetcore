/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Schema;
using SimpleBotCore.Logic;
 */

// apenas para teste .net (NON.Core)
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Schema;
using SimpleBotCore.Logic;
using System;
using System.Threading.Tasks;


namespace SimpleBotCore.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        SimpleBotUser _bot = new SimpleBotUser();

        //Repository.SimpleMessageRepository _repository = null;
        LogMongo _logMongo = null;

        //public MessagesController(SimpleBotUser bot, Repository.SimpleMessageRepository repository )
        public MessagesController(SimpleBotUser bot, LogMongo logMongo)
        {
            this._bot = bot;

            //this._repository = repository;
            this._logMongo = logMongo;

            this.call();
        }

        [HttpGet]
        public string Get()
        {
            return "Hello World";
        }



        public string call()
        {            
            Activity _activity = new Activity
            {
                Text = "cleitinho digitou hdushdushfuh",
                From = new ChannelAccount { Id = "1", Name = "Cleitinho" },
                Type = ActivityTypes.Message
            };

            var _result = this.Post(_activity).Result;

            return "true";
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
                        
            this._logMongo.AdicionaLog(message);

            var _result = _logMongo.Find(message.Id);
            message.Count = _result.Count;

            string response = _bot.Reply(message);

            await ReplyUserAsync(activity, response);
        }
        

            /*
        async Task HandleActivityAsync(Activity activity)
        {
            string text = activity.Text;
            string userFromId = activity.From.Id;
            string userFromName = activity.From.Name;

            var message = new SimpleMessage(userFromId, userFromName, text);

            try
            {
                //var _repository = new Repository.SimpleMessageRepository();
                this._repository.Insert(message);

                // verificar quantas mensagens ja foram gravadas na base
                // $"{message.User} disse '{message.Text} quant:' {countMessage} ";
                //var _result = _repository.Find("{'Id':" + message.Id + "}");
                var _result = _repository.Find($"{message.Id}");
                
                var _countMessages = _result.Count();

                string response = _bot.Reply(message);

                await ReplyUserAsync(activity, response);
            }
            catch
            {
                throw;
            }
        }
        */

        // Responde mensagens usando o Bot Framework Connector
        async Task ReplyUserAsync(Activity message, string text)
        {
            var connector = new ConnectorClient(new Uri(message.ServiceUrl));
            var reply = message.CreateReply(text);

            await connector.Conversations.ReplyToActivityAsync(reply);
        }
    }
}
