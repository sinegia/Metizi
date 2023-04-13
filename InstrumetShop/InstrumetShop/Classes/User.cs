namespace InstrumetShop.Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string UserSurname { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string UserPatronymic { get; set; }

        [Required]
        [StringLength(100)]
        public string UserLogin { get; set; }

        [Required]
        [StringLength(100)]
        public string UserPassword { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
