﻿using System;
using System.Collections.Generic;

namespace Vidzy
{
    public class Video
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public virtual Genre Genre { get; set; }
        public byte GenreId { get; set; }
        public Classification Classification { get; set; }
        public  virtual ICollection<Tag> Tags { get; private set; }

        public Video()
        {
            Tags = new HashSet<Tag>();
        }
    }
}