namespace lookFantastic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Review")]
    public partial class Review
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(60)]
        public string name { get; set; }

        public string komentar { get; set; }

        public int? grade { get; set; }

        public long? id_fitnesscentre { get; set; }

        public long? id_clothingshop { get; set; }

        public long? id_hairdresser { get; set; }

        public long? id_beautysalon { get; set; }

        public virtual BeautySalon BeautySalon { get; set; }

        public virtual ClothingShop ClothingShop { get; set; }

        public virtual FitnessCentre FitnessCentre { get; set; }

        public virtual HairDresser HairDresser { get; set; }
    }
}
