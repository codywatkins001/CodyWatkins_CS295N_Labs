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
                    BookTitle = "Prince of Foxes",
                    AuthorName = "Samuel Shellabarger",
                    ReviewText = "Great book, a must read!",
                    Reviewer = reviewer1,
                    ReviewDate = DateTime.Parse("11/1/2020")
                };
                context.Messages.Add(review);  // queues up a review to be added to the DB

                review = new Review
                {
                    BookTitle = "Virgil Wander",
                    AuthorName = "Lief Enger",
                    ReviewText = "Wonderful book, written by a distant cousin of mine.",
                    Reviewer = reviewer2,
                    ReviewDate = DateTime.Parse("11/30/2020")
                };
                context.Messages.Add(review);

                context.SaveChanges(); // stores all the Messages in the DB
            }
        }
    }
}
