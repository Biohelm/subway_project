using subway_project.Server.Data;
using subway_project.Server.Models;

namespace subway_project.Server
{
    public class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {



            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category { Name = "Specials" },
                    new Category { Name = "Sub" },
                    new Category { Name = "Drinks" },
                    new Category { Name = "Snacks" },
                    new Category { Name = "Desserts" }
                );

                context.SaveChanges();
            }

            if (!context.SubCategories.Any())
            {

                context.SubCategories.AddRange(
                    new SubCategory { Name = "Bread", CategoryId = 2 },
                    new SubCategory { Name = "Proteins", CategoryId = 2 },
                    new SubCategory { Name = "Vegetables", CategoryId = 2 },
                    new SubCategory { Name = "Sauces", CategoryId = 2 },
                    new SubCategory { Name = "Cheese", CategoryId = 2 },
                    new SubCategory { Name = "Carbonated", CategoryId = 3 },
                    new SubCategory { Name = "Non Carbonated", CategoryId = 3 },
                    new SubCategory { Name = "Chips", CategoryId = 4 },
                    new SubCategory { Name = "Cookies", CategoryId = 4 },
                    new SubCategory { Name = "Ice-Cream", CategoryId = 5 },
                    new SubCategory { Name = "Pies", CategoryId = 5 }
                    );

                context.SaveChanges();

            }

            if (!context.Products.Any())
            {
                context.Products.AddRange(

                    new Product { Name = "White Bread", Price = 15.00m, SubCategoryId = 1, CategoryId = 2, ImageUrl = "https://okfrozendough.com/wp-content/uploads/2019/10/OK340_9_inc_white_bun.jpg", Calories = 400, Protein = 12, Carbohydrates = 68, Fat = 4, Fiber = 2, Salt = 0.62 },
                    new Product { Name = "Whole Wheat Bread", Price = 20.00m, SubCategoryId = 1, CategoryId = 2, ImageUrl = "https://okfrozendough.com/wp-content/uploads/2019/10/OK345_9_inc_ww_sub_bun.jpg", Calories = 420, Protein = 16, Carbohydrates = 72, Fat = 4, Fiber = 8, Salt = 0.62 },
                    new Product { Name = "Light Bread", Price = 18.00m, SubCategoryId = 1, CategoryId = 2, ImageUrl = "https://www.seasonsandsuppers.ca/wp-content/uploads/2022/09/sub-rolls-4-3-3.jpg", Calories = 300, Protein = 14, Carbohydrates = 62, Fat = 4, Fiber = 4, Salt = 0.62 },
                    new Product {Name = "Cheese Bread", Price = 33.00m, SubCategoryId = 1, CategoryId = 2, ImageUrl = "https://cdn.vox-cdn.com/thumbor/v5MOxdUdtffU4E1zkMM80jetZ2c=/0x0:1080x1350/1200x800/filters:focal(477x802:649x974)/cdn.vox-cdn.com/uploads/chorus_image/image/72447167/358101373_292422893350341_630677683818333789_n.0.jpg", Calories = 440, Protein = 18, Carbohydrates = 74, Fat = 10, Fiber = 4, Salt = 1.05 },

                    new Product { Name = "Ham", Price = 15.00m, SubCategoryId = 2, CategoryId = 2, ImageUrl = "https://www.shutterstock.com/shutterstock/videos/1105399823/thumb/1.jpg?ip=x480", Calories = 13, Protein = 2.1, Carbohydrates = 0, Fat = 0.4, Fiber = 0.1, Salt = 0.1 },
                    new Product { Name = "Turkey", Price = 20.00m, SubCategoryId = 2, CategoryId = 2, ImageUrl = "https://t3.ftcdn.net/jpg/02/87/06/90/360_F_287069085_cSzPLAoux5MSAeETX4Pwhdxa5gxrbqf4.jpg", Calories = 30, Protein = 4, Carbohydrates = 0, Fat = 0.3, Fiber = 0.1, Salt = 0.6 },
                    new Product { Name = "Beef", Price = 30.00m, SubCategoryId = 2, CategoryId = 2, ImageUrl = "https://media.istockphoto.com/id/535786572/photo/grilled-striploin-steak.jpg?s=612x612&w=0&k=20&c=F_vrvwIOWe3vBR2y16Dp4z6d46K1sIY3togU3VYjrpA=", Calories = 50, Protein = 11, Carbohydrates = 0, Fat = 6, Fiber = 0, Salt = 0.55 },
                    new Product { Name = "Chicken", Price = 25.00m, SubCategoryId = 2, CategoryId = 2, ImageUrl = "https://www.everyday-delicious.com/wp-content/uploads/2021/03/chicken-spread-pasta-z-kurczaka-everyday-delicious-1.jpg", Calories = 40, Protein = 7, Carbohydrates = 1, Fat = 1, Fiber = 0, Salt = 0.2 },
                    new Product { Name = "Vegetarian", Price = 18.00m, SubCategoryId = 2, CategoryId = 2, ImageUrl = "https://cheapandcheerfulcooking.com/wp-content/uploads/2021/02/muhammara-red-pepper-walnut-dip-1.jpg", Calories = 25, Protein = 10, Carbohydrates = 2, Fat = 0, Fiber = 3, Salt = 0.77 },
                    new Product { Name = "Tuna", Price = 22.00m, SubCategoryId = 2, CategoryId = 2, ImageUrl = "https://www.goodnesst.com/wp-content/uploads/2019/12/easy-tuna-spread-recipe-2.jpg", Calories = 15, Protein = 13, Carbohydrates = 2, Fat = 2, Fiber = 1, Salt = 1.23 },
                    new Product { Name = "Chicken Breast", Price = 25.00m, SubCategoryId = 2, CategoryId = 2, ImageUrl = "https://i2.wp.com/www.downshiftology.com/wp-content/uploads/2023/01/Air-Fryer-Chicken-Breast-7.jpg", Calories = 25, Protein = 9, Carbohydrates = 0, Fat = 3, Fiber = 1, Salt = 0.66 },
                    new Product { Name = "Steak", Price = 30.00m, SubCategoryId = 2, CategoryId = 2, ImageUrl = "https://i.redd.it/03zxsyqc6otb1.jpg", Calories = 27, Protein = 11, Carbohydrates = 0, Fat = 2, Fiber = 2, Salt = 0.61 },
                    new Product { Name = "Tofu", Price = 18.00m, SubCategoryId = 2, CategoryId = 2, ImageUrl = "https://alegumeaday.com/wp-content/uploads/2021/08/Creamy-sun-dried-tomato-tofu-spread-A-Legume-a-Day-20210805-1.jpg", Calories = 27, Protein = 4, Carbohydrates = 1, Fat = 2.5, Fiber = 1, Salt = 0.04 },

                    new Product { Name = "Tomato", Price = 5.00m, SubCategoryId = 3, CategoryId = 2, ImageUrl = "https://m.economictimes.com/thumb/msid-95423731,width-1200,height-900,resizemode-4,imgsize-56196/tomatoes-canva.jpg", Calories = 19, Protein = 0.7, Carbohydrates = 3.9, Fat = 0.2, Fiber = 1.0, Salt = 0.00 },
                    new Product { Name = "Onion", Price = 3.00m, SubCategoryId = 3, CategoryId = 2, ImageUrl = "https://ih1.redbubble.net/image.3804311069.0627/raf,360x360,075,t,fafafa:ca443f4786.jpg", Calories = 40, Protein = 1.1, Carbohydrates = 9.3, Fat = 0.1, Fiber = 1.7, Salt = 0.00 },
                    new Product { Name = "Bell Pepper", Price = 6.00m, SubCategoryId = 3, CategoryId = 2, ImageUrl = "https://www.chilipeppermadness.com/wp-content/uploads/2024/02/Bell-Peppers1.jpg", Calories = 20, Protein = 0.9, Carbohydrates = 4.6, Fat = 0.2, Fiber = 1.7, Salt = 0.00 },
                    new Product { Name = "Cucumber", Price = 4.00m, SubCategoryId = 3, CategoryId = 2, ImageUrl = "https://snaped.fns.usda.gov/sites/default/files/styles/crop_ratio_7_5/public/seasonal-produce/2018-05/cucumbers2.jpg.webp?itok=Y2CZseBE", Calories = 16, Protein = 0.7, Carbohydrates = 3.6, Fat = 0.2, Fiber = 0.5, Salt = 0.00 },
                    new Product { Name = "Spinach", Price = 5.00m, SubCategoryId = 3, CategoryId = 2, ImageUrl = "https://bedford.tennessee.edu/wp-content/uploads/sites/162/2020/08/spinach-leaves-1024x593.jpg", Calories = 23, Protein = 2.9, Carbohydrates = 3.6, Fat = 0.4, Fiber = 2.2, Salt = 0.00 },

                    new Product { Name = "Mayonnaise", Price = 5.00m, SubCategoryId = 4, CategoryId = 2, ImageUrl = "https://media.istockphoto.com/id/507636140/photo/homemade-mayonnaise.jpg?s=612x612&w=0&k=20&c=Yo39cXtQ0x4uRJbRKMo__9ppA-BKcLI82PbMcn4aweo=", Calories = 714, Protein = 0.0, Carbohydrates = 0.0, Fat = 78.6, Fiber = 0.0, Salt = 0.46 },
                    new Product { Name = "Mustard", Price = 4.00m, SubCategoryId = 4, CategoryId = 2, ImageUrl = "https://www.realsimple.com/thmb/vPbhjHFdv4Ta_YuujhhHSzsKPL8=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/homemade-mustard-2000-178458cea0514bdfa3bcfb4cd499612b.jpg", Calories = 71, Protein = 0.0, Carbohydrates = 7.1, Fat = 7.1, Fiber = 0.0, Salt = 1.21 },
                    new Product { Name = "Barbecue Sauce", Price = 6.00m, SubCategoryId = 4, CategoryId = 2, ImageUrl = "https://www.allrecipes.com/thmb/N3b7R0ApzKN6q0RRLQdmb6KPegQ=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/51226-a-very-popular-bbq-sauce-DDMFS-4x3-c6e3230c5df240b4937385141cce0b67.jpg", Calories = 167, Protein = 0.0, Carbohydrates = 43, Fat = 0.0, Fiber = 0.0, Salt = 0.81 },
                    new Product { Name = "Sweet Chili", Price = 6.00m, SubCategoryId = 4, CategoryId = 2, ImageUrl = "https://www.foxyfolksy.com/wp-content/uploads/2021/10/sweet-chili-sauce-1200t.jpg", Calories = 143, Protein = 0.0, Carbohydrates = 43, Fat = 0.0, Fiber = 0.0, Salt = 0.76 },
                    new Product { Name = "Ranch Sauce", Price = 5.00m, SubCategoryId = 4, CategoryId = 2, ImageUrl = "https://taoofspice.com/wp-content/uploads/2022/01/Close-up-of-garlic-ranch-dip-with-carrots-surrounding-it-683x1024.jpg.webp", Calories = 421, Protein = 0.0, Carbohydrates = 7, Fat = 42.1, Fiber = 0.0, Salt = 0.96 },

                    new Product { Name = "Cheddar", Price = 10.00m, SubCategoryId = 5, CategoryId = 2, ImageUrl = "https://images3.alphacoders.com/665/665670.jpg", Calories = 403, Protein = 22.9, Carbohydrates = 3.4, Fat = 33.3, Fiber = 0, Salt = 0.65 },
                    new Product { Name = "Mozzarella", Price = 12.00m, SubCategoryId = 5, CategoryId = 2, ImageUrl = "https://www.shutterstock.com/shutterstock/videos/3391081405/thumb/3.jpg?ip=x480", Calories = 280, Protein = 28, Carbohydrates = 3.1, Fat = 17, Fiber = 0, Salt = 0.02 },
                    new Product { Name = "Hard Cheese", Price = 14.00m, SubCategoryId = 5, CategoryId = 2, ImageUrl = "https://www.shutterstock.com/shutterstock/videos/3665506537/thumb/1.jpg?ip=x480", Calories = 431, Protein = 28, Carbohydrates = 3, Fat = 36, Fiber = 0, Salt = 1.6 },

                    new Product { Name = "Coca-Cola", Price = 15.00m, SubCategoryId = 6, CategoryId = 3, ImageUrl = "https://www.shutterstock.com/shutterstock/videos/1065268699/thumb/1.jpg?ip=x480", Calories = 139, Protein = 0, Carbohydrates = 35, Fat = 0, Fiber = 0, Salt = 0.01 },
                    new Product { Name = "Fanta", Price = 15.00m, SubCategoryId = 6, CategoryId = 3, ImageUrl = "https://t4.ftcdn.net/jpg/03/57/78/97/360_F_357789751_uno2v0tEYXqgPW1AGcXsVWLqSRp9Q5bA.jpg", Calories = 142, Protein = 0, Carbohydrates = 35, Fat = 0, Fiber = 0, Salt = 0.00 },
                    new Product { Name = "Sprite", Price = 15.00m, SubCategoryId = 6, CategoryId = 3, ImageUrl = "https://www.hdwallpapers.in/download/sprite_pouring_on_glass_hd_sprite_cranberry-HD.jpg", Calories = 62, Protein = 0, Carbohydrates = 14.5, Fat = 0, Fiber = 0, Salt = 0.13 },

                    new Product { Name = "Water", Price = 10.00m, SubCategoryId = 7, CategoryId = 3, ImageUrl = "https://media.gettyimages.com/id/1243369052/sv/video/tr%C3%A4dg%C3%A5rdsslang-vattning-en-lummig-gr%C3%B6n-tr%C3%A4dg%C3%A5rd.jpg?s=640x640&k=20&c=uepVUNvnv1DO0sKeEC4j0LV_GVY0UtgEsQBmE0ymSFk=", Calories = 0, Protein = 0, Carbohydrates = 0, Fat = 0, Fiber = 0, Salt = 0.00 },

                    new Product { Name = "Lays Original", Price = 10.00m, SubCategoryId = 8, CategoryId = 4, ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/69/Potato-Chips.jpg/960px-Potato-Chips.jpg", Calories = 220, Protein = 2, Carbohydrates = 21, Fat = 14, Fiber = 1, Salt = 0.27 },
                    new Product { Name = "Lays Paprika", Price = 10.00m, SubCategoryId = 8, CategoryId = 4, ImageUrl = "https://www.shutterstock.com/image-photo/bbq-potato-chips-on-white-600nw-1054938998.jpg", Calories = 201, Protein = 3, Carbohydrates = 23, Fat = 11, Fiber = 0, Salt = 0.13 },

                    new Product { Name = "Chocolate Chip Cookies", Price = 12.00m, SubCategoryId = 9, CategoryId = 4, ImageUrl = "https://media.istockphoto.com/id/1411089766/sv/foto/pile-of-homemade-cookies.jpg?s=612x612&w=0&k=20&c=F6WFEHfumZI0EENWVYNZZu9B0jVAvJgI7JqDg1BlgDc=", Calories = 220, Protein = 2, Carbohydrates = 30, Fat = 10, Fiber = 1, Salt = 0.13 },
                    new Product { Name = "Cookie", Price = 10.00m, SubCategoryId = 9, CategoryId = 4, ImageUrl = "https://krollskorner.com/wp-content/uploads/2023/10/Chocolate-Chipless-Cookies_LowRes-017-1.jpg", Calories = 220, Protein = 2, Carbohydrates = 29, Fat = 10, Fiber = 1, Salt = 0.1 },
                    new Product { Name = "Brownie", Price = 15.00m, SubCategoryId = 9, CategoryId = 4, ImageUrl = "https://shared.cdn.smp.schibsted.com/v2/images/66339597-1216-4afb-b5ff-0a550ccf7ecf?fit=crop&h=1426&w=1900&s=a52df5a58314385584212b791d039917dd56d58d", Calories = 350, Protein = 4, Carbohydrates = 45, Fat = 18, Fiber = 2, Salt = 0.3 },

                    new Product { Name = "Ice Cream", Price = 20.00m, SubCategoryId = 10, CategoryId = 5, ImageUrl = "https://shared.cdn.smp.schibsted.com/v2/images/539eab90-b586-4397-8331-fe1c304d202b?fit=crop&h=1425&w=1900&s=f1969e391b4d00af2bb88340ffae4edbf37637c5", Calories = 207, Protein = 3.5, Carbohydrates = 24, Fat = 11, Fiber = 0, Salt = 0.1 },

                    new Product { Name = "Apple Pie", Price = 18.00m, SubCategoryId = 11, CategoryId = 5, ImageUrl = "https://media.istockphoto.com/id/450752471/sv/foto/homemade-organic-apple-pie-dessert.jpg?s=612x612&w=0&k=20&c=Lw-t-f6DoNwerNFNTdQ9emEhcCcD7aPIBAf5nLhWDNw=", Calories = 296, Protein = 2, Carbohydrates = 42, Fat = 14, Fiber = 2, Salt = 0.4 },
                    new Product { Name = "Cheesecake", Price = 22.00m, SubCategoryId = 11, CategoryId = 5, ImageUrl = "https://images3.alphacoders.com/600/600689.jpg", Calories = 321, Protein = 5, Carbohydrates = 25, Fat = 23, Fiber = 0, Salt = 0.3 }
                );

                context.SaveChanges();
            }

            //if (!context.Orders.Any())
            //{
            //    context.Orders.AddRange(

            //        new Order
            //        {
            //            TakeAway = true,
            //            TotalPrice = 300,
            //            Products = new List<Product> { context.Products.FirstOrDefault(p => p.Name == "Coca-Cola")!, context.Products.FirstOrDefault(p => p.Name == "Lays Original")!, context.Products.FirstOrDefault(p => p.Name == "Ice cream")! },
            //            Subs = new List<Sub>
            //            {
            //                new Sub
            //                {
            //                     Products = new List<Product>
            //                     {
            //                           context.Products.FirstOrDefault(p => p.Name == "White Bread")!,
            //                            context.Products.FirstOrDefault(p => p.Name == "Ham")!,
            //                            context.Products.FirstOrDefault(p => p.Name == "Tomato")!,
            //                            context.Products.FirstOrDefault(p => p.Name == "Tomato")!,
            //                            context.Products.FirstOrDefault(p => p.Name == "Onion")!,
            //                            context.Products.FirstOrDefault(p => p.Name == "Mayonnaise")!,
            //                            context.Products.FirstOrDefault(p => p.Name == "Cheddar")!
            //                     }
            //                }

            //            },
            //            OrderReceived = DateTime.Now.AddMinutes(10),
            //            CustomerId = "14"
            //        },


            //            new Order
            //            {
            //                TakeAway = false,
            //                TotalPrice = 300,
            //                Products = new List<Product> { context.Products.FirstOrDefault(p => p.Name == "Coca-Cola")!, context.Products.FirstOrDefault(p => p.Name == "Lays Original")!, context.Products.FirstOrDefault(p => p.Name == "Ice cream")! },
            //                Subs = new List<Sub>
            //            {
            //                new Sub
            //                {
            //                     Products = new List<Product>
            //                     {
            //                           context.Products.FirstOrDefault(p => p.Name == "White Bread")!,
            //                            context.Products.FirstOrDefault(p => p.Name == "Ham")!,
            //                            context.Products.FirstOrDefault(p => p.Name == "Tomato")!,
            //                            context.Products.FirstOrDefault(p => p.Name == "Onion")!,
            //                            context.Products.FirstOrDefault(p => p.Name == "Mayonnaise")!,
            //                            context.Products.FirstOrDefault(p => p.Name == "Cheddar")!
            //                     }
            //                },
            //                new Sub
            //                {
            //                     Products = new List<Product>
            //                     {
            //                           context.Products.FirstOrDefault(p => p.Name == "White Bread")!,
            //                            context.Products.FirstOrDefault(p => p.Name == "Ham")!,
            //                            context.Products.FirstOrDefault(p => p.Name == "Tomato")!,
            //                            context.Products.FirstOrDefault(p => p.Name == "Onion")!,
            //                            context.Products.FirstOrDefault(p => p.Name == "Mayonnaise")!,
            //                            context.Products.FirstOrDefault(p => p.Name == "Cheddar")!
            //                     }
            //                }

            //            },
            //                OrderReceived = DateTime.Now,
            //                OrderInProgress = DateTime.Now.AddMinutes(5),
            //                CustomerId = "13"
            //            },
            //            new Order
            //            {
            //                TakeAway = false,
            //                TotalPrice = 300,
            //                Products = new List<Product> { context.Products.FirstOrDefault(p => p.Name == "Coca-Cola")!, context.Products.FirstOrDefault(p => p.Name == "Lays Original")!, context.Products.FirstOrDefault(p => p.Name == "Ice cream")! },
            //                Subs = new List<Sub>
            //            {
            //                new Sub
            //                {
            //                     Products = new List<Product>
            //                     {
            //                           context.Products.FirstOrDefault(p => p.Name == "White Bread")!,
            //                            context.Products.FirstOrDefault(p => p.Name == "Ham")!,
            //                            context.Products.FirstOrDefault(p => p.Name == "Tomato")!,
            //                            context.Products.FirstOrDefault(p => p.Name == "Onion")!,
            //                            context.Products.FirstOrDefault(p => p.Name == "Mayonnaise")!,
            //                            context.Products.FirstOrDefault(p => p.Name == "Cheddar")!
            //                     }
            //                }

            //            },
            //                OrderReceived = DateTime.Now,
            //                OrderInProgress = DateTime.Now.AddMinutes(5),
            //                OrderCompleted = DateTime.Now.AddMinutes(15),
            //                CustomerId = "12"
            //            },
            //            new Order
            //            {
            //                TakeAway = true,
            //                TotalPrice = 300,
            //                Products = new List<Product> { context.Products.FirstOrDefault(p => p.Name == "Coca-Cola")!, context.Products.FirstOrDefault(p => p.Name == "Lays Original")!, context.Products.FirstOrDefault(p => p.Name == "Ice cream")! },
            //                Subs = new List<Sub>
            //            {
            //                new Sub
            //                {
            //                     Products = new List<Product>
            //                     {
            //                           context.Products.FirstOrDefault(p => p.Name == "White Bread")!,
            //                            context.Products.FirstOrDefault(p => p.Name == "Ham")!,
            //                            context.Products.FirstOrDefault(p => p.Name == "Tomato")!,
            //                            context.Products.FirstOrDefault(p => p.Name == "Onion")!,
            //                            context.Products.FirstOrDefault(p => p.Name == "Mayonnaise")!,
            //                            context.Products.FirstOrDefault(p => p.Name == "Cheddar")!
            //                     }
            //                }

            //            },
            //                OrderReceived = DateTime.Now,
            //                OrderInProgress = DateTime.Now.AddMinutes(5),
            //                OrderCompleted = DateTime.Now.AddMinutes(15),
            //                OrderCollected = DateTime.Now.AddMinutes(16),
            //                CustomerId = "11"

            //            });
            //    context.SaveChanges();

            //}



        }


    }

}
