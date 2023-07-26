using Library.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data
{
    public static  class DataInitializer
    { 
        public static void Seed(IApplicationBuilder app)
        {
           var context = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<LibraryDbContext>(); //app.ApplicationServices.GetRequiredService<LibraryDbContext>();

            context.Database.EnsureCreated();
            if (!context.Status.Any())
            {
                var statuses = new List<Status>
                {
                    new Status{ Name="Available"},
                    new Status { Name ="Checked Out"},
                    new Status { Name="On Hold"},
                    new Status{ Name="Lost"}
                };
                context.AddRange(statuses);
                context.SaveChanges();

                
            }
            if (!context.Branches.Any())
            {
                var branches = new List<Branch>
                    {
                        new Branch { Name = "The Historic Quincy Center Library ", Estabilished = DateTime.Now, Image = new byte(), Description="This is the oldest library in Quincy" , Location = "176 Presidents Ln, Quincy, Ma", Telephone= "774208886" },
                        new Branch { Name = "The Boston  Public Library ", Estabilished = DateTime.Now, Image = new byte(), Description="BPL Boston Public Library" , Location = "1 Boston Way, Boston, Ma", Telephone= "774208886" },
                        new Branch { Name = "The JFK Library ", Estabilished = DateTime.Now, Image = new byte(), Description="The President Library" , Location = "1 Presidents Rd, Quincy, Ma", Telephone= "774208886" },
                        new Branch { Name = "The Coop Library ", Estabilished = DateTime.Now, Image = new byte(), Description="This is the oldest library in Cambridge" , Location = "1122 Mass Ace, Cambridge, Ma", Telephone= "774208886" },
                        new Branch { Name = "The Books Library ", Estabilished = DateTime.Now, Image = new byte(), Description="This Porter Square Library" , Location = "122 Upland Rd, Porter, Ma", Telephone= "774208886" },
                        new Branch { Name = "The Drenas City Library ", Estabilished = DateTime.Now, Image = new byte(), Description="This is the oldest library in Quincy" , Location = "1 Drenica Way ,Drenas , Kosovo", Telephone= "774208886" },
                    };
                context.AddRange(branches);
                context.SaveChanges();
            }
            if(!context.AssetType.Any())
            {
                var aType = new List<AssetType>
                {
                    new AssetType { Name="Book"},
                    new AssetType { Name = "Magazine"},
                    new AssetType { Name = "Video"},
                    new AssetType { Name = "Audio"}
                };

                context.AddRange(aType);
                context.SaveChanges();
            }
        }
    }
}
