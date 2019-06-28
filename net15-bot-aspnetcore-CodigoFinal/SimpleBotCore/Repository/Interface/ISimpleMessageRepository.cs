using SimpleBotCore.Logic;
using System.Collections.Generic;

namespace SimpleBotCore.Repository.Interface
{
    interface ISimpleMessageRepository
    {
        IEnumerable<SimpleMessage> Find(string filter);
        void Insert(SimpleMessage message);
    }
}
