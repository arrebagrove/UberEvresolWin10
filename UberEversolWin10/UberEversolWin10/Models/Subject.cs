using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace UberEversol
{
    public class Subject
    {
        protected int id = 0;
        protected string first_name;
        protected string last_name;
        protected string full_name;
        protected DateTime created;
        protected int hit_count;
        //protected file image;     // Image of the subject


        /// <summary>
        /// Default Constructor
        /// </summary>
        public Subject()
        {

        }


        /// <summary>
        /// Constructor with First Name and Last Name
        /// </summary>
        /// <param name="fname">First Name</param>
        /// <param name="lname">Last Name</param>
        public Subject(string fname, string lname)
        {
            this.first_name = fname;
            this.last_name = lname;
            this.full_name = fname + " " + lname;
        }

        /// <summary>
        /// Constructor with First Name, Last Name and Full Name
        /// </summary>
        /// <param name="fname">First Name</param>
        /// <param name="lname">Last Name</param>
        /// <param name="full">Full Name</param>
        public Subject(string fname, string lname, string full)
        {
            this.first_name = fname;
            this.last_name = lname;
            this.full_name = full;
        }

        /// <summary>
        /// Constructor with only Full Name
        /// </summary>
        /// <param name="full">Full Name</param>
        public Subject(string full)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

            this.full_name = full;

            string[] name = full.Split(delimiterChars); // Put all the names into an array
            this.first_name = name[0];
            this.last_name = name[1];
        }

        /// <summary>
        /// Id Name Getter / Setter
        /// </summary>
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        /// <summary>
        /// First Name Getter / Setter
        /// </summary>
        public string FirstName
        {
            get { return this.first_name; }
            set { this.first_name = value; }
        }

        /// <summary>
        /// Last Name Getter / Setter
        /// </summary>
        public string LastName
        {
            get { return this.last_name; }
            set { this.last_name= value; }
        }

        /// <summary>
        /// Full Name Getter / Setter
        /// </summary>
        public string FullName
        {
            get { return this.full_name; }
            set { this.full_name = value; }
        }

        /// <summary>
        /// Created Date Getter / Setter
        /// </summary>
        public DateTime Created
        {
            get { return this.created; }
            set { this.created = value; }
        }

        /// <summary>
        /// Rating Getter / Setter
        /// </summary>
        public int Rating
        {
            get { return this.hit_count; }
            set { this.hit_count = value; }
        }

        /// <summary>
        /// Save the object to the database
        /// </summary>
        public void DBSave()
        {
            using (var db = new UberEversolContext())
            {
                db.Subjects.Add(this);
                db.SaveChanges();
            }
        }

        /// <summary>
        ///  Get the Subject from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A subject from database</returns>
        public Subject DBGet(int id)
        {
            using (var db = new UberEversolContext())
            {
                Subject sub = (from s in db.Subjects
                                  where s.Id == id
                                  select s).First();

                if (sub != null)
                    return sub;
                else
                    return null;
            }
        }

        /// <summary>
        /// Remove the selected 
        /// </summary>
        /// <param name="id"></param>
        public void DBRemove()
        {
            using (var db = new UberEversolContext())
            {
                db.Subjects.Remove(this);
                db.SaveChanges();
            }
        }
    }
}
