namespace OdeToFood2.Migrations
{
    using OdeToFood2.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OdeToFood2.Models.OdeToFood2Db>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OdeToFood2.Models.OdeToFood2Db context)
        {
            context.Restaurants.AddOrUpdate(r => r.Name,
                new Restaurant { Name = "Chusmita Restaurant", City = "Havana", Country = "Cuba" },
                new Restaurant { Name = "Versailles Restaurant", City = "Miami", Country = "USA" },
                new Restaurant
                {
                    Name = "Roma Pitzzeria",
                    City = "Milano",
                    Country = "Italy",
                    Reviews = new List<RestaurantReview> { 
                        new RestaurantReview { Rating = 9, Body = "Riquisimo - Delicius", ReviewerName = "Osmany San Martin" } }
                }
                );

            for (int i = 0; i < 1000; i++)
            {
                context.Restaurants.AddOrUpdate(r => r.Name,
                    new Restaurant { Name = i.ToString(), City = "Nowhere", Country = "USA" }
               );
            }
        }
    }
}
