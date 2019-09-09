using System;
using SQLite;

namespace TravelRecordsApp.Model
{
    public class Post
    {
        // SQLite attributes
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Experience { get; set; }
    }
}
