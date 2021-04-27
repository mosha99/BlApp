using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlApp.Shared;
//using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.SignalR;
//using Microsoft.AspNet.SignalR;
//using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;
namespace BlApp.Server.Hubs
{
    public class ChatHub : Hub
    {
        public services.Iservices Userservis;
        public ChatHub(services.Iservices userservis)
        {
            Userservis = userservis;

        }

        public async Task SendMessage(string message, int to)
        
        {

            if (to != null && message != null)
            {
                try
                {
                    var sendto = Userservis.addmessage(to, Context.ConnectionId, message);
                    var item = sendto.Message;

                    //string Ns = Userservis.getname(Context.ConnectionId);

                    var x = JsonConvert.SerializeObject(new messageL { date = item.sendDate, message = item.messag, name = item.sender.firstname + " " + item.sender.lastname, tname = "me", id = item.sender.id });
                    await Clients.Client(sendto.Cid).SendAsync("ReceiveMessage", x);
                    x = JsonConvert.SerializeObject(new messageL { date = item.sendDate, message = item.messag, name = "me", tname = item.target.firstname + " " + item.target.firstname, id = item.sender.id });
                    await Clients.Client(Context.ConnectionId).SendAsync("ReceiveMessage", x);
                }
                catch
                {
                    await Clients.Client(Context.ConnectionId).SendAsync("success", "is fild");
                }
                
            }
            else
            {
                await Clients.Client(Context.ConnectionId).SendAsync("ReceiveMessage", to.ToString(), "کاربر یافت نشد");
            }

        }
        public async Task start(string token)
        {
            string id = Context.ConnectionId;
            try
            {

                int Id = Userservis.change(token, Context.ConnectionId);
                if (Id!=-1)
                {
                    await Clients.Client(id).SendAsync("success", "is success");

                    var list = Userservis.inputM(Id,true);
                    var list2 = Userservis.senderM(Id);

                    foreach (var item in list)
                    {
                        var x =JsonConvert.SerializeObject(new messageL { date=item.sendDate , message=item.messag , name=item.sender.firstname+" "+item.sender.lastname ,tname="me", id=item.sender.id});
                        await Clients.Client(id).SendAsync("ReceiveMessage", x);
                    }
                    foreach (var item in list2)
                    {
                        var x = JsonConvert.SerializeObject(new messageL { date = item.sendDate, message = item.messag, name = "me",tname=item.target.firstname+" "+item.target.lastname, id = item.target.id });
                        await Clients.Client(id).SendAsync("ReceiveMessage", x);
                    }

                    await Clients.Client(id).SendAsync("success", "all send");
                }

                else await Clients.Client(id).SendAsync("success", "is fild");

            }
            catch (Exception ex)
            {
                await Clients.Client(id).SendAsync("success", "is fild");
            }
        }
        /*
        public async Task conline()
        {
            List<user> nu = users.Data;
            users.Data = new List<user>();
            //var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            //var clients = context.Clients.All;
            foreach (var item in nu)
            {
                await Clients.Client(item.id).SendAsync("io", true);
            }
        }
        public override Task OnConnectedAsync()
        {
            var x = Clients;
            var x1 = Context;
            return base.OnConnectedAsync();
        }*/
        public override Task OnDisconnectedAsync(Exception exception)
        {
            var x = Clients;
            var x1 = Context;
            var f = Userservis.ofline(x1.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }

        //public override Task OnDisconnectedAsync(Exception exception)
        //{

        //    return base.OnDisconnectedAsync(exception);
        //}*/

    }
}