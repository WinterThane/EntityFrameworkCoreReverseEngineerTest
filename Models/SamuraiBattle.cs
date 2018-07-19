using System;
using System.Collections.Generic;

namespace Models
{
    public partial class SamuraiBattle
    {
        public int SamuraiId { get; set; }
        public int BattleId { get; set; }

        public Battles Battle { get; set; }
        public Samurais Samurai { get; set; }
    }
}
