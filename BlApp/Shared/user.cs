using System;
using System.Collections.Generic;
using System.Text;

namespace BlApp.Shared
{
    public class userout
    {
        
        public string token { get; set; }

    }
    public class userin
    {
        public string email { get; set; }
        public string password { get; set; }

    }
    public class signin : Isignin
    {
        public string firsname  { get; set; }
        public string lastname  { get; set; }
        public string email     { get; set; }
        public string password  { get; set; }
        public string Cpassword { get; set; }

    }
    public class Esignin : Isignin
    {
        public string firsname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string Cpassword { get; set; }
        public string Efirsname { get; set; }
        public string Elastname { get; set; }
        public string Eemail { get; set; }
        public string Epassword { get; set; }
        public string ECpassword { get; set; }
    }
    public interface Isignin
    {
        string firsname { get; set; }
        string lastname { get; set; }
        string email { get; set; }
        string password { get; set; }
        string Cpassword { get; set; }

    }
    public class messageL
    {
        public string message { get; set; }
        public DateTime date { get; set; }
        public bool seen { get; set; }
        public string name { get; set; }
        public int  id { get; set; }
        public int Mid { get; set; }
        public string tname { get; set; }
    }
    public class chats
    {   
        public int id { get; set; }
        public string name { get; set; }
        public int unSeenCount { get; set; }
    }
    public class user
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}

