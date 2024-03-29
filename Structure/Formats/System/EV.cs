﻿using System;
using System.Runtime.InteropServices;
using UDIE.Adrupilot.Dataflash.Structure.Helpers;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.System
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EV
    {
        // FMT, 4, 12, EV, QB, TimeUS,Id

        public ulong TimeUS { get; set; }
        public byte Id { get; set; }
        public string Name => Enum.GetName(typeof(EventsEnum), Id);
    }
}