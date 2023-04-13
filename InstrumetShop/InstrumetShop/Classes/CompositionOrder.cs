namespace InstrumetShop.Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CompositionOrder")]
    public partial class CompositionOrder
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string ProductArticul { get; set; }

        public int OrderProductCount { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
