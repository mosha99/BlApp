using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlApp.Shared;
//using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.SignalR;
//using Microsoft.AspNet.SignalR;
//using Microsoft.AspNet.SignalR.Hubs;
namespace BlApp.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message, string to)
        {
            var _user = users.Data.FirstOrDefault(x=>x.id==user);
            var _to = users.Data.FirstOrDefault(x => x.name==to);

            if (_to != null && _user != null)
            {
                await Clients.Client(_to.id).SendAsync("ReceiveMessage", _user.name, message);
                if(_to.id!=_user.id)await Clients.Client(_user.id).SendAsync("ReceiveMessage", _user.name, message);
            }
            else
            {
                await Clients.Client(_user.id).SendAsync("ReceiveMessage", _user.name, "کاربر یافت نشد");
            }
            //await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        public async Task start(string _user, string _id)
        {
            try
            {

                if (users.Data == null) users.Data = new List<user>();

                if (users.Data.FirstOrDefault(x => x.name == _user) == null)
                {
                    users.Data.Add(new user { id = _id, name = _user });
                }
                else {users.Data.FirstOrDefault(x => x.name == _user).id = _id; }
                    
                await Clients.Client(_id).SendAsync("success", "is success");
            }
            catch(Exception ex)
            {
                await Clients.Client(_id).SendAsync("success", "is fild");
            }
        }

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
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            var x = Clients;
            var x1 = Context;
            return base.OnDisconnectedAsync(exception);
        }
        //public override Task OnDisconnectedAsync(Exception exception)
        //{

        //    return base.OnDisconnectedAsync(exception);
        //}

    }
}