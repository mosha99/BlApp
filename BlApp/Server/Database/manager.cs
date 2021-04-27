using BlApp.Server.services;
using Database;
using Microsoft.EntityFrameworkCore;
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
        public static bool first = false;
        public static MessagContext Database = new MessagContext();
        public static void inc()
        {
            if (!first)
            {
                first = true;
                //Database.user.Include("messag");
                //Database.messag.Include("user");
            }

        }
        //Database.messag.Include("user");
        //    Database.user.Include("messag");
        public static List<users> getallU()
        {
            inc();
            List<users> list = Database.user.ToList();
            return list;
        }
        public static List<messags> getallM()
        {
            inc();
            List<messags> list = Database.messag.ToList();
            return list;
        }
        public static users getu(int Id)
        {
            inc();
            var user = Database.user.FirstOrDefault(x => x.id == Id);
            return user;
        }
        public static users getu(string Id)
        {
            inc();
            var user = Database.user.FirstOrDefault(x => x.connectionId == Id);
            return user;
        }
        public static List<messags> usersend(int Id)
        {
            inc();
            List<messags> list = Database.user.FirstOrDefault(x => x.id == Id).sended?.ToList();
            return list;
        }
        public static List<messags> usermessage(int Id, bool unseen)
        {
            inc();
            var x = Database.messag.ToList();
            var x3 = Database.user.ToList();
            List<messags> list = x3.FirstOrDefault(x => x.id == Id).input?.ToList();
            if (unseen) list = list.Where(x => x.seen == false)?.ToList();
            /*foreach (var item in list)
            {
                item.seen = true;
            }*/
            Database.SaveChanges();
            return list;
        }
        public static sendM addMessage(int userid, string senderId, string message)
        {
            inc();
            try
            {
                messags ms = new messags();
                ms.sender = Database.user.FirstOrDefault(s => s.connectionId == senderId);
                ms.target = Database.user.FirstOrDefault(s => s.id == userid);
                ms.messag = message;
                ms.seen = false;
                ms.sendDate = DateTime.Now;
                Database.messag.Add(ms);
                Database.SaveChanges();
                sendM user = new sendM {  Message= ms , Cid= ms.target.connectionId};
                return user;
            }
            catch
            {
                return null;
            }
        }
        public static bool adduser(users user)
        {
            inc();
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
            inc();
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
            inc();
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
            inc();
            bool unseen = false;
            var us = Database.user.FirstOrDefault(x => x.id == userid);
            int count=us.input.Where(x => x.seen == false).Count();
            if(count!=0) unseen = true;
            return true;
        }
        public static List<users> getallUseronLine()
        {
            inc();
            var list = Database.user.Where(x => x.online == true).ToList();
            return list;
        }
        public static bool Ucheeck(int userid)
        {
            inc();
            bool online=Database.user.FirstOrDefault(x => x.id == userid).online;
            return online;
        }
        public static us login(userin user)
        {
            inc();
            us use = null;
            var users = Database.user.FirstOrDefault(x => x.email == user.email);
            if (users != null && user.password==users.password) use = new us {id=users.id,email=users.email,firstname=users.firstname,lastname=users.lastname };
            return use;
        }
        public static bool changeconnectionid(int id, string newid)
        {
            inc();
            try
            {
                var user = Database.user.FirstOrDefault(x => x.id == id);
                user.connectionId = newid;
                Database.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool changeconnectionid(int id, bool online)
        {
            try
            {
                var user = Database.user.FirstOrDefault(x => x.id == id);
                user.online = online;
                if (!online) user.Lastonline = DateTime.Now;
                Database.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool changeconnectionid(string id)
        {
            try
            {
                var user = Database.user.FirstOrDefault(x => x.connectionId == id);
                if (user != null)
                {
                    user.online = false;
                    user.Lastonline = DateTime.Now;
                }

                Database.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
