using System.Collections.Generic;
using System.Linq;
using GeoCoordinatePortable;

namespace UDIE.Adrupilot.Dataflash.Dynamic.Helpers.Extracting
{
    public static class CalculationHelper
    {
        private static IEnumerable<double> CalculateClimbs(IEnumerable<double> altitudes) =>
            altitudes.Zip(altitudes.Skip(1), (current, next) => current > next ? current - next : 0);

        public static double CalculateTotalClimb(IEnumerable<double> altitudeItems) =>
            CalculateClimbs(altitudeItems).Sum();
        
        private static IEnumerable<double> CalculateGpsPointToPointDistance(double[] gpsLatitudePoints, double[] gpsLongitudePoints) =>
            Enumerable.Range(0, gpsLatitudePoints.Length - 1)
                .Select(index => new GeoCoordinate(gpsLatitudePoints[index], gpsLongitudePoints[index])
                    .GetDistanceTo(new GeoCoordinate(gpsLatitudePoints[index + 1], gpsLongitudePoints[index + 1])));
        
        public static double CalculateGpsTotalPassedDistance(double[] gpsLatitudePoints, double[] gpsLongitudePoints) => 
            CalculateGpsPointToPointDistance(gpsLatitudePoints, gpsLongitudePoints)
                .Sum();

        private static IEnumerable<double> CalculateGpsPointToStartPointDistance(double[] gpsLatitudePoints, double[] gpsLongitudePoints) =>
            Enumerable.Range(0, gpsLatitudePoints.Length - 1)
                .Select(index => new GeoCoordinate(gpsLatitudePoints[index], gpsLongitudePoints[index])
                    .GetDistanceTo(new GeoCoordinate(gpsLatitudePoints[0], gpsLongitudePoints[0])));

        public static double CalculateMaxDistanceFromStartPoint(double[] gpsLatitudePoints, double[] gpsLongitudePoints) =>
            CalculateGpsPointToStartPointDistance(gpsLatitudePoints, gpsLongitudePoints).Max();
    }
}
