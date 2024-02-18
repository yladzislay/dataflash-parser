using System;
using System.Runtime.InteropServices;
using UDIE.Adrupilot.Dataflash.Structure.Helpers;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.System;

/// <summary>
/// Структура EV используется для записи событий.
/// The EV structure is used to record events.
/// </summary>

/// <remarks>
/// FMT, 4, 12, EV, QB, TimeUS,Id
/// </remarks>

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct EV
{
    /// <summary>
    /// Время в микросекундах с момента запуска системы.
    /// Time in microseconds since system startup.
    /// </summary>
    public ulong TimeUS { get; set; }

    /// <summary>
    /// Идентификатор события.
    /// Event identifier.
    /// </summary>
    public byte Id { get; set; }

    /// <summary>
    /// Имя события на основе перечисления EventsEnum.
    /// Event name based on the EventsEnum enumeration.
    /// </summary>
    public string Name => Enum.GetName(typeof(EventsEnum), Id);
}