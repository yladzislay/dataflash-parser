using System;
using System.Runtime.InteropServices;
using UDIE.Adrupilot.Dataflash.Structure.Helpers;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.System;

/// <summary>
/// Структура MODE отображает текущий режим полёта системы.
/// The MODE structure reflects the current flight mode of the system.
/// </summary>

/// <remarks>
/// FMT, 171, 14, MODE, QMBB, TimeUS,Mode,ModeNum,Rsn
/// </remarks>

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct MODE
{
    /// <summary>
    /// Время в микросекундах с момента запуска системы.
    /// Time in microseconds since system startup.
    /// </summary>
    public ulong TimeUS { get; set; }

    [MarshalAs(UnmanagedType.U1, SizeConst = 1)]
    private readonly byte _Mode;

    /// <summary>
    /// Текущий режим полёта.
    /// The current flight mode.
    /// </summary>
    public string Mode => Enum.GetName(typeof(ModesEnum), ModeNum);

    /// <summary>
    /// Числовое значение текущего режима полёта.
    /// The numeric value of the current flight mode.
    /// </summary>
    public byte ModeNum { get; set; }

    private readonly byte _Rsn;

    /// <summary>
    /// Причина изменения режима полёта, если доступно.
    /// The reason for the change in flight mode, if available.
    /// </summary>
    public string Reason => Enum.GetName(typeof(ModeReasonsEnum), _Rsn);
}