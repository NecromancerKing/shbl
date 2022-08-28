using Microsoft.EntityFrameworkCore;
using Shbl.Spt.Model.Core.Entity.Activities;
using Shbl.Spt.Model.Core.Entity.Auth;
using Shbl.Spt.Model.Core.Entity.General;
using Shbl.Spt.Model.Core.Entity.Word;

namespace Shbl.Spt.Dal.Core.Context
{
    public class SptContext : DbContext
    {
        public SptContext(DbContextOptions<SptContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetTableName(entityType.DisplayName());
            }
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<SptUser> SptUsers { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<CfType> CfTypes { get; set; }
        public DbSet<CfTypeSpeaker> CfTypeSpeakers { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<WordSpeaker> WordSpeakers { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<SptUserActivity> SptUserActivities { get; set; }
        public DbSet<SptUserActivityDetail> SptUserActivityDetails { get; set; }
        public DbSet<EventLog> EventLogs { get; set; }
    }
}
