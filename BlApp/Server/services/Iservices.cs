using DAl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlApp.Server.services
{
    public interface Iservices
    {
        /*Database.users GetById(int id);
        List<Database.users> getall();*/
        public List<Database.users> getall();
        public List<Database.messags> getallmessage();

        public List<Database.messags> senderM(int id);
        public List<Database.messags> inputM(int id);

        public List<Database.messags> inputM(int id, bool seen);

        public bool cheeck(int id);
        public string login(DAl.userin user);
        public int cheeckToken(string token);
        public int change(string token, string newid);
        public bool ofline(string connectionid);
        public bool online(int id);
        public sendM addmessage(int userid, string senderId, string message);
        public string getname(string senderId);
    }
}
