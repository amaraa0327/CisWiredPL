using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CisWiredPL.Models
{
    public class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public bool isActive { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public string eyeColor { get; set; }
        public List<string> friends { get; set; }
    }
}