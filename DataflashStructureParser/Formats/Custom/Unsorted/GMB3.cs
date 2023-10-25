using System.Runtime.InteropServices;

namespace DataflashStructureParser.Formats.Custom.Unsorted
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GMB3
    {
        // FMT, 215, 13, GMB3, Ihhh, TimeMS,rl_torque_cmd,el_torque_cmd,az_torque_cmd

        public uint TimeMS { get; set; }
        public short rl_torque_cmd { get; set; }
        public short el_torque_cmd { get; set; }
        public short az_torque_cmd { get; set; }
    }
}