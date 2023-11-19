﻿using System.ComponentModel.DataAnnotations.Schema;

namespace HungryHUB.Entity
{
    public class Restaurant
        {
            public int RestaurantId { get; set; }
            public string Name { get; set; }

            public string? CityID { get; set; }

            [ForeignKey(nameof(CityID))]
            public City City { get; set; }
        
        }
}
