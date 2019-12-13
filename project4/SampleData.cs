using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project4.Models
{
    public class SampleData
    {
        public static void Initialize(DiscContext context)
        {
           
            if (!context.Discs.Any()) {
                context.Discs.AddRange(
                    new Disc {
                        Name = "Red",
                        Artist = "FireGuy",
                        Count = 6
                    },
                    new Disc {
                        Name = "Black",
                        Artist = "NiggaGuy",
                        Count = 10
                    },
                    new Disc {
   
                        Name = "Yellow",
                        Artist = "SunGuy",
                        Count = 12
                    }
                ); 
                context.SaveChanges();
            }

            if (!context.Artists.Any()) {
                context.Artists.AddRange(
                    new Artist {
                        Name = "RedGuy",
                        Country = "Russia",
                       
                    },
                    new Artist {
                        Name = "YellowGuy",
                        Country = "China",
                    },
                    new Artist {

                        Name = "WhiteGuy",
                        Country = "USA",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
