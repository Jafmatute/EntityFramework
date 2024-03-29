﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CodeFirst.Vitzy
{
    public class Video
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Classification classification { get; set; }

        public byte GenreId { get; set; }
        public Genre Genre { get; set; }

        public ICollection<Tag> Tags { get; set; } = new Collection<Tag>();
    }
}
