using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Battles
    {
        public Battles()
        {
            SamuraiBattle = new HashSet<SamuraiBattle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<SamuraiBattle> SamuraiBattle { get; set; }
    }
}
