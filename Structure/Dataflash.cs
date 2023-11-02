using System.Collections.Generic;
using UDIE.Adrupilot.Dataflash.Structure.Formats.System;

namespace UDIE.Adrupilot.Dataflash.Structure
{
    public class Dataflash
    {
        public List<FMT> FormatMessages { get; set; } = new List<FMT>();
        public List<dynamic> Messages { get; set; } = new List<dynamic>();
    }
}