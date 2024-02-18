using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.System;

/// <summary>
/// Структура FMTU определяет единицы измерения и множители, используемые для полей других сообщений.
/// The FMTU structure defines units and multipliers used for fields of other messages.
/// </summary>

/// <remarks>
/// FMT, 201, 44, FMTU, QBNN, TimeUS,FmtType,UnitIds,MultIds
/// </remarks>

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct FMTU
{
    /// <summary>
    /// Время в микросекундах с момента запуска системы.
    /// Time in microseconds since system startup.
    /// </summary>
    public ulong TimeUS { get; set; }

    /// <summary>
    /// Числовая ссылка на соответствующее сообщение FMT.
    /// Numeric reference to associated FMT message.
    /// </summary>
    public byte FmtType { get; set; }

    /// <summary>
    /// Каждый символ ссылается на сообщение UNIT. Единица в смещении соответствует полю с тем же смещением в FMT.Format.
    /// Each character refers to a UNIT message. The unit at an offset corresponds to the field at the same offset in FMT.Format.
    /// </summary>
    public string UnitIds { get; set; }

    /// <summary>
    /// Каждый символ ссылается на сообщение MULT. Множитель в смещении соответствует полю с тем же смещением в FMT.Format.
    /// Each character refers to a MULT message. The multiplier at an offset corresponds to the field at the same offset in FMT.Format.
    /// </summary>
    public string MultIds { get; set; }
}