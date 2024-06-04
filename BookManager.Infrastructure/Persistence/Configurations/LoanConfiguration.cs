//using BookManger.Core.Entities;
//using Microsoft.EntityFrameworkCore;

//namespace BookManager.Infrastructure.Persistence.Configurations;
//public class LoanConfiguration : IEntityTypeConfiguration<Loan>
//{
//    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Loan> builder)
//    {
//       builder
//            .HasKey(e => e.Id);

//        builder
//            .HasOne(e => e.User)
//            .WithMany(e => e.Loans)
//            .HasForeignKey(e => e.IdUser);

//        builder
//            .HasOne(e => e.Book)
//            .WithMany(e => e.Loans)
//            .HasForeignKey(e => e.IdBook);
//    }
//}
