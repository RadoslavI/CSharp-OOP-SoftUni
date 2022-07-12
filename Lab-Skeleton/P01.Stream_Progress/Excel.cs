using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class Excel : IFile
    {
        private int rows;
        private int cols;

        public Excel(int rows, int cols, int length, int bytesSent)
        {
            this.rows = rows;
            this.cols = cols;
            Length = length;
            BytesSent = bytesSent;
        }

        public int Length { get; }

        public int BytesSent { get; }
    }
}
