using System;
using System.Collections.Generic;

namespace Section_02_06
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BillingCategory> categories = GetBillingCategories();

            List<BillingCategory> hierarchy = 
                BuildHierarchy(categories, catID: null, level: 0);

            PrintHierarchy(hierarchy);
        }

        static void PrintHierarchy(List<BillingCategory> hierarchy)
        {
            foreach (var cat in hierarchy)
                Console.WriteLine(cat.Name);
        }

        static List<BillingCategory> BuildHierarchy(
             List<BillingCategory> categories, int? catID, int level)
        {
            var found = new List<BillingCategory>();

            foreach (var cat in categories)
            {
                if (cat.Parent == catID)
                {
                    cat.Name = new string('\t', level) + cat.Name;
                    found.Add(cat);
                    List<BillingCategory> subCategories = 
                        BuildHierarchy(categories, cat.ID, level + 1);
                    found.AddRange(subCategories);
                }
            }

            return found;
        }

        static List<BillingCategory> GetBillingCategories()
        {
            return new List<BillingCategory>
            {
                new BillingCategory { ID = 1, Name = "First 1",  Parent = null },
                new BillingCategory { ID = 2, Name = "First 2",  Parent = null },
                new BillingCategory { ID = 4, Name = "Second 1", Parent = 1 },
                new BillingCategory { ID = 3, Name = "First 3",  Parent = null },
                new BillingCategory { ID = 5, Name = "Second 2", Parent = 2 },
                new BillingCategory { ID = 6, Name = "Second 3", Parent = 3 },
                new BillingCategory { ID = 8, Name = "Third 1",  Parent = 5 },
                new BillingCategory { ID = 8, Name = "Third 2",  Parent = 6 },
                new BillingCategory { ID = 7, Name = "Second 4", Parent = 3 },
                new BillingCategory { ID = 9, Name = "Second 5", Parent = 1 },
                new BillingCategory { ID = 8, Name = "Third 3",  Parent = 9 }
            };
        }
    }

    public class BillingCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? Parent { get; set; }
    }
}
