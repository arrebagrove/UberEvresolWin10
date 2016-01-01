using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberEversol.Models;
using Microsoft.Data.Entity;

namespace UberEversol.Models
{
    public class MediaRequest
    {
        public int id;
        public string requestee;
        public string email;
        public string phone;
        //public enum media {"};
        private List<Track> tracks = new List<Track>();
    }
}
