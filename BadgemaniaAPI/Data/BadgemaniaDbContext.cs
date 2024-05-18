using BadgemaniaAPI.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BadgemaniaAPI.Data
{
    public class BadgemaniaDbContext : IdentityDbContext<CustomUser>        //: DbContext
    {
        public BadgemaniaDbContext(DbContextOptions<BadgemaniaDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Badge> Badges { get; set; }

        public DbSet<Badgegroup> Badgegroups { get; set; }

        public DbSet<Badgetype> Badgetypes { get; set; }

        public DbSet<School> Schools { get; set; }

        public DbSet<CustomUserBadge> CustomUserBadges { get; set; }

        public DbSet<CustomUserBadgegroup> CustomUserBadgegroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Badge>()
                .HasOne(b => b.Badegroup)
                .WithMany(b => b.Badges)
                .HasForeignKey(b => b.BadgegroupId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Badge>()
                .HasOne(b => b.Badgetype)
                .WithMany(b => b.Badges)
                .HasForeignKey(b => b.BadgetypeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CustomUserBadge>()
                .HasKey(cb => new { cb.CustomUserId, cb.BadgeId });

            modelBuilder.Entity<CustomUserBadge>()
                .HasOne(c => c.CustomUser)
                .WithMany(cb => cb.CustomUserBadges)
                .HasForeignKey(c => c.CustomUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CustomUserBadge>()
                .HasOne(b => b.Badge)
                .WithMany(cb => cb.CustomUserBadges)
                .HasForeignKey(b => b.BadgeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CustomUserBadgegroup>()
                .HasKey(cb => new { cb.CustomUserId, cb.BadgegroupId });

            modelBuilder.Entity<CustomUserBadgegroup>()
                .HasOne(c => c.CustomUser)
                .WithMany(cb => cb.CustomUserBadgegroups)
                .HasForeignKey(c => c.CustomUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CustomUserBadgegroup>()
                .HasOne(b => b.Badgegroup)
                .WithMany(cb => cb.CustomUserBadgegroups)
                .HasForeignKey(b => b.BadgegroupId)
                .OnDelete(DeleteBehavior.NoAction);

            var superAdminRoleId = "30cfae89-ac70-4d27-a033-384bf4287716";
            var schoolAdminRoleId = "71c497af-4809-40f2-82c2-c770eb00150a";
            var teacherRoleId = "82f4b7a1-c728-4522-a51d-04741cdeee2a";
            var studentRoleId = "f378e6ae-dbb3-415f-83ce-e069d4c16073";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = superAdminRoleId,
                    ConcurrencyStamp = superAdminRoleId,
                    Name = "SuperAdmin",
                    NormalizedName = "SuperAdmin".ToUpper(),
                },
                new IdentityRole
                {
                    Id = schoolAdminRoleId,
                    ConcurrencyStamp = schoolAdminRoleId,
                    Name = "SchoolAdmin",
                    NormalizedName = "SchoolAdmin".ToUpper(),
                },
                new IdentityRole
                {
                    Id = teacherRoleId,
                    ConcurrencyStamp = teacherRoleId,
                    Name = "Teacher",
                    NormalizedName = "Teacher".ToUpper(),
                },
                new IdentityRole
                {
                    Id = studentRoleId,
                    ConcurrencyStamp = studentRoleId,
                    Name = "Student",
                    NormalizedName = "Student".ToUpper(),
                }
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);

            var schools = new List<School>
            {
                new School
                {
                    Id = Guid.Parse("213b864f-c265-491c-a2cb-77038bc93e26"),
                    Name = "Väggaskolan",
                },
                new School
                {
                    Id = Guid.Parse("d8628307-3d6c-49bc-8c41-d53c482b1b93"),
                    Name = "Aleholmsskolan",
                }
            };

            modelBuilder.Entity<School>().HasData(schools);


            var customUser = new CustomUser
            {
                Id = "b383d2b5-5786-4188-b1b7-248ea6533cd9",
                Email = "vagga@admin.com",
                EmailConfirmed = true,
                UserName = "vagga@admin.com",
                NormalizedUserName = "VAGGA@ADMIN.COM",
                NormalizedEmail = "VAGGA@ADMIN.COM",
                SchoolId = Guid.Parse("213b864f-c265-491c-a2cb-77038bc93e26"),
            };

            PasswordHasher<CustomUser> passwordHasher = new PasswordHasher<CustomUser>();
            customUser.PasswordHash = passwordHasher.HashPassword(customUser, "Test1234");

            modelBuilder.Entity<CustomUser>().HasData(customUser);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = schoolAdminRoleId,
                UserId = customUser.Id
            });

            var customUser2 = new CustomUser
            {
                Id = "5f0da40b-c93e-4227-8747-45eaa53ccc78",
                Email = "vagga@teacher1.com",
                EmailConfirmed = true,
                UserName = "vagga@teacher1.com",
                NormalizedUserName = "VAGGA@TEACHER1.COM",
                NormalizedEmail = "VAGGA@TEACHER1.COM",
                SchoolId = Guid.Parse("213b864f-c265-491c-a2cb-77038bc93e26"),
            };

            PasswordHasher<CustomUser> passwordHasher2 = new PasswordHasher<CustomUser>();
            customUser2.PasswordHash = passwordHasher2.HashPassword(customUser2, "Test1234");

            modelBuilder.Entity<CustomUser>().HasData(customUser2);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = teacherRoleId,
                UserId = customUser2.Id
            });

            var customUser3 = new CustomUser
            {
                Id = "ea5d94ef-655a-4565-bde4-f2098d4f81d1",
                Email = "vagga@student1.com",
                EmailConfirmed = true,
                UserName = "vagga@student1.com",
                NormalizedUserName = "VAGGA@STUDENT1.COM",
                NormalizedEmail = "VAGGA@STUDENT1.COM",
                SchoolId = Guid.Parse("213b864f-c265-491c-a2cb-77038bc93e26"),
            };

            PasswordHasher<CustomUser> passwordHasher3 = new PasswordHasher<CustomUser>();
            customUser3.PasswordHash = passwordHasher3.HashPassword(customUser3, "Test1234");

            modelBuilder.Entity<CustomUser>().HasData(customUser3);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = studentRoleId,
                UserId = customUser3.Id
            });
        }
    }
}
