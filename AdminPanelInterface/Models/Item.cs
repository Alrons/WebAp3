using AdminPanelInterface.Interfase;
using static System.Net.Mime.MediaTypeNames;

namespace AdminPanelInterface.Models
{
    public class Item : IItem 
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

        public Item(){}
    }
}
