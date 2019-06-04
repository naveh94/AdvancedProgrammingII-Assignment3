using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ex3.Models.Network
{
    public class PointFromNetwork : IPointSource
    {
        private IClient _client;

        private readonly String GET_RUDDER = "get controls/flight/rudder\r\n";
        private readonly String GET_THROTTLE = "get controls/engines/current-engine/throttle\r\n";
        private readonly String GET_LAT = "get position/latitude-deg\r\n";
        private readonly String GET_LON = "get position/longitude-deg\r\n";

        public PointFromNetwork(IClient client)
        {
            this._client = client;
        }

        public Point GetPoint()
        {
            string Lon = _client.GetValue(GET_LON);
            string Lat = _client.GetValue(GET_LAT);
            return new Point(StringToValue(Lon), StringToValue(Lat));
        }

        public Quadple GetQuadple()
        {
            string Lon = _client.GetValue(GET_LON);
            string Lat = _client.GetValue(GET_LAT);
            string Rudder = _client.GetValue(GET_RUDDER);
            string Throttle = _client.GetValue(GET_THROTTLE);
            return new Quadple(StringToValue(Lon), StringToValue(Lat), StringToValue(Rudder), StringToValue(Throttle));
        }

        private double StringToValue(string input)
        {
            string[] split = input.Split(new char[] { '\'' });
            return double.Parse(split[1]);
        }

        public void Close()
        {
            this._client.Disconnect();
        }

    }
}