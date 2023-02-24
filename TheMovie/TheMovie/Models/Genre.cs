using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace TheMovie.Models
{
    public class Genre
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class AllGenre
    {
        public ObservableCollection<Genre> genres { get; set; }
    }
}
