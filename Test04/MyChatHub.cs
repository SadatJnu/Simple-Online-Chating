using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Test04.Models;

namespace Test04
{
    public class MyChatHub : Hub
    {
        public void SendMessage(String userName, String message)
        {
            var obj = new ChatMessage
            {
                ConnectionId = Context.ConnectionId,
                UserName = userName,
                Message = message,
                SentDate = DateTime.Now
            };

            using (var db = new ChatContext())
            {
                db.ChatMessage.Add(obj);
                db.SaveChanges();
            }
            
            Clients.All.broadcastMessage(userName, message, obj.SentDate);
            //Clients.All.broadcastMessage(userName, message);
        }
    }
}