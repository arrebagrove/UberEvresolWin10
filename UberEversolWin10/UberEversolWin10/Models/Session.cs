using System;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEversol.DataModel
{
    
    public partial class Session
    {
        

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Session() { }

        /// <summary>
        /// Constructor with id
        /// </summary>
        /// <param name="id"></param>
        public Session(int id)
        {
            this.id = id;
            this.created = DateTime.Now;
            this.title = null;
            this.description = null;
            this.folderDir = null;
        }

        /// <summary>
        /// Constructor with now as created, title, desc
        /// </summary>
        /// <param name="title"></param>
        /// <param name="desc"></param>
        public Session(string title, string desc)
        {
            this.created = new DateTime();
            this.title = title;
            this.description = desc;
        }

        /// <summary>
        /// Constructor with custom created, title, desc
        /// </summary>
        /// <param name="created"></param>
        /// <param name="title"></param>
        /// <param name="desc"></param>
        public Session(DateTime created, string title, string desc)
        {
            this.created = created;
            this.title = title;
            this.description = desc;
        }

        /// <summary>
        /// Constructor with custom created, title, desc
        /// </summary>
        /// <param name="id"></param>
        /// <param name="created"></param>
        /// <param name="title"></param>
        /// <param name="desc"></param>
        public Session(int id, DateTime created, string title, string desc)
        {
            this.id = id;
            this.created = created;
            this.title = title;
            this.description = desc;
        }

        /// <summary>
        /// Get Session record from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Session DBGet(int id)
        {
            // Populate object with data from database
            using (var db = new UberEversolContext())
            {
                // Load the session
                Session ses = (from s in db.Sessions
                               where s.id == id
                               select s).First();

                // Load the tracks
                ses.tracks = (from t in db.Tracks
                              where t.session_id == ses.id
                              select t).ToList();

                foreach(Track t in ses.tracks)
                    t.loadStructures();

                return ses;
            }
        }

        /// <summary>
        /// Save the object to the database
        /// </summary>
        public void DBSave()
        {
            using (var db = new UberEversolContext())
            {
                db.Sessions.Add(this);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Update the database with changes
        /// </summary>
        public int DBUpdate()
        {
            try
            {
                using (var db = new UberEversolContext())
                {
                    var result = db.Sessions.FirstOrDefault(s => s.id == this.id);
                    if (result != null)
                    {
                        result.title = this.title;
                        result.description = this.description;
                        result.folderDir = this.folderDir;
                        result.created = this.created;
                        result.hit_count = this.hit_count;

                        db.SaveChanges();
                    }
                }
                return 0;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        /// <summary>
        /// Remove the selected session from DB
        /// </summary>
        /// <param name="id"></param>
        public void DBRemove()
        {
            using (var db = new UberEversolContext())
            {
                db.Sessions.Remove(this);
                db.SaveChanges();
            }
        }


        /// <summary>
        /// Gets the highest last index in tracks list for this session
        /// </summary>
        /// <returns>max index</returns>
        public int getMaxTrackIndex()
        {
            int maxIndx = 0;
            using (var db = new UberEversolContext())
            {
                db.Sessions.Remove(this);
                maxIndx = db.Tracks.Where(t => t.session_id == this.id).Max(t => t.index);
            }
            return maxIndx;
        }
    }
}
