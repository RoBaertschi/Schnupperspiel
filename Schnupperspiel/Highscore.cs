using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schnupperspiel
{
    class Highscore
    {
        public int highscore;
        public Highscore(int highscore)
        {
            this.highscore = highscore;
        }

        public int GetHighscore()
        {
            return this.highscore;
        }
    }
}
