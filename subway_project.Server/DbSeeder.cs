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
                    new SubCategory { Name = "Bread", CategoryId = 1 },
                    new SubCategory { Name = "Vegetables", CategoryId = 1 },
                    new SubCategory { Name = "Sauces", CategoryId = 1 },
                    new SubCategory { Name = "Cheese", CategoryId = 1 },
                    new SubCategory { Name = "Proteins", CategoryId = 1 },
                    new SubCategory { Name = "Carbonated", CategoryId = 2 },
                    new SubCategory { Name = "Non Carbonated", CategoryId = 2 },
                    new SubCategory { Name = "Chips", CategoryId = 3 },
                    new SubCategory { Name = "Cookies", CategoryId = 3 },
                    new SubCategory { Name = "Ice-Cream", CategoryId = 4 },
                    new SubCategory { Name = "Pies", CategoryId = 4 }
                    );

                context.SaveChanges();

            }

            if (!context.SubIngredients.Any())
            {
                context.SubIngredients.AddRange(
                    new SubIngredients { ProductId = 1 },
                    new SubIngredients { ProductId = 2 },
                    new SubIngredients { ProductId = 3 },
                    new SubIngredients { ProductId = 4 },
                    new SubIngredients { ProductId = 5 },
                    new SubIngredients { ProductId = 6 },
                    new SubIngredients { ProductId = 7 },
                    new SubIngredients { ProductId = 8 },
                    new SubIngredients { ProductId = 9 },
                    new SubIngredients { ProductId = 10 },
                    new SubIngredients { ProductId = 11 },
                    new SubIngredients { ProductId = 12 },
                    new SubIngredients { ProductId = 13 },
                    new SubIngredients { ProductId = 14 },
                    new SubIngredients { ProductId = 15 },
                    new SubIngredients { ProductId = 16 },
                    new SubIngredients { ProductId = 17 },
                    new SubIngredients { ProductId = 18 },
                    new SubIngredients { ProductId = 19 },
                    new SubIngredients { ProductId = 20 },
                    new SubIngredients { ProductId = 21 },
                    new SubIngredients { ProductId = 22 },
                    new SubIngredients { ProductId = 23 },
                    new SubIngredients { ProductId = 24 },
                    new SubIngredients { ProductId = 25 },
                    new SubIngredients { ProductId = 26 }



                    );
            }

            if (!context.Products.Any())
            {
                context.Products.AddRange(

                    new Product { Name = "White Bread", Price = 15.00m, SubCategoryId = 1, ImageUrl = "https://okfrozendough.com/wp-content/uploads/2019/10/OK340_9_inc_white_bun.jpg" },
                    new Product { Name = "Whole Wheat Bread", Price = 20.00m, SubCategoryId = 1, ImageUrl = "https://okfrozendough.com/wp-content/uploads/2019/10/OK345_9_inc_ww_sub_bun.jpg" },
                    new Product { Name = "Light Bread", Price = 18.00m, SubCategoryId = 1, ImageUrl = "https://www.seasonsandsuppers.ca/wp-content/uploads/2022/09/sub-rolls-4-3-3.jpg" },
                    new Product { Name = "Cheese Bread", Price = 33.00m, SubCategoryId = 1, ImageUrl = "https://cdn.vox-cdn.com/thumbor/v5MOxdUdtffU4E1zkMM80jetZ2c=/0x0:1080x1350/1200x800/filters:focal(477x802:649x974)/cdn.vox-cdn.com/uploads/chorus_image/image/72447167/358101373_292422893350341_630677683818333789_n.0.jpg" },

                    new Product { Name = "Tomato", Price = 5.00m, SubCategoryId = 2, ImageUrl = "https://m.economictimes.com/thumb/msid-95423731,width-1200,height-900,resizemode-4,imgsize-56196/tomatoes-canva.jpg" },
                    new Product { Name = "Onion", Price = 3.00m, SubCategoryId = 2, ImageUrl = "https://ih1.redbubble.net/image.3804311069.0627/raf,360x360,075,t,fafafa:ca443f4786.jpg" },
                    new Product { Name = "Bell Pepper", Price = 6.00m, SubCategoryId = 2, ImageUrl = "https://www.chilipeppermadness.com/wp-content/uploads/2024/02/Bell-Peppers1.jpg" },
                    new Product { Name = "Cucumber", Price = 4.00m, SubCategoryId = 2, ImageUrl = "https://snaped.fns.usda.gov/sites/default/files/styles/crop_ratio_7_5/public/seasonal-produce/2018-05/cucumbers2.jpg.webp?itok=Y2CZseBE" },
                    new Product { Name = "Spinach", Price = 5.00m, SubCategoryId = 2, ImageUrl = "https://bedford.tennessee.edu/wp-content/uploads/sites/162/2020/08/spinach-leaves-1024x593.jpg" },

                    new Product { Name = "Mayonnaise", Price = 5.00m, SubCategoryId = 3, ImageUrl = "https://media.istockphoto.com/id/507636140/photo/homemade-mayonnaise.jpg?s=612x612&w=0&k=20&c=Yo39cXtQ0x4uRJbRKMo__9ppA-BKcLI82PbMcn4aweo=" },
                    new Product { Name = "Mustard", Price = 4.00m, SubCategoryId = 3, ImageUrl = "https://www.realsimple.com/thmb/vPbhjHFdv4Ta_YuujhhHSzsKPL8=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/homemade-mustard-2000-178458cea0514bdfa3bcfb4cd499612b.jpg" },
                    new Product { Name = "Barbecue Sauce", Price = 6.00m, SubCategoryId = 3, ImageUrl = "https://www.allrecipes.com/thmb/N3b7R0ApzKN6q0RRLQdmb6KPegQ=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/51226-a-very-popular-bbq-sauce-DDMFS-4x3-c6e3230c5df240b4937385141cce0b67.jpg" },
                    new Product { Name = "Sweet Chili", Price = 6.00m, SubCategoryId = 3, ImageUrl = "https://www.foxyfolksy.com/wp-content/uploads/2021/10/sweet-chili-sauce-1200t.jpg" },
                    new Product { Name = "Ranch Sauce", Price = 5.00m, SubCategoryId = 3, ImageUrl = "https://taoofspice.com/wp-content/uploads/2022/01/Close-up-of-garlic-ranch-dip-with-carrots-surrounding-it-683x1024.jpg.webp" },


                    new Product { Name = "Cheddar", Price = 10.00m, SubCategoryId = 4, ImageUrl = "https://images3.alphacoders.com/665/665670.jpg" },
                    new Product { Name = "Mozzarella", Price = 12.00m, SubCategoryId = 4, ImageUrl = "https://www.shutterstock.com/shutterstock/videos/3391081405/thumb/3.jpg?ip=x480" },
                    new Product { Name = "Hard Cheese", Price = 14.00m, SubCategoryId = 4, ImageUrl = "https://www.shutterstock.com/shutterstock/videos/3665506537/thumb/1.jpg?ip=x480" },

                    new Product { Name = "Ham", Price = 15.00m, SubCategoryId = 5, ImageUrl = "https://www.shutterstock.com/shutterstock/videos/1105399823/thumb/1.jpg?ip=x480" },
                    new Product { Name = "Turkey", Price = 20.00m, SubCategoryId = 5, ImageUrl = "https://t3.ftcdn.net/jpg/02/87/06/90/360_F_287069085_cSzPLAoux5MSAeETX4Pwhdxa5gxrbqf4.jpg" },
                    new Product { Name = "Beef", Price = 30.00m, SubCategoryId = 5, ImageUrl = "https://media.istockphoto.com/id/535786572/photo/grilled-striploin-steak.jpg?s=612x612&w=0&k=20&c=F_vrvwIOWe3vBR2y16Dp4z6d46K1sIY3togU3VYjrpA=" },
                    new Product { Name = "Chicken", Price = 25.00m, SubCategoryId = 5, ImageUrl = "https://www.everyday-delicious.com/wp-content/uploads/2021/03/chicken-spread-pasta-z-kurczaka-everyday-delicious-1.jpg" },
                    new Product { Name = "Vegetarian", Price = 18.00m, SubCategoryId = 5, ImageUrl = "https://cheapandcheerfulcooking.com/wp-content/uploads/2021/02/muhammara-red-pepper-walnut-dip-1.jpg" },
                    new Product { Name = "Tuna", Price = 22.00m, SubCategoryId = 5, ImageUrl = "https://www.goodnesst.com/wp-content/uploads/2019/12/easy-tuna-spread-recipe-2.jpg" },
                    new Product { Name = "Chicken Breast", Price = 25.00m, SubCategoryId = 5, ImageUrl = "https://i2.wp.com/www.downshiftology.com/wp-content/uploads/2023/01/Air-Fryer-Chicken-Breast-7.jpg" },
                    new Product { Name = "Steak", Price = 30.00m, SubCategoryId = 5, ImageUrl = "https://i.redd.it/03zxsyqc6otb1.jpg" },
                    new Product { Name = "Tofu", Price = 18.00m, SubCategoryId = 5, ImageUrl = "https://alegumeaday.com/wp-content/uploads/2021/08/Creamy-sun-dried-tomato-tofu-spread-A-Legume-a-Day-20210805-1.jpg" },
                    new Product { Name = "Coca-Cola", Price = 15.00m, SubCategoryId = 6, ImageUrl = "https://www.shutterstock.com/shutterstock/videos/1065268699/thumb/1.jpg?ip=x480" },
                    new Product { Name = "Fanta", Price = 15.00m, SubCategoryId = 6, ImageUrl = "https://t4.ftcdn.net/jpg/03/57/78/97/360_F_357789751_uno2v0tEYXqgPW1AGcXsVWLqSRp9Q5bA.jpg" },
                    new Product { Name = "Sprite", Price = 15.00m, SubCategoryId = 6, ImageUrl = "https://www.hdwallpapers.in/download/sprite_pouring_on_glass_hd_sprite_cranberry-HD.jpg" },

                    new Product { Name = "Water", Price = 10.00m, SubCategoryId = 7, ImageUrl = "https://media.gettyimages.com/id/1243369052/sv/video/tr%C3%A4dg%C3%A5rdsslang-vattning-en-lummig-gr%C3%B6n-tr%C3%A4dg%C3%A5rd.jpg?s=640x640&k=20&c=uepVUNvnv1DO0sKeEC4j0LV_GVY0UtgEsQBmE0ymSFk=" },

                    new Product { Name = "Lays Original", Price = 10.00m, SubCategoryId = 8, ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/69/Potato-Chips.jpg/960px-Potato-Chips.jpg" },
                    new Product { Name = "Lays Paprika", Price = 10.00m, SubCategoryId = 8, ImageUrl = "https://www.shutterstock.com/image-photo/bbq-potato-chips-on-white-600nw-1054938998.jpg" },

                    new Product { Name = "Chocolate Chip Cookies", Price = 12.00m, SubCategoryId = 9, ImageUrl = "https://media.istockphoto.com/id/1411089766/sv/foto/pile-of-homemade-cookies.jpg?s=612x612&w=0&k=20&c=F6WFEHfumZI0EENWVYNZZu9B0jVAvJgI7JqDg1BlgDc=" },
                    new Product { Name = "Cookie", Price = 10.00m, SubCategoryId = 9, ImageUrl = "https://krollskorner.com/wp-content/uploads/2023/10/Chocolate-Chipless-Cookies_LowRes-017-1.jpg" },
                    new Product { Name = "Brownie", Price = 15.00m, SubCategoryId = 9, ImageUrl = "https://shared.cdn.smp.schibsted.com/v2/images/66339597-1216-4afb-b5ff-0a550ccf7ecf?fit=crop&h=1426&w=1900&s=a52df5a58314385584212b791d039917dd56d58d" },

                    new Product { Name = "Ice Cream", Price = 20.00m, SubCategoryId = 10, ImageUrl = "https://shared.cdn.smp.schibsted.com/v2/images/539eab90-b586-4397-8331-fe1c304d202b?fit=crop&h=1425&w=1900&s=f1969e391b4d00af2bb88340ffae4edbf37637c5" },

                    new Product { Name = "Apple Pie", Price = 18.00m, SubCategoryId = 11, ImageUrl = "https://media.istockphoto.com/id/450752471/sv/foto/homemade-organic-apple-pie-dessert.jpg?s=612x612&w=0&k=20&c=Lw-t-f6DoNwerNFNTdQ9emEhcCcD7aPIBAf5nLhWDNw=" },
                    new Product { Name = "Cheesecake", Price = 22.00m, SubCategoryId = 11, ImageUrl = "https://images3.alphacoders.com/600/600689.jpg" }
                );

                context.SaveChanges();
            }

            if (!context.Orders.Any())
            {
                context.Orders.AddRange(

                    new Order
                    {
                        TakeAway = true,
                        OrderReceived = DateTime.Now,
                        Queue = new Queue(),
                        TotalPrice = 300,
                        Products = new List<Product> { context.Products.FirstOrDefault(p => p.Id == 1)!, context.Products.FirstOrDefault(p => p.Id == 7)!, context.Products.FirstOrDefault(p => p.Id == 13)! },
                        Subs = new List<Sub>
                        {
                            new Sub
                            {
                                SubIngredients = new List<SubIngredients>
                                {
                                    context.SubIngredients.FirstOrDefault(t => t.Id == 1)!,
                                    context.SubIngredients.FirstOrDefault(t => t.Id == 2)!,
                                    context.SubIngredients.FirstOrDefault(t => t.Id == 6)!,
                                    context.SubIngredients.FirstOrDefault(t => t.Id == 12)!,
                                    context.SubIngredients.FirstOrDefault(t => t.Id == 17)!
                                }
                            }
                        }
                    },
                    new Order
                    {
                        TakeAway = true,
                        OrderReceived = DateTime.Now,
                        OrderInProgress = DateTime.Now.AddMinutes(5),
                        Queue = new Queue(),
                        TotalPrice = 300,
                        Products = new List<Product> { context.Products.FirstOrDefault(p => p.Id == 2)!, context.Products.FirstOrDefault(p => p.Id == 7)!, context.Products.FirstOrDefault(p => p.Id == 13)! },
                        Subs = new List<Sub>
                        {
                            new Sub
                            {
                                SubIngredients = new List<SubIngredients>
                                {
                                    context.SubIngredients.FirstOrDefault(t => t.Id == 2)!,
                                    context.SubIngredients.FirstOrDefault(t => t.Id == 3)!,
                                    context.SubIngredients.FirstOrDefault(t => t.Id == 6)!,
                                    context.SubIngredients.FirstOrDefault(t => t.Id == 13)!,
                                    context.SubIngredients.FirstOrDefault(t => t.Id == 18)!
                                }
                            }
                        }
                    },
                     new Order
                     {
                         TakeAway = true,
                         OrderReceived = DateTime.Now,
                         OrderInProgress = DateTime.Now.AddMinutes(5),
                         OrderCompleted = DateTime.Now.AddMinutes(15),
                         Queue = new Queue(),
                         TotalPrice = 300,
                         Products = new List<Product> { context.Products.FirstOrDefault(p => p.Id == 2)!, context.Products.FirstOrDefault(p => p.Id == 7)!, context.Products.FirstOrDefault(p => p.Id == 13)! },
                         Subs = new List<Sub>
                        {
                            new Sub
                            {
                                SubIngredients = new List<SubIngredients>
                                {
                                    context.SubIngredients.FirstOrDefault(t => t.Id == 2)!,
                                    context.SubIngredients.FirstOrDefault(t => t.Id == 3)!,
                                    context.SubIngredients.FirstOrDefault(t => t.Id == 6)!,
                                    context.SubIngredients.FirstOrDefault(t => t.Id == 13)!,
                                    context.SubIngredients.FirstOrDefault(t => t.Id == 18)!
                                }
                            }
                        }
                     },
                      new Order
                      {
                          TakeAway = true,
                          OrderReceived = DateTime.Now,
                          OrderInProgress = DateTime.Now.AddMinutes(5),
                          OrderCompleted = DateTime.Now.AddMinutes(15),
                          OrderCollected = DateTime.Now.AddMinutes(17),
                          Queue = new Queue(),
                          TotalPrice = 300,
                          Products = new List<Product> { context.Products.FirstOrDefault(p => p.Id == 2)!, context.Products.FirstOrDefault(p => p.Id == 7)!, context.Products.FirstOrDefault(p => p.Id == 13)! },
                          Subs = new List<Sub>
                        {
                            new Sub
                            {
                                SubIngredients = new List<SubIngredients>
                                {
                                    context.SubIngredients.FirstOrDefault(t => t.Id == 2)!,
                                    context.SubIngredients.FirstOrDefault(t => t.Id == 3)!,
                                    context.SubIngredients.FirstOrDefault(t => t.Id == 6)!,
                                    context.SubIngredients.FirstOrDefault(t => t.Id == 13)!,
                                    context.SubIngredients.FirstOrDefault(t => t.Id == 18)!
                                }
                            }
                        }
                      }
                    );

            context.SaveChanges();
        }



    }


}

}
