using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEversol.Models
{
    class Session
    {
        protected int id;
        protected DateTime date;
        protected string title;
        protected string description;
        protected string folderDir;

        protected List<Subject> people = new List<Subject>();

        // Default Constructor
        public Session()
        {

        }

        // Constructor with now as date, title, desc
        public Session(string title, string desc)
        {
            this.date = new DateTime();
            this.title = title;
            this.description = desc;
        }

        // Constructor with custom date, title, desc
        public Session(DateTime date, string title, string desc)
        {
            this.date = date;
            this.title = title;
            this.description = desc;
        }

        // Constructor with custom date, title, desc
        public Session(int id, DateTime date, string title, string desc)
        {
            this.id = id;
            this.date = date;
            this.title = title;
            this.description = desc;
        }

        // This is the date getter/setter
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        // This is the date getter/setter
        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }

        // This is the title getter/setter
        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        //  Description getter / setter
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        // Folder Dir getter / setter
        public string FolderDirectory
        {
            get { return this.folderDir; }
            set { this.folderDir = value; }
        }
    }
}
