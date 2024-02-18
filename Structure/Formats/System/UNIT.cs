using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.System;

/// <summary>
/// Структура UNIT предназначена для отображения символа на единицу измерения SI.
/// The UNIT structure is designed to map a single character to an SI unit.
/// </summary>

/// <remarks>
/// FMT, 202, 76, UNIT, QbZ, TimeUS,Id,Label
/// </remarks>

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct UNIT
{
    /// <summary>
    /// Время в микросекундах с момента запуска системы.
    /// Time in microseconds since system startup.
    /// </summary>
    public ulong TimeUS { get; set; }

    /// <summary>
    /// Символ, на который ссылается FMTU.
    /// The character referenced by FMTU.
    /// </summary>
    public sbyte Id { get; set; }

    /// <summary>
    /// Единица измерения SI.
    /// SI unit.
    /// </summary>
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    public string Label { get; set; }
}