using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace MyFirstMobileApp.Models.Entities
{
    public class Movies
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        //[MaxLength(250), Unique]
        public string Name { get; set; }
        public string Trilogy { get; set; }
        public int Watched { get; set; } = 0;
    }
}

