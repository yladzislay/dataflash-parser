using System.Runtime.InteropServices;
using UDIE.Adrupilot.Dataflash.Structure.Helpers;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.Navigation
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GPSB
    {
        // @LoggerMessage: GPSB
        // FMT, 132, 50, GPSB, QBIHBcLLeffffB, TimeUS,Status,GMS,GWk,NSats,HDop,Lat,Lng,Alt,Spd,GCrs,VZ,Yaw,U
        // @Description: Information received from GNSS systems attached to the autopilot
        // @Field: TimeUS: microseconds since system startup
        // @Field: Status: GPS Fix type; 2D fix, 3D fix etc.
        // @Field: GMS: milliseconds since start of GPS Week
        // @Field: GWk: weeks since 5 Jan 1980
        // @Field: NSats: number of satellites visible
        // @Field: HDop: horizontal precision
        // @Field: Lat: latitude
        // @Field: Lng: longitude
        // @Field: Alt: altitude
        // @Field: Spd: speed
        // @Field: GCrs: ground course
        // @Field: VZ: vertical velocity
        // @Field: Yaw: vehicle yaw
        // @Field: U: boolean value indicating whether this GPS is in use

        public ulong TimeUS { get; set; }
        public byte Status { get; set; }
        public uint GMS { get; set; }
        public ushort Gwk { get; set; }
        public byte NStats { get; set; }

        private readonly short _HDop;
        private readonly int _Lat;
        private readonly int _Lng;
        private readonly int _Alt;

        public double HDop => _HDop.Toc();
        public double Lat => _Lat.ToL();
        public double Lng => _Lng.ToL();
        public double Alt => _Alt.Toe();

        public float Spd { get; set; }
        public float GCrs { get; set; }
        public float VZ { get; set; }
        public float Yaw { get; set; }
        public byte U { get; set; }
    }
}