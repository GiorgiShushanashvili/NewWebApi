using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Week14.Model;


namespace Week14.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class FirstController : Controller
    {
        [HttpPost("adduser")]

        public IActionResult AddUser(Person person)
        {

            var personlist = new List<Person>
            {
                new Person
                {
                    createtime = DateTime.Now,
                    firstname = "David",
                    lastname = "white",
                    jobposition = "doctor",
                    salary = 2500,
                    workexperience = 2,
                    personaddress =  new Address {country = "USA",
                    city = "New York", homenumber = 31,
                    } },
                    new Person
                    { createtime = DateTime.Now,
                    firstname = "Lebron",
                    lastname = "James",
                    jobposition = "basketball player",
                    salary = 4000,
                    workexperience = 5,
                    personaddress = new Address {country = "USA",
                    city = "Los Angeles", homenumber = 21} }


                };

            personlist.Add(person);

            return Accepted(personlist);
        }




        [HttpGet("list/person")]
        public IActionResult Getallusers(Person person)
        {
            var personlist = new List<Person>
            {
                new Person()
                {
                    createtime = DateTime.Now,
                    firstname = "David",
                    lastname = "white",
                    jobposition = "doctor",
                    salary = 2500,
                    workexperience = 2,
                    personaddress =  new Address {country = "USA",
                    city = "New York", homenumber = 31
                    } },
                    new Person()
                    { createtime = DateTime.Now,
                    firstname = "Lebron",
                    lastname = "James",
                    jobposition = "basketball player",
                    salary = 4000,
                    workexperience = 5,
                    personaddress = new Address {country = "USA",
                    city = "Los Angeles", homenumber = 21} }
     };
            return Accepted(personlist);

        }

        [HttpGet("person/{id}")]
        public IActionResult GetUserById(int id)
        {
            var personlist = new List<Person>
            {
                new Person()
                {
                    createtime = DateTime.Now,
                    firstname = "David",
                    lastname = "white",
                    jobposition = "doctor",
                    salary = 2500,
                    workexperience = 2,
                    personaddress =  new Address{country = "USA",
                    city = "New York", homenumber = 31
                    } },
                    new Person()
                    { createtime = DateTime.Now,
                    firstname = "Lebron",
                    lastname = "James",
                    jobposition = "basketball player",
                    salary = 4000,
                    workexperience = 5,
                    personaddress = new Address {country = "USA",
                    city = "Los Angeles", homenumber = 21} }
                  };
            return Accepted(personlist[id]);

        }

        [HttpGet("userfilter")]
        public IActionResult FilteredUser([FromQuery] Person person)
        {
            var personlist = new List<Person>
            {
                new Person()
                {
                    createtime = DateTime.Now,
                    firstname = "David",
                    lastname = "white",
                    jobposition = "doctor",
                    salary = 2500,
                    workexperience = 2,
                    personaddress = new Address { country = "USA",
                        city = "New York", homenumber = 31
                    } },
                new Person()
                { createtime = DateTime.Now,
                    firstname = "Lebron",
                    lastname = "James",
                    jobposition = "basketball player",
                    salary = 4000,
                    workexperience = 5,
                    personaddress = new Address { country = "USA",
                        city = "Los Angeles", homenumber = 21 } }

            };
            return Accepted(personlist.Where
                (x => x.personaddress.city == person.personaddress.city || x.salary == person.salary));
                }


        [HttpDelete("deleteperson/{listindex}")]
        public IActionResult DeleteUser(int listindex)
        {
            var personlist = new List<Person>
            {
                new Person()
                {
                    createtime = DateTime.Now,
                    firstname = "David",
                    lastname = "white",
                    jobposition = "doctor",
                    salary = 2500,
                    workexperience = 2,
                    personaddress = new Address {country = "USA",
                    city = "New York", homenumber = 31
                    } },
                new Person()
                    { createtime = DateTime.Now,
                    firstname = "Lebron",
                    lastname = "James",
                    jobposition = "basketball player",
                    salary = 4000,
                    workexperience = 5,
                    personaddress = new Address {country = "USA",
                    city = "Los Angeles", homenumber = 21} }
                  };



            personlist.RemoveAt(listindex);
            if (personlist.Count == 2)
            {
                return BadRequest("Sorry, user was not deleted");
            }
            else
            {
                return Ok(personlist);
            }

        }

        [HttpPut("updateperson/{id}")]
        public IActionResult ReplacePerson(Person person, int id)
        {
            var personlist = new List<Person>
            {
                new Person()
                {
                    createtime = DateTime.Now,
                    firstname = "David",
                    lastname = "white",
                    jobposition = "doctor",
                    salary = 2500,
                    workexperience = 2,
                    personaddress = new Address {country = "USA",
                    city = "New York", homenumber = 31
                    } },
                new Person()
                    { createtime = DateTime.Now,
                    firstname = "Lebron",
                    lastname = "James",
                    jobposition = "basketball player",
                    salary = 4000,
                    workexperience = 5,
                    personaddress = new Address {country = "USA",
                    city = "Los Angeles", homenumber = 21} }
                  };
            personlist[id].firstname = person.firstname;
            personlist[id].lastname = person.lastname;
            personlist[id].jobposition = person.jobposition;
            personlist[id].salary = person.salary;
            personlist[id].workexperience = person.workexperience;
            personlist[id].personaddress.city = person.personaddress.city;
            personlist[id].personaddress.country = person.personaddress.country;
            personlist[id].personaddress.homenumber = person.personaddress.homenumber;

            return Accepted(personlist);



        }
    }
}

