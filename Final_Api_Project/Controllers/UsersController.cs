
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
                        var items = c.USERSTABLEs.Where(x => x.User_name == uname && x.Password == pass)
                        .Select(x => new
                        {
                            username = x.User_name,
                            email = x.Email
                        });

                        var JSON = JsonConvert.SerializeObject(items);
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
        public object placeorder(Placeordermodel p)
        {
            using (FinalProjectEntities6 c = new FinalProjectEntities6())
            {
                Orders_table reg = new Orders_table
                {

                    rupya = p.rupya,
                    pin = p.pin,
                    ph = p.ph,
                    paisa = p.paisa,
                    firstname = p.firstname,
                    lastname = p.lastname,
                    email = p.email,
                    counrycode = p.counrycode,
                    country = p.country,
                    buyerfname = p.buyerfname,
                    buyerlname = p.buyerlname,
                    address = p.address,
                    state = p.state

                };
                c.Orders_table.Add(reg);
                c.SaveChanges();

            }
            return true;
        }

        public object vieworder(string username)
        {
            using (FinalProjectEntities6 c = new FinalProjectEntities6())
            {

                var items = c.Orders_table.Where(x => x.buyerfname == username )
                        .Select(x => new
                        {
                            rupya=x.rupya,
                            ph=x.ph,
                            buyerfname=x.buyerfname,
                            firstname=x.firstname,
                            address=x.address
                            

                          
                        });

                var JSON = JsonConvert.SerializeObject(items);
                return JSON;

            }
            
        }
    }
}

