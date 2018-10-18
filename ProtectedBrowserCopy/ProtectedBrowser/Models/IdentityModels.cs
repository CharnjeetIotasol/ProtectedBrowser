using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProtectedBrowser.Common.Extensions;

namespace ProtectedBrowser.Models
{
    public class CustomUserRole : IdentityUserRole<long> { }
    public class CustomUserClaim : IdentityUserClaim<long> { }
    public class CustomUserLogin : IdentityUserLogin<long> { }

    public class CustomRole : IdentityRole<long, CustomUserRole>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }
    }

    public class CustomUserStore : UserStore<ApplicationUser, CustomRole, long,
        CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }

    public class CustomRoleStore : RoleStore<CustomRole, long, CustomUserRole>
    {
        public CustomRoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser<long, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public ApplicationUser()
        {
            IsActive = true;
            IsDeleted = false;
            UniqueCode = CommonMethods.GetUniqueKey();
            IsFacebookConnected = false;
            IsGoogleConnected = false;
        }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePic { get; set; }
        public string UniqueCode { get; set; }
        public bool? IsFacebookConnected { get; set; }
        public bool? IsGoogleConnected { get; set; }
        public string FacebookId { get; set; }
        public string GoogleId { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager userManager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await userManager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, long> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, CustomRole, long, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>()
            .ToTable("Users");

            modelBuilder.Entity<CustomRole>()
                .ToTable("Roles");

            modelBuilder.Entity<CustomUserRole>()
                .ToTable("UserRoles");

            modelBuilder.Entity<CustomUserClaim>()
                .ToTable("UserClaims");

            modelBuilder.Entity<CustomUserLogin>()
                .ToTable("UserLogins");
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
