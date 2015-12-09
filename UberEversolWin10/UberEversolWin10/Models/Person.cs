using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEversol
{
    class Subject
    {
        protected int id = 0;
        protected string first_name;
        protected string last_name;
        protected string full_name;
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

    }
}
