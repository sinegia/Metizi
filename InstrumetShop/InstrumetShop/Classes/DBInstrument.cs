using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace InstrumetShop.Classes
{
	public partial class DBInstrument : DbContext
	{
		public DBInstrument()
			: base("name=DBInstrument")
		{
		}

		public virtual DbSet<CompositionOrder> CompositionOrder { get; set; }
		public virtual DbSet<Name> Name { get; set; }
		public virtual DbSet<Order> Order { get; set; }
		public virtual DbSet<PointOfIssue> PointOfIssue { get; set; }
		public virtual DbSet<Product> Product { get; set; }
		public virtual DbSet<Provider> Provider { get; set; }
		public virtual DbSet<Purpose> Purpose { get; set; }
		public virtual DbSet<Role> Role { get; set; }
		public virtual DbSet<Status> Status { get; set; }
		public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
		public virtual DbSet<Type> Type { get; set; }
		public virtual DbSet<User> User { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Name>()
				.Property(e => e.NameOfProduct)
				.IsUnicode(false);

			modelBuilder.Entity<Name>()
				.HasMany(e => e.Product)
				.WithRequired(e => e.Name)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Order>()
				.Property(e => e.OrderFullNameClient)
				.IsUnicode(false);

			modelBuilder.Entity<Order>()
				.HasMany(e => e.CompositionOrder)
				.WithRequired(e => e.Order)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<PointOfIssue>()
				.Property(e => e.PointOfIssueName)
				.IsUnicode(false);

			modelBuilder.Entity<PointOfIssue>()
				.HasMany(e => e.Order)
				.WithRequired(e => e.PointOfIssue)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Product>()
				.HasMany(e => e.CompositionOrder)
				.WithRequired(e => e.Product)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Provider>()
				.Property(e => e.ProviderName)
				.IsUnicode(false);

			modelBuilder.Entity<Provider>()
				.HasMany(e => e.Product)
				.WithRequired(e => e.Provider)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Purpose>()
				.Property(e => e.PurposeName)
				.IsUnicode(false);

			modelBuilder.Entity<Purpose>()
				.HasMany(e => e.Product)
				.WithRequired(e => e.Purpose)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Role>()
				.Property(e => e.RoleName)
				.IsUnicode(false);

			modelBuilder.Entity<Role>()
				.HasMany(e => e.User)
				.WithRequired(e => e.Role)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Status>()
				.Property(e => e.StatusName)
				.IsUnicode(false);

			modelBuilder.Entity<Status>()
				.HasMany(e => e.Order)
				.WithRequired(e => e.Status)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Type>()
				.Property(e => e.TypeName)
				.IsUnicode(false);

			modelBuilder.Entity<Type>()
				.HasMany(e => e.Product)
				.WithRequired(e => e.Type)
				.WillCascadeOnDelete(false);
		}
	}
}
