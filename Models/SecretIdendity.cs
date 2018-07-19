using System;
using System.Collections.Generic;

namespace Models
{
    public partial class SecretIdendity
    {
        public int Id { get; set; }
        public string RealName { get; set; }
        public int SamuraiId { get; set; }

        public Samurais Samurai { get; set; }
    }
}
