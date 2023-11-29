using Microsoft.EntityFrameworkCore;

namespace authen.Data
{
  public static class PrepDb
  {

    public static void PrepPopulation(IApplicationBuilder app)
    {
      using (var serviceScope = app.ApplicationServices.CreateScope())
      {
        SeedData(serviceScope.ServiceProvider.GetService<ApplicationDbContext>());

      }
    }

    private static void SeedData(ApplicationDbContext context)
    {
      System.Console.WriteLine("---> Attempting to apply migrations...");
      try
      {
        context.Database.Migrate();
      }
      catch (Exception ex)
      {
        System.Console.WriteLine($"---> Could not run migrations: {ex.Message}");
      }

      //check db exists
      //branchs
      if (!context.branches.Any())
      {
        System.Console.WriteLine("---> seeding data branchs...");
        var branch1 = new Branch
        {
          ImgURL = "https://example.com/image1.png",
          Name = "Branch 1",
          DiaChi = "Address 1",
          PhoneNo = "1234567890"
        };

        var branch2 = new Branch
        {
          ImgURL = "https://example.com/image2.png",
          Name = "Branch 2",
          DiaChi = "Address 2",
          PhoneNo = "0987654321"
        };

        context.branches.AddRange(
            branch1, branch2
        );

        context.SaveChanges();
      }
      else
      {
        System.Console.WriteLine("--> We already have data branchs");
      }

      //movie
      if (!context.movies.Any())
      {
        System.Console.WriteLine("---> seeding data movies...");
        var movies = new[]
        {
                    new Movie
                    {
                        Name = "Movie 1",
                        SmallImageURL = "https://example.com/image1.png",
                        ShortDescription = "Short description for Movie 1",
                        LongDescription = "Long description for Movie 1",
                        LargeImageURL = "https://example.com/largeimage1.png",
                        Director = "Director 1",
                        Actors = "Actor 1, Actor 2",
                        Categories = "Category 1, Category 2",
                        ReleaseDate = DateTime.Now.AddMonths(-6),
                        Duration = 120,
                        TrailerURL = "https://example.com/trailer1.mp4",
                        Language = "English",
                        Rated = "PG-13",
                        IsShowing = 1
                    },
                    new Movie
                    {
                        Name = "Movie 2",
                        SmallImageURL = "https://example.com/image2.png",
                        ShortDescription = "Short description for Movie 2",
                        LongDescription = "Long description for Movie 2",
                        LargeImageURL = "https://example.com/largeimage2.png",
                        Director = "Director 2",
                        Actors = "Actor 3, Actor 4",
                        Categories = "Category 3, Category 4",
                        ReleaseDate = DateTime.Now.AddMonths(-3),
                        Duration = 105,
                        TrailerURL = "https://example.com/trailer2.mp4",
                        Language = "Spanish",
                        Rated = "R",
                        IsShowing = 1
                    },
                    // Add more movies if needed
                };

        context.movies.AddRange(movies);
        context.SaveChanges();
      }
      else
      {
        System.Console.WriteLine("--> We already have data movies");
      }

      //rooms
      if (!context.rooms.Any())
      {
        System.Console.WriteLine("---> seeding data rooms...");

        var branches = context.branches.ToList();
        var rooms = new[]
             {
                    new Room
                    {
                        Name = "Room A",
                        Capacity = 50,
                        TotalArea = 100.0,
                        ImgURL = "https://example.com/roomA.jpg",
                        BranchId = branches[0].Id // Chọn Branch 1 cho Room A
                    },
                    new Room
                    {
                        Name = "Room B",
                        Capacity = 40,
                        TotalArea = 80.0,
                        ImgURL = "https://example.com/roomB.jpg",
                        BranchId = branches[1].Id // Chọn Branch 2 cho Room B
                    },
                    // Add more rooms if needed
                };

        context.rooms.AddRange(rooms);
        context.SaveChanges();
      }
      else
      {
        System.Console.WriteLine("--> We already have data rooms");
      }

      //Schedules
      if (!context.schedules.Any())
      {
        System.Console.WriteLine("---> seeding data Schedules...");
        var movies = context.movies.ToList(); // Lấy danh sách các movies từ cơ sở dữ liệu
        var branches = context.branches.ToList(); // Lấy danh sách các branches từ cơ sở dữ liệu
        var rooms = context.rooms.ToList(); // Lấy danh sách các rooms từ cơ sở dữ liệu

        var random = new Random();

        var schedules = new[]
        {
                    new Schedule
                    {
                        StartDate = DateTime.Now.Date.AddDays(1),
                        StartTime = new TimeSpan(18, 30, 0),
                        Price = 9.99,
                        MovieId = movies[random.Next(movies.Count)].Id, // Chọn ngẫu nhiên 1 movie từ danh sách
                        BranchId = branches[random.Next(branches.Count)].Id, // Chọn ngẫu nhiên 1 branch từ danh sách
                        RoomId = rooms[random.Next(rooms.Count)].Id // Chọn ngẫu nhiên 1 room từ danh sách
                    },
                    new Schedule
                    {
                        StartDate = DateTime.Now.Date.AddDays(2),
                        StartTime = new TimeSpan(14, 0, 0),
                        Price = 8.50,
                        MovieId = movies[random.Next(movies.Count)].Id,
                        BranchId = branches[random.Next(branches.Count)].Id,
                        RoomId = rooms[random.Next(rooms.Count)].Id
                    },
                    // Thêm nhiều schedules khác nếu cần
                };

        context.schedules.AddRange(schedules);
        context.SaveChanges();
      }
      else
      {
        System.Console.WriteLine("--> We already have data Schedules");
      }

      //seats
      if (!context.seats.Any())
      {
        var random = new Random();
        var rooms = context.rooms.ToList();
        System.Console.WriteLine("---> seeding data movies...");
        var seats = new[] {
            new Seat
                    {

                     Name = "Seat A",
                    RoomId = rooms[random.Next(rooms.Count)].Id
                    },
                 new Seat
                       {

                     Name = "Seat B",
                    RoomId = rooms[random.Next(rooms.Count)].Id
                    }
                  };

        context.seats.AddRange(seats);
        context.SaveChanges();
      }
      else
      {
        System.Console.WriteLine("--> We already have data Seatss");
      }

      //bills
      if (!context.bills.Any())
      {
        var random = new Random();
        var rooms = context.bills.ToList();
        System.Console.WriteLine("---> seeding data movies...");
        var users = context.Users.ToList(); // Lấy danh sách các movies từ cơ sở dữ liệu
        var user = users[random.Next(rooms.Count)];
        var bills = new List<Bill>
        {
            new Bill {  CreatedTime = DateTime.Now, UserId = user.Id, User = user },
        };

        context.bills.AddRange(bills);
        context.SaveChanges();
      }
      else
      {
        System.Console.WriteLine("--> We already have data bills");
      }

      //tickets
      if (!context.tickets.Any())
      {
        var random = new Random();
        System.Console.WriteLine("---> seeding data tickets...");
        var seats = context.seats.ToList();
        var schedules = context.schedules.ToList();
        var bills = context.bills.ToList();
        var tickets = new List<Ticket>
        {
          new Ticket {  QRImageURL = "https://example.com/qrimage1.png", SeatId = seats[random.Next(seats.Count)].Id, Seat = seats[random.Next(seats.Count)], ScheduleId = schedules[random.Next(schedules.Count)].Id, BillId = bills[random.Next(bills.Count)].Id},

        };

        context.tickets.AddRange(tickets);
        context.SaveChanges();
      }
      else
      {
        System.Console.WriteLine("--> We already have data tickets");
      }
    }
  }
}