using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shroomsweeper
{
    [Serializable()]
    public class HighScore
    {
        public int Level { get; set; }
        public double? BestTime { get; set; }
    }
}
