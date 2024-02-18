using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.System;

/// <summary>
/// Структура D32 представляет собой формат записи 32-битных данных с временной меткой.
/// The D32 structure represents the format for recording 32-bit data with a timestamp.
/// </summary>

/// <remarks>
/// FMT, 8, 16, D32, QBi, TimeUS,Id,Value
/// </remarks>

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct D32
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
    /// Значение 32-битных данных.
    /// Value of the 32-bit data.
    /// </summary>
    public int Value { get; set; }
}