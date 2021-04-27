using BlApp.Server.infrastructure;
using BlApp.Server.infrastructure.ApplicationSetings;
using BlApp.Shared;
using DAl;
using Microsoft.AspNet.SignalR.Messaging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlApp.Server.services
{
    public class sendM
    {
        public Database.messags Message { get; set; }
        public string Cid { get; set; }
    }
    public class services : Object, Iservices
    {

        public services(Microsoft.Extensions.Options.IOptions<infrastructure.ApplicationSetings.Main> option) : base()
        {
            mainsetings = new Main { timeOut = 7*24*60, key = "fdlkgfdfdglsdflgjdflkgdfgndbljkgn" };

        }
        protected Main mainsetings { get; }

        public List<Database.users> getall()
        {
            var list = DAl.manager.getallU();
            return list;
        }
        public List<Database.messags> getallmessage()
        {
            var list = DAl.manager.getallM();
            return list;
        }

        public List<Database.messags> senderM(int id)
        {
            var m = DAl.manager.usersend(id);
            return m;
        }
        public List<Database.messags> inputM(int id)
        {
            var m = DAl.manager.usermessage(id, false);
            return m;
        }

        public List<Database.messags> inputM(int id, bool seen)
        {
            var m = DAl.manager.usermessage(id, true);
            return m;
        }

        public bool cheeck(int id)
        {
            var ch = DAl.manager.check(id);
            return ch;
        }
        public string login(DAl.userin user)
        {
            string token = null;
            us id = DAl.manager.login(user);
            if (id != null) { token = BlApp.Server.infrastructure.jwtUtility.generateToken(id, mainsetings); }
            return token;
        }
        public int cheeckToken(string token)
        {
            int id = jwtUtility.auth(token, mainsetings);
            return id;
        }
        public int change(string token, string newid)
        {
            try
            {
                int id = cheeckToken(token);
                bool x;
                if (id != -1)
                {
                    x = DAl.manager.changeconnectionid(id, newid);
                    online(id);
                }

                else return id;
                return id;
            }
            catch
            {
                return -1;
            }
        }
        public bool online(int id)
        {
            try
            {
                DAl.manager.changeconnectionid(id, true);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ofline(string connectionid)
        {
            try
            {
                DAl.manager.changeconnectionid(connectionid);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public sendM addmessage(int userid, string senderId, string message)
        {
            sendM connectionid = DAl.manager.addMessage( userid , senderId , message);
            return connectionid;
        }

        public string getname(string senderId)
        {
            var user =DAl.manager.getu(senderId);
            return user.firstname + " " + user.lastname;
        }



        /* public Database.users GetById(int id)
         {
             throw new NotImplementedException();
         }*/
    }
}
