using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Razorweb.Models
{
    public class MyBlogContext : IdentityDbContext<AppUser>
    {
        // Bằng cách thiết lập như trên thì trong MyBlogContext ngoài chứa bảng Article thì nó còn chưa các bảng do IDentityDbContext triển khai
        public MyBlogContext(DbContextOptions<MyBlogContext> options) : base(options)
        {
            // Khai báo ở đây để sau nếu muốn thì sẽ thiết lập thêm
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Bỏ tiền tố AspNet của các bảng: mặc định các bảng trong IdentityDbContext có
            // tên với tiền tố AspNet như: AspNetUserRoles, AspNetUser ...
            // Đoạn mã sau chạy khi khởi tạo DbContext, tạo database sẽ loại bỏ tiền tố đó
            foreach (var entityType in modelBuilder.Model.GetEntityTypes ()) {
                var tableName = entityType.GetTableName ();
                if (tableName.StartsWith ("AspNet")) {
                    entityType.SetTableName (tableName.Substring (6));
                }
            }
        }
        public DbSet<Article> articles { get; set; }
    }
}