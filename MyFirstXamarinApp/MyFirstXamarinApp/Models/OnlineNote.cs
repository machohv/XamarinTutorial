using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyFirstXamarinApp.Models
{
    public class OnlineNote
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string ImagePath { get; set; }
    }
}
