using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Config
{
    public class APIConfig
    {
        public static string ApiDomain = "https://music-i-like.herokuapp.com/api";
        public static string AccountPath = "/api/v1/accounts";
        public static string SongPath = "/api/v1/songs";
        public static string MySongPath = "/api/v1/songs/mine";
        public static string AuthenticationPath = "/api/v1/accounts/authentication";
        public static string MediaType = "application/json";
    } 
}
