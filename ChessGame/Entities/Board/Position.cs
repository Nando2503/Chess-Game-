﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace board
{
    internal class Position
    {
        public int Line {  get; set; }
        public int Column { get; set; }

        public Position (int line, int column)
        {
            this.Line = line;
            this.Column = column;

        }

        public void DefineValues(int line, int column)
        {
            this.Line = line;
            this.Column = column;
        }


        public override string ToString()
        {
            return Line + ", " + Column;
        }

    }
}
