using System.ComponentModel.DataAnnotations.Schema;

namespace MyAmazonstore3.Models
{
    public class LignePanier
    {
        public int LignePanierId { get; set; }

        public int Quantite { get; set; }
        public int idPanier { get; set; }//dans la cookie 
        public int ProduitId { get; set; }
        public Produit Produit { get; set; }

        [NotMapped]
        public decimal Total => Produit.Prix * Quantite;
    }


}
