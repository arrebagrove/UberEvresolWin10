using System;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberEversol.Model;

namespace UberEversol.Model
{
    public partial class Track
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Track() {}

        /// <summary>
        /// Constructor with now as date, title, desc
        /// </summary>
        /// <param name="title"></param>
        /// <param name="desc"></param>
        /// <param name="filePath"></param>
        public Track(string title, string desc, string filePath)
        {
            this.created_date = DateTime.Now;
            this.title = title;
            this.description = desc;
        }

        /// <summary>
        /// Constructor with custom date, title, desc
        /// </summary>
        /// <param name="date"></param>
        /// <param name="title"></param>
        /// <param name="desc"></param>
        public Track(DateTime date, string title, string desc)
        {
            this.created_date = date;
            this.title = title;
            this.description = desc;
        }

        /// <summary>
        /// Constructor with custom date, title, desc
        /// </summary>
        /// <param name="id"></param>
        /// <param name="created"></param>
        /// <param name="title"></param>
        /// <param name="desc"></param>
        public Track(int id, DateTime created, string title, string desc)
        {
            this.id = id;
            this.created_date = created;
            this.title = title;
            this.description = desc;
        }

        /// <summary>
        /// Add subject to subject list
        /// </summary>
        /// <param name="person"></param>
        public void appendSubjects(Subject person)
        {
           this.subjects.Add(person);
        }

        /// <summary>
        /// Add list of subjects to subjects list list
        /// </summary>
        /// <param name="people"></param>
        public void appendSubjects(List<Subject> people)
        {
            foreach (Subject p in people)
            {
               this.subjects.Add(p);
            }
        }

        /// <summary>
        /// Append word to keywords list
        /// </summary>
        /// <param name="kw"></param>
        public void appendKeyword(string kw)
        {
           this.keywords += ", " + kw;
        }

        /// <summary>
        /// Append list of words to keywords list
        /// </summary>
        /// <param name="kw"></param>
        public void appendKeywords(List<string> kw)
        {
            string delimeter = ",";
            this.keywords += kw.Aggregate((i, j) => i + delimeter + j);
        }

        /// <summary>
        /// Save the object to the database
        /// </summary>
        public void DBSave()
        {
            using (var db = new UberEversolContext())
            {
                db.Tracks.Add(this);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Update the database with changes
        /// </summary>
        public void DBUpdate()
        {
            using (var db = new UberEversolContext())
            {
                var result = db.Tracks.FirstOrDefault(t => t.id == this.id);
                if (result != null)
                {
                    result.id = this.id;
                    result.session_id = this.session_id;
                    result.title = this.title;
                    result.description = this.description;
                    result.duration = this.duration;
                    result.file_name = this.file_name;
                    result.file_dir = this.file_dir;
                    result.file_size = this.file_size;

                    result.subjects = this.subjects;
                    result.keywords = this.keywords;

                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        ///  Get the Subject from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A subject from database</returns>
        public Subject DBGet(int id)
        {
            if (id > 0)
            {
                using (var db = new UberEversolContext())
                {
                    Subject sub = (from s in db.Subjects
                                   where s.id == id
                                   select s).First();
                    return sub;
                }
            }
            return null;
        }

        /// <summary>
        /// Remove the selected subject from db
        /// </summary>
        /// <param name="id"></param>
        public void DBRemove()
        {
            using (var db = new UberEversolContext())
            {
                db.Tracks.Remove(this);
                db.SaveChanges();
            }
        }
    }
}
