using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramAutoPosting.Interfaces
{
    public interface ITelegramService
    {
        void SendMessageToChannel(string message);
    }
}
