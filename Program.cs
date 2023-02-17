using System.Security.Cryptography.X509Certificates;

namespace HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> userList = new List<User>();
            User testUser = new User();
            testUser.Login = "test";
            testUser.Name = "test";
            testUser.IsPremium = false;
            userList.Add(testUser);

            Console.WriteLine("Введите логин");
            string log = Console.ReadLine();
            User user = LogIn(userList, log);
            Greeting(user);

            Console.ReadKey();
        }

        static void ShowAds()
        {
            Console.WriteLine("Посетите наш новый сайт с бесплатными играми free.games.for.a.fool.com");
            // Остановка на 1 с
            Thread.Sleep(1000);

            Console.WriteLine("Купите подписку на МыКомбо и слушайте музыку везде и всегда.");
            // Остановка на 2 с
            Thread.Sleep(2000);

            Console.WriteLine("Оформите премиум-подписку на наш сервис, чтобы не видеть рекламу.");
            // Остановка на 3 с
            Thread.Sleep(3000);
        }

        static User LogIn(List<User> userList, string loggin)
        {
            User user;
            bool isExist = TryGetUser(userList, loggin, out user);
            while (!isExist)
            {
                Console.WriteLine("Пользователь не найден. Проверьте верность веееденного логина или зарегестрируйтесь.");
                LogIn(userList, loggin);
            }
            return user;
        }

        static void Greeting(User user)
        {
            Console.WriteLine($"Приветствую {user.Name}");
            if (user.IsPremium == false)
            {
                ShowAds();
            }
        }
        static bool TryGetUser(List<User> userList, string loggin, out User user)
        {
            user = null;
            bool isUser = false;
            foreach (User userF in userList)
            {
                if (userF.Login == loggin)
                {
                    user = userF;
                    isUser = true;
                }
            }
            return isUser ;
        }
    }

}