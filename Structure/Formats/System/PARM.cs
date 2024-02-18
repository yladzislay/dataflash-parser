using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.System;

/// <summary>
/// Структура PARM предназначена для хранения и передачи параметров.
/// The PARM structure is designed to store and transmit parameters.
/// </summary>

/// <remarks>
/// FMT, 129, 31, PARM, Nf, Name,Value
/// </remarks>

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PARM
{
    /// <summary>
    /// Имя параметра.
    /// The parameter name.
    /// </summary>
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
    public string Name { get; set; }

    /// <summary>
    /// Значение параметра.
    /// The parameter value.
    /// </summary>
    public float Value { get; set; }
}