namespace WebApplication3.Models
{
    public class Currencies
    {
        public int Id { get; set; }
        public string CurrencyName { get; set; }

        public Currencies (int id, string currencyName)
        {
            Id = id;
            CurrencyName = currencyName;
        }
    }
}
