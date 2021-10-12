using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TelegramAutoPosting.Interfaces;

namespace TelegramAutoPosting.Services
{
    public class TelegramService: ITelegramService
    {

        IConfiguration _configuration;
        public TelegramService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendMessageToChannel(string message)
        {
            var telegramEndPoint = _configuration["TelegramSettings:EndpointTelegram"];
            var apiToken = _configuration["TelegramSettings:BookinglaneChannel:BotToken"];
            var chatId = _configuration["TelegramSettings:BookinglaneChannel:ChatId"];
            //string pathPhoto = @"C:\Users\Melis\source\repos\TelegramAutoPosting\TelegramAutoPosting\wwwroot\img\Laptop.jpg";

            telegramEndPoint = String.Format(telegramEndPoint, apiToken, chatId, message);
            WebRequest requestFrom = WebRequest.Create(telegramEndPoint);
            Stream rs = requestFrom.GetResponse().GetResponseStream();
        }
    }
}
