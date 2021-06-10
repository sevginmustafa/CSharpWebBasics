namespace Andreys.Data
{
    public class UserPoduct
    {
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
