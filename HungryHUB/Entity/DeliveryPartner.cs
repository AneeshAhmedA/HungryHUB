using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HungryHUB.Entity
{
    public class DeliveryPartner
    {
        [Key]
        public string DeliveryPartnerId { get; set; }

        [Required]
        public string Name { get; set; }


        [Required]
        public string PhoneNumber { get; set; }

        public bool IsAvailable { get; set; }

        public string CityID { get; set; }

        [ForeignKey(nameof(CityID))]
        public City City { get; set; }


    }
}
