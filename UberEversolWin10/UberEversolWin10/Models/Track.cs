using System;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberEversol.Models;

namespace UberEversol.Models
{
    public class Track
    {
        protected int id { get; set; }
        protected Session session;

        protected int index;
        protected string title;
        protected string description;
        protected TimeSpan duration;

        protected string file_name;
        protected int file_size;
        protected string file_dir;

        protected List<Subject> subjects = new List<Subject>(); // public virtual ICollection<Subject> subjects;
        protected List<string> keywords = new List<string>();

        // Default Constructor
        public Track()
        {

        }

        // Constructor with now as date, title, desc
        public Track(string title, string desc, string filePath)
        {
            //this.date = new DateTime();
            this.title = title;
            this.description = desc;
        }

        // Constructor with now as date, title, desc
        /*public Track(string title, string desc, FileStream file)
        {
            //this.date = new DateTime();
            this.title = title;
            this.description = desc;
        }*/

        // Constructor with custom date, title, desc
        public Track(DateTime date, string title, string desc)
        {
            //this.date = date;
            this.title = title;
            this.description = desc;
        }

        // Constructor with custom date, title, desc
        public Track(int id, DateTime date, string title, string desc)
        {
            this.id = id;
            //this.date = date;
            this.title = title;
            this.description = desc;
        }


        // Session getter/setter
        public Session getSession() { return this.session; }
        public void setSession(Session ses) { this.session = ses; }
        public void setSession(int id) {
            // get session from database
        }

        // Index getter/setter
        public int getIndex() { return this.index; }
        public void setIndex(int indx) { this.index = indx; }

        // Duration getter/setter
        public TimeSpan getDuration() { return this.duration; }
        public void setDuration(TimeSpan ts) { this.duration= ts; }

        // Date getter/setter
        public DateTime getDate() { return this.session.Date; }
        //public void setDate(DateTime date) { this.date = date; }

        // Title getter/setter
        public string getTitle() { return this.title; }
        public void setTitle(string title) { this.title = title; }

        //  Description getter / setter
        public string getDescription() { return this.description; }
        public void setDescription(string desc) { this.description = desc; }



        // File Name getter / setter
        public string getFileName() { return this.file_name; }
        public void setFileName(string fn) { this.file_name = fn; }

        // File Name getter / setter
        public int getFileSize() { return this.file_size; }
        public void setFileSize(int fs) { this.file_size = fs; }

        // File Dir getter / setter
        public string getFolderDir() { return this.file_dir; }
        public void setFolderDir(string dir) { this.file_dir = dir; }



        // Subjects getter / setter
        public List<Subject> getSubjects() { return this.subjects; }
        public void setSubjects(List<Subject> s) { this.subjects = s; }
        public void appendSubjects(List<Subject> people)
        {
            foreach (Subject p in people)
            {
                this.subjects.Add(p);
            }
        }

        // Keywords getter / setter
        public List<string> getKeywords() { return this.keywords; }
        public void setKeywords(List<string> kw) { this.keywords = kw; }
        public void appendKeywords(List<string> kw)
        {
            foreach (string w in kw)
            {
                this.keywords.Add(w);
            }
        }
    }
}
