using System.Collections.Generic;

namespace projektet
{

    class Podcast
    {
        public List<Avsnitt> AllaAvsnitt { get; set; }
        public string Namn { get; set; }
        public int updateringFrekvens { get; set; }
        public Kategori PodcastKategori { get; set; }

    }

}
