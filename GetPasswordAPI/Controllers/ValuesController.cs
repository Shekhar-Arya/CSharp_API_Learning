using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Ajax.Utilities;

namespace GetPasswordAPI.Controllers
{
    public class ValuesController : ApiController
    {

        static List<PasswordFactor> pass = new List<PasswordFactor>();
        
        // GET api/values
        public List<PasswordFactor> Get()
        {
            return pass;
        }

        // GET api/values/5
        public PasswordFactor Get(string pa)
        {
            PasswordFactor i = null;
            foreach(var j in pass)
            {
                if(j.passwordfor == pa)
                {
                    i = j;
                    break;
                }
            }
            return i ;
        }

        // POST api/values
        public void Post([FromBody] PasswordFactor value)
        {
            pass.Add(value);
        }

        // PUT api/values/5
        public void Put(string passfor, [FromBody] string value)
        {
            foreach(var b in pass)
            {
                if(b.passwordfor == passfor)
                {
                    b.password = value;
                    break;
                }
            }
        }

        // DELETE api/values/5
        public void Delete(string passfor)
        {
            foreach(var a in pass)
            {
                if(a.passwordfor == passfor)
                {
                    pass.Remove(a);
                    break;
                }
            }
        }
    }
}
