using CoolCarClub.Models;
using System;

namespace CoolCarClub.Data
{
    public class SeedData
    {
        public static void Seed(CoolCarClubDbContext context)
        {
            if (!context.Messages.Any())  // this is to prevent adding duplicate data
            {
                // Create AppUser objects
                AppUser user1 = new AppUser { Name = "Emma Watson" };
                AppUser user2 = new AppUser { Name = "Cody Watkins" };
                // Queue up AppUser objects to be saved to the DB
                context.AppUsers.Add(user1);
                context.AppUsers.Add(user2);
                context.SaveChanges();  // Saving adds AppUserId to AppUser objects

                Message message = new Message
                {
                    Text = "Hello, this is a message from Emma to Cody.",
                    From = user1,
                    To = user2,
                    Date = DateOnly.FromDateTime(DateTime.Now)
                };

                context.Messages.Add(message);  // queues up a message to be added to the DB

                message = new Message
                {
                    Text = "Hi Emma, this is Cody. Nice to hear from you!",
                    From = user2,
                    To = user1,
                    Date = DateOnly.FromDateTime(DateTime.Now)
                };
                
                context.Messages.Add(message);

                context.SaveChanges(); // stores all the Messages in the DB
            }
        }
    }
}
