using Microsoft.EntityFrameworkCore;
using Cuba_Staterkit.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Cuba_Staterkit.Data
{
    public class Context : IdentityDbContext<IdentityUser>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public virtual DbSet<HomeWork> HomeWorks { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Quiz> Quizes { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }

    }
}
