using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendezvény
{
    class Event
    {
        private int _indexOfShow;
        private int _startTime;
        private int _endTime;


        public int IndxOfShow
        { get { return _indexOfShow; } set { _indexOfShow = value; } }
        public int StartTime
        { get { return _startTime; } set { _startTime = value; } }
        public int EndTime
        { get { return _endTime; } set { _endTime = value; } }


        public Event(int indexOfShow_, int statTime_, int endTime_)
        {
            _indexOfShow = indexOfShow_;
            _startTime = statTime_;
            _endTime = endTime_;
        }
    }
}
