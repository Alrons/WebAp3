namespace WebApplication3.Models
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

        public Item()
        {
        }
    }
}
