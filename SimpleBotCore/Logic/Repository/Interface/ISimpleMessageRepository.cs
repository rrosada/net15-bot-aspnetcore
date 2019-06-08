using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBotCore.Logic.Repository.Interface
{
    public interface ISimpleMessageRepository
    {
        IEnumerable<SimpleMessage> Find(string filter);

        void Insert(SimpleMessage message);
    }
}
