using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PP_lab1
{
    public class Buffer
    {
        private BitArray _frame;
        public BitArray receipt { get; set; }
        public BitArray[] _frameArray;
        public Buffer()
        {

        }
        public Buffer(BitArray frame)
        {
            _frame = frame;
        }
        public Buffer(BitArray[] frameArray)
        {
            _frameArray = frameArray;
        }

        public BitArray ReceiveFrame()
        {
            return _frame;
        }
        public BitArray[] ReceiveFrameArray()
        {
            return _frameArray;
        }
    }
}
