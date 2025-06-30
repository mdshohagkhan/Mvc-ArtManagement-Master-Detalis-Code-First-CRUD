namespace ArtMangementmvc.Models
{
    public class SaleDetaile
    {
        public int SaleDetaileId { get; set; }
        public string ArtName { get; set; }
        public int Quantity { get; set; }
        public int SaleId { get; set; }

        public virtual Sale Sale { get; set; }
    }
}