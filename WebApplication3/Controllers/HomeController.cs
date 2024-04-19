using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using System.Data.SqlClient;
using Microsoft.Data.Sqlite;
namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public List<Item> Items = new List<Item>();
        // GET: HomeController
        [Route("AdminPanel/AllItems")]
        public List<Item> Index()
        {
            string connectionString = "Data Source=WebApplication3Context-dc508207-6226-4e8d-add3-7ab5eeca9a25.db";
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Item";
                using (SqliteCommand command = new SqliteCommand(sql, connection))
                {

                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Item client = new Item();
                            client.Id = reader.GetInt32(0);
                            client.Title = reader.GetString(1);
                            client.Description = reader.GetString(2);
                            client.Price = reader.GetInt32(3);
                            client.Сurrency = reader.GetInt32(4);
                            client.Image = reader.GetString(5);
                            client.Place = reader.GetInt32(6);
                            client.Health = reader.GetInt32(7);
                            client.Power = reader.GetInt32(8);
                            client.XPover = reader.GetInt32(9);
                            Items.Add(client);

                        }
                    }
                }

            }

            return Items;
        }
}
}
