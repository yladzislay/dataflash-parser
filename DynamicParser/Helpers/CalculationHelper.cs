using System.Collections.Generic;
using System.Linq;
using GeoCoordinatePortable;

namespace Parser.Helpers
{
    public static class CalculationHelper
    {
        public static double CalculateTotalClimb(IEnumerable<double> hagls)
        {
            double previewElement = 0;
            double total = 0;

            foreach (var element in hagls)
            {
                if (element > previewElement) total += (element - previewElement);
                previewElement = element;
            }

            return total;
        }

        public static double GetDistance(double[] gpsLatitudePoints, double[] gpsLongitudePoints)
        {
            var result = new List<double>();

            for (var index = 0; index < gpsLatitudePoints.Length-1; index++)
            {
                var distane =
                    new GeoCoordinate(gpsLatitudePoints[index], gpsLongitudePoints[index])
                        .GetDistanceTo(
                        new GeoCoordinate(gpsLatitudePoints[index + 1], gpsLongitudePoints[index + 1]));

                result.Add(distane);
            }
            
            return result.Sum();
        }

        public static double GetMaxDistanceFromStartPoint(double[] gpsLatitudePoints, double[] gpsLongitudePoints)
        {
            var result = new List<double>();

            for (var index = 0; index < gpsLatitudePoints.Length - 1; index++)
            {
                result.Add(new GeoCoordinate(gpsLatitudePoints[0], gpsLongitudePoints[0]).GetDistanceTo(new GeoCoordinate(gpsLatitudePoints[index + 1], gpsLongitudePoints[index + 1])));
            }

            return result.Max();
        }
    }
}
