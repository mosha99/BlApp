using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAl
{
    public class userin
    {
        public string email { get; set; }
        public string password { get; set; }

    }
    public class us
    {
        public int id { get; set; }
        public string firstname { set; get; }
        public string lastname { set; get; }
        public string email { set; get; }
        public DateTime start { set; get; }
    }

    public class manager
    {
        public static MessagContext Database= new MessagContext();
        //Database.messag.Include("user");
        //    Database.user.Include("messag");
        public static List<users> getallU()
        {
            List<users> list = Database.user.ToList();
            return list;
        }
        public static List<messags> getallM()
        {
            List<messags> list = Database.messag.ToList();
            return list;
        }
        public static List<messags> usersend(int Id)
        {
            List<messags> list = Database.user.FirstOrDefault(x => x.id == Id).sended.ToList();
            return list;
        }
        public static List<messags> usermessage(int Id, bool unseen)
        {
            List<messags> list = Database.user.FirstOrDefault(x => x.id == Id).input.ToList();
            if (unseen) list = list.Where(x => x.seen == false).ToList();
            foreach (var item in Database.user.FirstOrDefault(x => x.id == Id).input.Where(x => x.seen == false))
            {
                item.seen = true;
            }
            Database.SaveChanges();
            return list;
        }
        public static bool addMessage(int userid, int senderId, string message)
        {
            try
            {
                messags ms = new messags();
                ms.sender = Database.user.FirstOrDefault(s => s.id == senderId);
                ms.target = Database.user.FirstOrDefault(s => s.id == userid);
                ms.messag = message;
                ms.seen = false;
                ms.sendDate = DateTime.Now;
                Database.messag.Add(ms);
                Database.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool adduser(users user)
        {
            try
            {
                Database.user.Add(user);
                Database.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool DeletMessage(int Messagid)
        {

            try
            {
                var ms = Database.messag.FirstOrDefault(x => x.id == Messagid);
                var mu = ms.sender.sended.FirstOrDefault(x => x.id == Messagid);
                var msu = ms.sender.input.FirstOrDefault(x => x.id == Messagid);
                Database.messag.Remove(mu);
                Database.messag.Remove(msu);
                Database.messag.Remove(ms);
                Database.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool Deletuser(int userid)
        {
            try
            {
                var us = Database.user.FirstOrDefault(x => x.id == userid);
                var mu = us.input;
                var msu = us.sended;
                Database.messag.RemoveRange(mu);
                Database.messag.RemoveRange(msu);
                Database.user.Remove(us);
                Database.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool check(int userid)
        {
            bool unseen = false;
            var us = Database.user.FirstOrDefault(x => x.id == userid);
            int count=us.input.Where(x => x.seen == false).Count();
            if(count!=0) unseen = true;
            return true;
        }
        public static List<users> getallUseronLine()
        {
            var list = Database.user.Where(x => x.online == true).ToList();
            return list;
        }
        public static bool Ucheeck(int userid)
        {
            bool online=Database.user.FirstOrDefault(x => x.id == userid).online;
            return online;
        }
        public static us login(userin user)
        {
            us use = null;
            var users = Database.user.FirstOrDefault(x => x.email == user.email);
            if (users != null) use = new us {id=users.id,email=users.email,firstname=users.firstname,lastname=users.lastname };
            return use;
        }
    }
}
