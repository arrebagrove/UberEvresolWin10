using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using System.IO;
using Windows.Storage;
using UberEversol.DataModel;

namespace UberEversol.DataModel
{
    public partial class Subject
    {

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
        }

        /// <summary>
        /// Constructor with only Full Name
        /// </summary>
        /// <param name="full">Full Name</param>
        public Subject(string full)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

            string[] name = full.Split(delimiterChars); // Put all the names into an array
            this.first_name = name[0];
            this.last_name = name[1];
        }


        /// <summary>
        /// Rating Increment
        /// </summary>
        public void RatingPlus()
        {
            this.user_rating += 1;

            using (var db = new UberEversolContext())
            {
                var result = db.Subjects.FirstOrDefault(s => s.id == this.id);
                result.user_rating += 1;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Rating Decrement
        /// </summary>
        public void RatingMinus()
        {
            this.user_rating -= 1;

            using (var db = new UberEversolContext())
            {
                var result = db.Subjects.FirstOrDefault(s => s.id == this.id);
                result.user_rating -= 1;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Increment Hit Count
        /// </summary>
        public void Hit()
        {
            this.hit_count += 1;

            using (var db = new UberEversolContext())
            {
                var result = db.Subjects.FirstOrDefault(s => s.id == this.id);
                result.hit_count += 1;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Sets the image of the subject to storage
        /// </summary>
        /// <param name="imageFile"></param>
        public void setImage(StorageFile imageFile)
        {
            // Set the image file to string
            string fileType = imageFile.FileType;
            
        }

        /// <summary>
        /// Gets the storage file stored in the string
        /// </summary>
        /// <returns></returns>
        public StorageFile getImage()
        {
            return null;
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
        /// Update the database with changes
        /// </summary>
        public void DBUpdate()
        {
            using (var db = new UberEversolContext())
            {
                var result = db.Subjects.FirstOrDefault(s => s.id == this.id);
                if (result != null)
                {
                    result.first_name = this.first_name;
                    result.last_name = this.last_name;
                    result.created = this.created;
                    result.user_rating = this.user_rating;

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
                    Subject sub = (Subject)(from s in db.Subjects
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
                db.Subjects.Remove(this);
                db.SaveChanges();
            }
        }
    }
}
