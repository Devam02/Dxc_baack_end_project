
//using com.sun.org.apache.xpath.@internal.operations;
//using CsQuery.Engine.PseudoClassSelectors;
using Final_Api_Project.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
 
namespace Final_Api_Project.Controllers

{
    public class StudentsController : Controller
    {
        // GET: Students
        public object Login(string uname, string pass)
        {
            using (FinalProjectEntities c = new FinalProjectEntities())
            {
                if (c.USERSTABLEs.FirstOrDefault(p => p.User_name == uname) != null)
                {
                    if (c.USERSTABLEs.FirstOrDefault(p => p.Password == pass) != null)
                    {
                        var items = c.USERSTABLEs .Where(x => x.User_name == uname && x.Password == pass)
                        .Select(x => new
                        {
                            username = x.User_name,
                            email = x.Email
                        });

                         var  JSON = JsonConvert.SerializeObject(items);
                        return JSON;
                        
                    }
                    return false;
                }

                return false;

            }

        }
        public object register(Model m)
        {
            using (FinalProjectEntities c = new FinalProjectEntities())
            {
                USERSTABLE reg = new USERSTABLE
                {

                    User_name = m.User_name,
                    Email = m.email,
                    Password = m.password

                };
                c.USERSTABLEs.Add(reg);
                c.SaveChanges();

            }
            return true;



        }
    }


    



}

