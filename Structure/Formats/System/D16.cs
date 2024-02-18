using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.System;

/// <summary>
/// Структура D16 представляет собой формат записи 16-битных данных с временной меткой.
/// The D16 structure represents the format for recording 16-bit data with a timestamp.
/// </summary>

/// <remarks>
/// FMT, 6, 14, D16, QBh, TimeUS,Id,Value
/// </remarks>

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct D16
{
    /// <summary>
    /// Время в микросекундах с момента запуска системы.
    /// Time in microseconds since system startup.
    /// </summary>
    public ulong TimeUS { get; set; }

    /// <summary>
    /// Идентификатор данных.
    /// Data identifier.
    /// </summary>
    public byte Id { get; set; }

    /// <summary>
    /// Значение 16-битных данных.
    /// Value of the 16-bit data.
    /// </summary>
    public short Value { get; set; }
}