using System;
using System.Data.Entity.Core;
using Moshavit.DataBase;
using Moshavit.Entity.EntityTable;
using Moshavit.Entity.TableEntity;
using Moshavit.Service;

namespace RunSettings
{
    class Program
    {
        static void Main(string[] args)
        {
            var babySitter = new BabySitterTable
            {
                Content = "Searching Baby sitter",
                EstimateTime = new DateTime(2014, 5, 10),
                Rate = 30.0,
                Subject = "looking for baby sitter",
                StartTime = new DateTime(2014, 5, 12, 20,0,0),
                Title = "Baby Sitter",
                User = new UserTable
                {
                    FirstName = "KK",
                    LastName = "ll",
                    Email = "name@domain.com",
                    Password = "1234",
                    Phone = "050-544",
                    IsActive = true,
                    StarTime = DateTime.Now

                }
            };

            try
            {
                var service = new MessageService(new Repository<MessageTable>());

                service.AddNewMessage(babySitter);
                Console.WriteLine("Finish!!!");

                //using (var context = new Context())
                //{
                //    context.Set<MessageTable>().Add(babySitter);
                //    context.SaveChanges();
                //}
                Console.WriteLine("Finish!!!");
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }

            Console.ReadLine();
        }
    }
}
