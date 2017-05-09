using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrint
{
    class Felt
    {
        public int column { get; set; }
        public int row { get; set; }

        public Felt(int col, int row)
        {
            this.column = col;
            this.row = row;
        }
    }
}
