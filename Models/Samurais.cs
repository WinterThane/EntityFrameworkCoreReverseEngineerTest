using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Samurais
    {
        public Samurais()
        {
            Quotes = new HashSet<Quotes>();
            SamuraiBattle = new HashSet<SamuraiBattle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public SecretIdendity SecretIdendity { get; set; }
        public ICollection<Quotes> Quotes { get; set; }
        public ICollection<SamuraiBattle> SamuraiBattle { get; set; }
    }
}
