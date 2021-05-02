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

            if (to != null && to > 0 && message != null)
            {
                try
                {
                    var sendto = Userservis.addmessage(to, Context.ConnectionId, message);
                    if (sendto.Message.sender == null)
                    {
                        Userservis.removeM(sendto.Message.id);
                        if (sendto.Message.target != null)
                        {
                            await Clients.Client(Context.ConnectionId).SendAsync("restart", sendto.Message.messag, sendto.Message.target.id);
                        }
                    }
                    else
                    {


                        var item = sendto.Message;

                        //string Ns = Userservis.getname(Context.ConnectionId);
                        if (item.target != null && item.sender != null)
                        {
                            var x = JsonConvert.SerializeObject(new messageL { date = item.sendDate, message = item.messag, name = item.sender.firstname + " " + item.sender.lastname, tname = "me", id = item.sender.id, Mid = item.id, seen = item.seen });
                            if (sendto.Cid != null) await Clients.Client(sendto.Cid).SendAsync("ReceiveMessage", x);

                            x = JsonConvert.SerializeObject(new messageL { date = item.sendDate, message = item.messag, name = "me", tname = item.target.firstname + " " + item.target.lastname, id = item.sender.id, Mid = item.id, seen = true });
                            await Clients.Client(Context.ConnectionId).SendAsync("ReceiveMessage", x);
                        }
                    }

                }
                catch (Exception ex)
                {
                    await Clients.Client(Context.ConnectionId).SendAsync("success", "شکست در ارسال");
                }

            }
            else
            {
                await Clients.Client(Context.ConnectionId).SendAsync("ReceiveMessage", to.ToString(), "کاربر یافت نشد");
            }

        }

        public async Task seen(int Mid)
        {
            Userservis.messagSeen(Mid);
        }




        public async Task start(string token)
        {
            string id = Context.ConnectionId;
            try
            {

                int Id = Userservis.change(token, Context.ConnectionId);
                if (Id != -1)
                {
                    await Clients.Client(id).SendAsync("success", "is success");

                    var list = Userservis.inputM(Id, true);
                    var list2 = Userservis.senderM(Id);

                    if (list != null && list.Count != 0)
                    {

                        foreach (var item in list)
                        {
                            try
                            {
                                var x = JsonConvert.SerializeObject(new messageL { date = item.sendDate, message = item.messag, name = item.sender.firstname + " " + item.sender.lastname, tname = "me", id = item.sender.id, Mid = item.id, seen = item.seen });
                                await Clients.Client(id).SendAsync("ReceiveMessage", x);
                            }
                            catch
                            {
                                await Clients.Client(id).SendAsync("success", $"مشکل{ item.id}");
                            }


                        }
                    }
                    if (list2 != null && list2.Count != 0)
                    {

                        foreach (var item in list2)
                        {
                            try
                            {
                                if (item.target != null)
                                {
                                    var x = JsonConvert.SerializeObject(new messageL { date = item.sendDate, message = item.messag, name = "me", tname = item.target.firstname + " " + item.target.lastname, id = item.target.id, Mid = item.id, seen = true });
                                    await Clients.Client(id).SendAsync("ReceiveMessage", x);
                                }
                            }
                            catch
                            {
                                await Clients.Client(id).SendAsync("success", $"مشکل{ item.id}");
                            }
                        }

                    }
                    await Clients.Client(id).SendAsync("success", "all send");
                }

                else await Clients.Client(id).SendAsync("success", "کاربر پیدا نشد");

            }
            catch (Exception ex)
            {
                await Clients.Client(id).SendAsync("success", "شکست");
            }
        }




        public async Task getall()
        {
            string id = Context.ConnectionId;

            try
            {
                var Ulist = Userservis.getall();
                Ulist = Ulist.Where(x => x.connectionId != id)?.ToList();
                foreach (var item in Ulist)
                {
                    var x = JsonConvert.SerializeObject(new user { id = item.id, name = item.firstname + " " + item.lastname });
                    await Clients.Client(id).SendAsync("getuser", x);
                }
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