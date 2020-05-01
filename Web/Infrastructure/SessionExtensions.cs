﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Web.Infrastructure
{
    public static class SessionExtensions
    {
        public static void SetJson<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);

            return sessionData == null
                ? default(T) : JsonConvert.DeserializeObject<T>(sessionData);
        }


        //public static void SetJson<T>(this ISession session, string key, T value)
        //{
        //    session.SetString(key, System.Text.Json.JsonSerializer.Serialize<T>(value));
        //}

        //public static T GetJson<T>(this ISession session, string key)
        //{
        //    var value = session.GetString(key);
        //    return value == null
        //        ? default(T) : System.Text.Json.JsonSerializer.Deserialize<T>(value);
        //}
    }
}
