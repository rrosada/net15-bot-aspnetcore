﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBotCore.Logic
{
    public class SimpleBotUser
    {
        public string Reply(SimpleMessage message)
        {
            return $"{message.User} disse '{message.Text}'. ({message.Count} {(message.Count == 1 ? "mensagem" : "mensagens")} enviada)";
        }

    }
}