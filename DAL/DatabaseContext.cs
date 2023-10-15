using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Entity.Validation;
using System.Linq;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        //public string ip_adress { get; set; }
        //public string CurrentUser { get; set; }

        public DbSet<Author> authors { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<User> Usersss { get; set; }
        public DbSet<ActivityyyLog> ActivityyyLogs { get; set; }



        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        //public DatabaseContext(string user, string ip_address) : base("name=ContextDbContainer1")
        //{
        //    this.ip_adress = ip_address;
        //    this.CurrentUser = user;
        //}

        public override int SaveChanges()
        {
            //var modifiedEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Added |
            //                                                          e.State == EntityState.Deleted |
            //                                                          e.State == EntityState.Modified);

            //foreach (var entity in modifiedEntities)
            //{
            //    if (!(entity.Entity is ActivityLog))
            //    {
            //        var wewewe = new ActivityLog
            //        {
            //            IPAddress = ip_adress,
            //            UserName = CurrentUser,
            //            Action = entity.State.ToString(),
            //            CreatedAt = DateTime.Now,
            //            URL = ""
            //        };
            //    }
            //    var tt = entity;
            //}
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    clsUtility.WriteToFile(clsUtility.StatusLogFile(), eve.Entry.Entity.GetType().Name);

                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}
