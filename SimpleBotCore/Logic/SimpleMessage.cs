﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBotCore.Logic
{
    public class SimpleMessage
    {
        public string Id { get; }
        public string User { get; }
        public string Text { get; }

        //public int Quant { get; set; }

        public SimpleMessage(string id, string username, string text)
        {
            this.Id = id;
            this.User = username;
            this.Text = text;
        }
    }
}