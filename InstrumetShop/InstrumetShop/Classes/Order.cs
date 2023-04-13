namespace InstrumetShop.Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            CompositionOrder = new HashSet<CompositionOrder>();
        }

        public int OrderId { get; set; }

        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime OrderDelivery { get; set; }

        public int PointOfIssueId { get; set; }

        [Required]
        [StringLength(100)]
        public string OrderFullNameClient { get; set; }

        public int OrderCode { get; set; }

        public int StatusId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompositionOrder> CompositionOrder { get; set; }

        public virtual PointOfIssue PointOfIssue { get; set; }

        public virtual Status Status { get; set; }
    }
}
