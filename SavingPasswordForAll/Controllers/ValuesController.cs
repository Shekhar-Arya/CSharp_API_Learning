using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SavingPasswordForAll.Controllers
{
    public class ValuesController : ApiController
    {
        static List<User> userAndpassword = new List<User>();
        // GET api/values
        public List<User> Get()
        {
            return userAndpassword;
        }

        // GET api/values/5
        public List<PasswordSaver> Get(string na)
        {
            var b = new List<PasswordSaver>();
            foreach(var a in userAndpassword)
            {
                if(a.name == na)
                {
                    b = a.passwordSaver;
                    break;
                }
            }
            return b;
        }

        // POST api/values
        public void Post(string na, [FromBody] PasswordSaver value)
        {
            bool x = true;
            foreach(var a in userAndpassword)
            {
                if (a.name == na)
                {
                    x = false;
                    a.passwordSaver.Add(value);
                }
            }
            if (x == true) 
            {
                User u = new User();
                u.name = na;
                u.passwordSaver.Add(value);
                userAndpassword.Add(u);
            }
        }

        // PUT api/values/5
        public void Put(string na, string web,[FromBody] string value)
        {
            foreach(var a in userAndpassword)
            {
                if(a.name == na)
                {
                    foreach(var b in a.passwordSaver)
                    {
                        if(b.website==web)
                        {
                            b.password = value;
                        }
                    }
                }
            }
        }

        // DELETE api/values/5
        public void Delete(string na, string web)
        {
            foreach(var a in userAndpassword)
            {
                if(a.name == na)
                {
                    foreach(var b in a.passwordSaver)
                    {
                        if(b.website == web)
                        {
                            a.passwordSaver.Remove(b);
                            break;
                        }
                    }
                    break;
                }
            }
        }
    }
}
