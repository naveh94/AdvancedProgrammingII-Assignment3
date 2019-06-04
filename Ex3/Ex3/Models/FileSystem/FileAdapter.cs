using System;

namespace Ex3.Models.FileSystem
{
    public class FileAdapter : IPointSource
    {
        PointFromNetwork pointFromNetwork;
        FileSaver fileSaver = new FileSaver();
       // Quadple quadple 
        string fileName; 

        public FileAdapter(PointFromNetwork client, string fileN)
        {
           
            this.fileName = fileN;
            this.pointFromNetwork = client;
            
        }
        public Point GetPoint()
        {
            Quadple quadple = pointFromNetwork.GetQuadaple();
            return new Point(quadple.Lon, quadple.Lat);
        }
        //where to save the values of he qudple?
        
    }
}
