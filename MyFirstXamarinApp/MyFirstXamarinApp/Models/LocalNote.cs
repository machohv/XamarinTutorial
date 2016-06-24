using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Android.Graphics;

namespace MyFirstXamarinApp.Models
{
    [Table("Note")]
    public class LocalNote
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string ImagePath { get; set; }
        
    }
}
