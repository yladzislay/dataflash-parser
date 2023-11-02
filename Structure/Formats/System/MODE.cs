using System;
using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.System
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MODE
    {
        // FMT, 171, 14, MODE, QMBB, TimeUS,Mode,ModeNum,Rsn

        public ulong TimeUS { get; set; }

        [MarshalAs(UnmanagedType.U1, SizeConst = 1)]
        private readonly byte _Mode;

        public string Mode => Enum.GetName(typeof(ModesEnum), ModeNum);

        public byte ModeNum { get; set; }

        private readonly byte _Rsn;

        public string Reason => Enum.GetName(typeof(ModeReasonsEnum), _Rsn);
    }
}
