using CisWiredPL.Common;
using CisWiredPL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CisWiredPL.Controllers
{
    public class PeopleController : Controller
    {
        // GET: People
        public ActionResult GetAll(int pagingNo)
        {
            List<Person> allPeople = Utils.getAllPeople(Server); // retrieve all data from file using using shared static method of Utils class

            var count = (from person in allPeople
                         orderby person.age descending
                         select person)
                         .Count(); // get count. It will used on paging

            ViewBag.RecordNumber = count; // on the view RecordNumber is used on paging
            ViewBag.PagingNo = pagingNo; // on the view PagingNo is used on paging

            var allOrderedTo = (from person in allPeople
                                orderby person.age descending
                                select person)
                                .ThenBy(p => p.lastName)
                                .ThenBy(p => p.firstName)
                                .Skip((pagingNo - 1) * 100)
                                .Take(100);// get pageNo th 100 data and use linq query

            return View("PeopleList", allOrderedTo); // PeopleList view used on all actions
        }

        public ActionResult GetMenBlueEyesOver30(int pagingNo)
        {
            List<Person> allPeople = Utils.getAllPeople(Server);// retrieve all data from file using using shared static method of Utils class

            var count = (from person in allPeople
                         where person.gender == "male" 
                         && person.isActive
                         && person.eyeColor == "blue"
                         && person.age > 30
                         select person)
                         .Count();

            ViewBag.RecordNumber = count; // on the view RecordNumber is used on paging
            ViewBag.PagingNo = pagingNo; // on the view PagingNo is used on paging

            var filteredTo = (from person in allPeople
                              where person.gender == "male"
                              && person.isActive
                              && person.eyeColor == "blue"
                              && person.age > 30
                              orderby person.age descending
                              select person)
                              .ThenBy(p => p.lastName)
                              .ThenBy(p => p.firstName)
                              .Skip((pagingNo - 1) * 100)
                              .Take(100);// get pageNo th 100 data and use linq query

            return View("PeopleList", filteredTo);// PeopleList view used on all actions
        }

        public ActionResult GetLessThan3Friends(int pagingNo)
        {
            List<Person> allPeople = Utils.getAllPeople(Server);// retrieve all data from file using using shared static method of Utils class

            var count = (from person in allPeople
                         where person.friends.Count < 3
                         select person)
                         .Count();

            ViewBag.RecordNumber = count; // on the view RecordNumber is used on paging
            ViewBag.PagingNo = pagingNo; // on the view PagingNo is used on paging

            var filteredTo = (from person in allPeople
                              where person.friends.Count < 3
                              select person)
                              .Skip((pagingNo - 1) * 100)
                              .Take(100);// get pageNo th 100 data and use linq query

            return View("PeopleList", filteredTo);// PeopleList view used on all actions
        }
    }
}