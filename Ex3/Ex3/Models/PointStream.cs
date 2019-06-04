using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ex3.Models
{
    public class PointStream
    {
        private static PointStream instance;
        private IPointSource _source;
        
        private PointStream(IPointSource source)
        {
            this._source = source;
        }
        
        public static PointStream Instance()
        {
            return instance;
        }

        public static PointStream Instance(IPointSource source)
        {
            if (instance == null || source != instance._source)
            {
                instance = new PointStream(source);
            }
            return instance;
        }

        public Point GetPoint()
        {
            return _source.GetPoint();
        }

        public void Close()
        {
            this._source.Close();
        }
    }
}