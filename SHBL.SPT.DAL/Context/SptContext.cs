using SHBL.SPT.Model.Activities;
using SHBL.SPT.Model.Auth;
using SHBL.SPT.Model.General;
using SHBL.SPT.Model.Word;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SHBL.SPT.DAL.Context
{
    public class SptContext : DbContext
    {
        private static string SptConnection = ConfigurationManager.ConnectionStrings["SPTDB"].ConnectionString;

        public SptContext()
            : base(SptConnection)
        {
            Database.SetInitializer<SptContext>(null);
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Person>().ToTable("Person", "dbo");
            modelBuilder.Entity<SptUser>().ToTable("SptUser", "dbo");
            modelBuilder.Entity<Word>().ToTable("Word", "dbo");
            modelBuilder.Entity<CFType>().ToTable("CFType", "dbo");
            modelBuilder.Entity<CFTypeSpeaker>().ToTable("CFTypeSpeaker", "dbo");
            modelBuilder.Entity<Speaker>().ToTable("Speaker", "dbo");
            modelBuilder.Entity<WordSpeaker>().ToTable("WordSpeaker", "dbo");
            modelBuilder.Entity<Activity>().ToTable("Activity", "dbo");
            modelBuilder.Entity<SptUserActivity>().ToTable("SptUserActivity", "dbo");
            modelBuilder.Entity<SptUserActivityDetail>().ToTable("SptUserActivityDetail", "dbo");

            modelBuilder.Entity<EventLog>().ToTable("EventLog", "dbo");
        }

        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<SptUser> SptUsers { get; set; }
        public virtual DbSet<Word> Words { get; set; }
        public virtual DbSet<CFType> CFTypes { get; set; }
        public virtual DbSet<CFTypeSpeaker> CFTypeSpeakers { get; set; }
        public virtual DbSet<Speaker> Speakers { get; set; }
        public virtual DbSet<WordSpeaker> WordSpeakers { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<SptUserActivity> SptUserActivities { get; set; }
        public virtual DbSet<SptUserActivityDetail> SptUserActivityDetails { get; set; }
        public virtual DbSet<EventLog> EventLogs { get; set; }

    }
}
