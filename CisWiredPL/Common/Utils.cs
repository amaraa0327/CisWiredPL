using CisWiredPL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CisWiredPL.Common
{
    public class Utils
    {
        public static List<Person> getAllPeople(HttpServerUtilityBase pServer)
        {
            List<Person> result = null;
            using (StreamReader sr = new StreamReader(pServer.MapPath("~/Content/code_test.json")))
            {
                result = JsonConvert.DeserializeObject<List<Person>>(sr.ReadToEnd());
            }

            return result;
        }
    }
}