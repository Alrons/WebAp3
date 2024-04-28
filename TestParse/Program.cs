using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ItemApiExample
{
    public class Item
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int Сurrency { get; set; }
        public string? Image { get; set; }
        public int Place { get; set; }
        public int Health { get; set; }
        public int Power { get; set; }

        // Коафицент умнажения мощьности при добовлнения еще одного item в одно и тоже место
        public int XPover { get; set; }

        public Item(int id, string? title, string? description, int price, int сurrency, string? image, int place, int health, int power, int xPover)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            Сurrency = сurrency;
            Image = image;
            Place = place;
            Health = health;
            Power = power;
            XPover = xPover;
        }
    }
    class Program
    {
        static async Task Main(string[] args)
        {
            // Create a new instance of the Item class
            Item item = new Item
            (
                0,
                "Example Item",
                "This is an example item",
                10,
                1,
                "https://example.com/image.jpg",
                1,
                10,
                5,
                2
            );

            // Convert the Item object to JSON
            string json = JsonConvert.SerializeObject(item);

            // Create a new instance of HttpClient
            using (HttpClient client = new HttpClient())
            {
                // Set the BaseAddress of the client
                client.BaseAddress = new Uri("https://localhost:7139/api/");

                // Create a new HttpContent object with the JSON data
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                // Make the POST request
                HttpResponseMessage response = await client.PostAsync("Items", content);

                // Check the response status code
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Item created successfully!");
                }
                else
                {
                    Console.WriteLine("Error creating item: " + response.StatusCode);
                }
            }
        }
    }
}
