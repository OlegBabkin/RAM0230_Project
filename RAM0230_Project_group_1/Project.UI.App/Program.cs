using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Domain.Core;
using Project.Domain.Repository;
using Project.Infrastructure.Database.Connection;
using Project.Infrastructure.Database.DataAccess;

namespace Project.UI.App
{
    class Program
    {
        private static IUnitOfWork uow = new UnitOfWork(new KolledzDBContext());
        static void Main(string[] args)
        {
            int sel;
            User user = null;
            do
            {
                sel = UsersMenu();
                
                switch (sel)
                {
                    case 1:
                        foreach (var item in uow.Users.GetAllEntries().ToList())
                        {
                            Console.WriteLine("[{0}] {1} {2}. Role: {3}; Email: {4} ", item.Id, item.Name, item.Lastname, item.Role.Name, item.Email);
                        }
                        break;
                    case 2:
                        foreach (var item in uow.Users.GetAllEntries().ToList())
                        {
                            Console.WriteLine("[{0}]", item.Email);
                        }
                        break;
                    case 3:
                        foreach (var item in uow.Users.FindBy(u => u.Role.Name.Equals("teacher")).ToList())
                        {
                            Console.WriteLine("[{0}] {1} {2}. Role: {3};", item.Id, item.Name, item.Lastname, item.Role.Name);
                        }
                        break;
                    case 4:
                        user = new User();
                        Console.Write("Name: ");
                        user.Name = Console.ReadLine();
                        Console.Write("Lastname: ");
                        user.Lastname = Console.ReadLine();
                        user.Login = user.Name + user.Lastname;
                        user.Password = "12345678";
                        user.Role = uow.Roles.GetByKey(4);
                        user.Email = user.Name + user.Lastname + "@student.ee";

                        uow.Users.Insert(user);
                        uow.Save();
                        break;
                    case 5:
                        if (user == null) { Console.WriteLine("Nothing to delete!"); }
                        else
                        {
                            string str = String.Format("User: {0} {1} has been deleted", user.Name, user.Lastname);
                            uow.Users.Delete(user);
                            uow.Save();
                            user = null;
                        }
                        
                        break;

                    case 6:
                        foreach (var subject in uow.Subjects.GetAllEntries())
                        {
                            Console.WriteLine(subject.Code);
                            foreach (var group in subject.Groups)
                            {
                                Console.WriteLine("\t" + group.GroupCode);
                                foreach (var item in group.Students)
                                {
                                    Console.WriteLine("\t\t" + item.Code + "| " + item.Lastname);
                                    subject.Students.Add(item);
                                }
                            }
                        }
                        //uow.Save();
                        Console.WriteLine("all done!");
                        break;
                    default:
                        break;
                }
            } while (sel != 0);
            if (uow != null)
            {
                uow.Dispose();
            }
        }

        private static int UsersMenu()
        {
            string[] menuItems = { "1. Show Users", "2. Show Emails", "3. Show Teachers", "4. Add User", "5. Delete User", "6. Update", "0. Exit" };
            Console.WriteLine();
            foreach (var item in menuItems)
            {
                Console.WriteLine(item);
            }
            Console.Write("Choose menu selection: ");
            int sel = 0;
            bool result = Int32.TryParse(Console.ReadLine(), out sel);
            if (!result) { throw new Exception("Wrong selection"); }
            return sel;
        }
    }
}
