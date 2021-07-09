using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace UserNamespace
{
    class User
    {
        public int Id { get; set; }
        public int MyId { get; set; } = 0;
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User() { Id = ++MyId; }
        public User(string name, string surname, int age, string email, string password)
        {
            Id = ++MyId;
            Name = name;
            Surname = surname;
            Age = age;
            Email = email;
            Password = password;
        }
        public void ShowUser()
        {
            Console.WriteLine($"Fullname: {Name} {Surname}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Email: {Email}");
        }

    }
}
namespace PostNamespace
{
    class Post
    {
        public int Id { get; set; }
        public int MyId { get; set; } = 0;
        public string Content { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int LikeCount { get; set; } = 0;
        public int ViewCount { get; set; } = 0;
        public Post()
        {
            Id = ++MyId;
        }
        public Post(string content, DateTime cretiondatetime)
        {
            Id = ++MyId;
            Content = content;
            CreationDateTime = cretiondatetime;
        }
        public void IncreaseLikeCount()
        {
            ++LikeCount;
        }
        public void ShowPost()
        {
            Console.WriteLine($@"               {Content}
        view {++ViewCount}                   like {LikeCount}          {CreationDateTime}");
        }

    }
}
namespace AdminNamespace
{
    using User = UserNamespace.User;
    using Post = PostNamespace.Post;
    class Notification
    {
        public int Id { get; set; }
        public int MyId { get; set; } = 0;
        public string Text { get; set; }
        public DateTime Datetime { get; set; }
        public User FromUser { get; set; }

        public Notification()
        {
            Id = ++MyId;
        }
        public Notification(string text, DateTime dateTime, User fromuser)
        {
            Id = ++MyId;
            Text = text;
            Datetime = dateTime;
            FromUser = fromuser;
        }
        public void ShowNotification()
        {
            Console.WriteLine($"You have a notification from {FromUser.Name} {FromUser.Surname}");
            Console.WriteLine($"<< {Text} >>");
            Console.WriteLine($@"                                                                   Time: {Datetime}");
        }
    }
    class Admin
    {
        public Admin()
        {
            ID = ++MyId;
        }
        public int ID { get; set; }
        public int MyId { get; set; } = 0;
        public string Username { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public Post[] Posts { get; set; }
        public int PostCount { get; set; } = 0;
        public Notification[] Notifications { get; set; }
        public int NotificationCount { get; set; } = 0;

        public Admin(string username, string email, string password)
        {
            ID = ++MyId;
            Username = username;
            Email = email;
            Password = password;
        }
        public void ShowAdmin()
        {
            Console.WriteLine($"Admin Username: {Username} ");
            Console.WriteLine($"Email: {Email}");
        }
        public void AddPost(Post post)
        {
            Post[] temp = new Post[PostCount + 1];
            if (PostCount != 0)
            {
                Posts.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = post;
            Posts = temp;
            ++PostCount;
        }
        public void AddNotification(Notification not)
        {
            Notification[] temp = new Notification[NotificationCount + 1];
            if (NotificationCount != 0)
            {
                Notifications.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = not;
            Notifications = temp;
            ++NotificationCount;
        }
    }

}
namespace NetworkNamespace { }

namespace Namespaces
{
    using User = UserNamespace.User;
    using Not = AdminNamespace.Notification;
    using Admin = AdminNamespace.Admin;
    using Post = PostNamespace.Post;

    class DataBase
    {
        public User[] Users { get; set; }
        public int UserCount { get; set; }
        public Not[] Notifications { get; set; }
        public int NotCount { get; set; }
        public Admin[] Admins { get; set; }
        public int AdminCount { get; set; }
        public Post[] Posts { get; set; }
        public int PostCount { get; set; }
        public void AddUser(User user)
        {
            User[] temp = new User[UserCount + 1];
            if (UserCount != 0)
            {
                Users.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = user;
            Users = temp;
            ++UserCount;
        }
        public void AddNotification(Not notification)
        {
            Not[] temp = new Not[NotCount + 1];
            if (NotCount != 0)
            {
                Notifications.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = notification;
            Notifications = temp;
            ++NotCount;
        }
        public void AddAdmin(Admin admin)
        {
            Admin[] temp = new Admin[AdminCount + 1];
            if (AdminCount != 0)
            {
                Admins.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = admin;
            Admins = temp;
            ++AdminCount;
        }
        public void AddPost(Post post)
        {
            Post[] temp = new Post[PostCount + 1];
            if (PostCount != 0)
            {
                Posts.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = post;
            Posts = temp;
            ++PostCount;
        }
    }

    class Run
    {
        public DataBase Database { get; set; }
        public Run()
        {
            Database = new DataBase();
        }
        public void CreatAdmin()
        {
            Admin admin1 = new Admin
            {
                Username = "Admin",
                Email = "Adminadmin@gmail.com",
                Password = "adminadmin"
            };
            Database.AddAdmin(admin1);

        }
        public void CreatUser()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Surname: ");
            string surname = Console.ReadLine();
            Console.Write("Age: ");
            string a = Console.ReadLine();
            int age = int.Parse(a);
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            User user = new User
            {
                Name = name,
                Surname = surname,
                Age = age,
                Email = email,
                Password = password
            };

            Database.AddUser(user);
            Console.Clear();
            Console.WriteLine("User created...");
        }
        public void CreatPost(string username)
        {
            Console.WriteLine("Content");
            string content = Console.ReadLine();

            Console.WriteLine("Creation time: ");
            Console.Write("Year: ");
            string year = Console.ReadLine();
            int yy = int.Parse(year);

            Console.Write("\nMonth: ");
            string month = Console.ReadLine();
            int mm = int.Parse(month);

            Console.Write("\nDay: ");
            string day = Console.ReadLine();
            int dd = int.Parse(day);

            Post post = new Post
            {
                Content = content,
                CreationDateTime = new DateTime(yy, mm, dd)
            };

            Database.AddPost(post);
            foreach (var admin in Database.Admins)
            {
                admin.AddPost(post);
            }
            Console.WriteLine("Post created...");
        }
        public void CreatNotification(User fromUser, Post forpost)
        {
            Not notification = new Not
            {
                Text = "Liked ",
                Datetime = DateTime.Now,
                FromUser = fromUser
            };
            Database.AddNotification(notification);

            foreach (var admin in Database.Admins)
            {
                admin.AddNotification(notification);
            }
        }
        public void Display1()
        {
            Console.Clear();
            Console.WriteLine("User [1] \nAdmin [2] \nChoose:  ");
            string ch = Console.ReadLine();
            if (ch == "1")
            {
                UserRegistr();
            }
            else if (ch == "2")
            {
                CreatAdmin();
                Control("2");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Choose 1 or 2 ");
                Display1();
            }
        }
        public void AdminControl(string email, string password)
        {
            Console.Clear();
            for (int i = 0; i < Database.AdminCount; i++)
            {
                var admin = Database.Admins[i];
                if (admin.Email == email && admin.Password == password)
                {
                    Console.WriteLine("Creat Post [1]");
                    Console.WriteLine("Show notification [2]");
                    Console.WriteLine("Show posts [3]");
                    Console.WriteLine("Back [0]");
                    string ch = Console.ReadLine();
                    var username = admin.Username;
                    Choise(ch, username, email, password);
                }
                else
                {
                    Console.WriteLine("Email or password is incorrect. . .");
                    Thread.Sleep(2000);
                    Display1();
                }
            }
        }
        public void Choise(string ch, string username, string email, string password)
        {
            Console.Clear();
            if (ch == "1")
            {
                CreatPost(username);
                var cho = Back();
                if (cho)
                {
                    AdminControl(email, password);
                }
            }
            else if (ch == "2")
            {
                for (int i = 0; i < Database.NotCount; i++)
                {
                    Database.Notifications[i].ShowNotification();
                }
                var cho = Back();
                if (cho)
                {
                    AdminControl(email, password);
                }
            }
            else if (ch == "3")
            {
                for (int i = 0; i < Database.PostCount; i++)
                {
                    Database.Posts[i].ShowPost();
                }
                var cho = Back();
                if (cho)
                {
                    AdminControl(email, password);
                }
            }
            else
            {
                Display1();
            }

        }
        public void UserControl(string email, string password)
        {
            Console.Clear();
            for (int i = 0; i < Database.UserCount; i++)
            {
                var user = Database.Users[i];
                if (user.Email == email && user.Password == password)
                {
                    ShowPosts(user);
                }
                else
                {
                    UserRegistr();
                }
            }
        }
        public void UserRegistr()
        {
            Console.WriteLine(" Do you want to register [yes or no] : ");
            string answer = Console.ReadLine();
            if (answer == "yes")
            {
                CreatUser();
                Control("1");
            }
            else
            {
                Console.Clear();
                Control("1");
            }
        }
        public void ShowPosts(User user)
        {
            if (Database.PostCount != 0)
            {
                for (int i = 0; i < Database.PostCount; i++)
                {
                    var post = Database.Posts[i];
                    post.ShowPost();
                    Console.WriteLine("[Y] Do you like? ");
                    string ans = Console.ReadLine();
                    if (ans == "Y")
                    {
                        post.IncreaseLikeCount();
                        CreatNotification(user, post);
                    }
                }
            }
            else
            {
                Console.WriteLine("There are no post...");

            }
            var cho = Back();
            if (cho)
            {
                Display1();
            }
        }
        public void Control(string choise)
        {
            Console.Clear();
            Console.Write($@"


                                                   Email: ");
            string email = Console.ReadLine();
            Console.Write($@"


                                                   Password: ");
            string password = Console.ReadLine();
            if (choise == "1")
            {
                UserControl(email, password);
            }
            else if (choise == "2")
            {
                AdminControl(email, password);
            }

        }
        public bool Back()
        {
            Console.WriteLine("Back [0]");
            string cho = Console.ReadLine();
            if (cho == "0")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Incorrect choise");
                Back();
                return false;
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Run run = new Run();
            run.Display1();

        }
    }
}
