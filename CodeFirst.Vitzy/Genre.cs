using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CodeFirst.Vitzy
{
    public class Genre
    {
        public byte Id { get; set; }
        public string Name { get; set; }

        public ICollection<Video> Videos { get; set; } = new Collection<Video>();
    }
}
