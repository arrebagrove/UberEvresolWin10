using System;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberEversol.DataModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
//using SQLite.Net.Attributes;

namespace UberEversol.DataModel
{
    public class UberEversolContext : DbContext
    {
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<TrackSubjects> TracksSubjects { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<MediaType> MediaTypes { get; set; }
        public DbSet<MediaRequest> MediaRequest { get; set; }
        public DbSet<Requestee> Requestors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite($"Filename=UberEversol.db");

            string databaseFilePath = "UberEversol.db";
            try
            {
                databaseFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, databaseFilePath);
            }
            catch (InvalidOperationException) { }

            optionsBuilder.UseSqlite($"Data source={databaseFilePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Make Session.id required
            modelBuilder.Entity<Session>();
        }
    }

    /// <summary>
    /// Session Entity
    /// </summary>
    public partial class Session
    {
        // Primary Key
        [Key]
        public int id { get; set; }
        [Required]
        public DateTime created { get; set; }
        [Required]
        [MaxLength(200), MinLength(1)]
        public string title { get; set; }
        [MaxLength(600)]
        public string description { get; set; }
        public string folderDir { get; set; }
        public int? hit_count { get; set; }

        // Navigation
        public virtual ICollection<Track> tracks { get; set; }
    }

    /// <summary>
    /// Track Entity
    /// </summary>
    public partial class Track
    {
        //Primary Key
        [Key]
        public int id { get; set; }

        public int index { get; set; }
        public DateTime created_date { get; set; }
        [Required]
        [MaxLength(200), MinLength(1)]
        public string title { get; set; }
        public string description { get; set; }
        public TimeSpan? duration { get; set; }
        public string keywords { get; set; }

        public string file_name { get; set; }
        public int file_size { get; set; }
        public string file_dir { get; set; }


        // Foreign Key to Sessions
        [Required]
        public int session_id { get; set; }
        [ForeignKey("session_id")]
        public Session session { get; set; }

        // Navigation
        public int subject_id { get; set; }
        [ForeignKey("subject_id")]
        public Subject subject { get; set; }
        //public virtual ICollection<Subject> subjects { get; set; }
    }

    /// <summary>
    /// Track and Subjects Many To Many relationship
    /// </summary>
    public partial class TrackSubjects
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("track_id")]
        public int track_id { get; set; }
        [ForeignKey("subject_id")]
        public int subject_id { get; set; }
    }

    /// <summary>
    /// Base class for Subject and Requestee
    /// </summary>
    public partial class Person
    {
        [Required]
        [MaxLength(100), MinLength(1)]
        public string first_name { get; set; }
        [Required]
        [MaxLength(200), MinLength(1)]
        public string last_name { get; set; }
        public DateTime? dob { get; set; }
    }

    /// <summary>
    /// Subject Entity
    /// </summary>
    public partial class Subject : Person
    {
        // Primary Key
        [Key]
        public int id { get; set; }
        [Required]
        public DateTime created { get; set; }

        public int hit_count { get; set; }
        public int recording_count { get; set; }
        public int user_rating { get; set; }
        public byte[] image { get; set; }     // Image of the subject
        public bool active { get; set; }
    }

    /// <summary>
    /// Requestee Entity which is also a person
    /// </summary>
    public partial class Requestee : Person
    {
        // Primary Key
        [Key]
        public int id { get; set; }
        [Required]
        public DateTime created { get; set; }
    }

    /// <summary>
    /// Media Type
    /// </summary>
    public partial class MediaType
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int index { get; set; }
        [Required]
        public string title { get; set; }
        public string description { get; set; }
    }

    /// <summary>
    /// Media Request
    /// </summary>
    public partial class MediaRequest
    {
        // Primary Key
        [Key]
        public int id { get; set; }

        [Required]
        public Requestee requestor { get; set; }
        [Required]
        public DateTime request_date { get; set; }
        public bool completed { get; set; }
        public DateTime completed_date { get; set; }
        public string email { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public MediaType media { get; set; }
        public string notes { get; set; }

        // Navigation
        public ICollection<Track> tracks { get; set; }
    }
}
