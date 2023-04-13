namespace InstrumetShop.Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            CompositionOrder = new HashSet<CompositionOrder>();
        }

        [Key]
        [StringLength(100)]
        public string ProductArticul { get; set; }

        public int NameId { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductDescription { get; set; }

        public int TypeId { get; set; }

        public int PurposeId { get; set; }

        public int ProviderId { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductDiscount { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductCost { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] ProductImage { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductCountInStoke { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompositionOrder> CompositionOrder { get; set; }

        public virtual Name Name { get; set; }

        public virtual Provider Provider { get; set; }

        public virtual Purpose Purpose { get; set; }

        public virtual Type Type { get; set; }
    }
}
