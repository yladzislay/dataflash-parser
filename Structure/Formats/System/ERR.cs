using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.System;

/// <summary>
/// Структура ERR используется для записи информации об ошибках, возникающих в системе.
/// The ERR structure is used to record information about errors occurring in the system.
/// </summary>

/// <remarks>
/// FMT, 5, 13, ERR, QBB, TimeUS,Subsys,ECode
/// </remarks>

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ERR
{
    /// <summary>
    /// Время, когда произошла ошибка, в микросекундах.
    /// Time at which the error occurred in microseconds.
    /// </summary>
    public ulong TimeUS { get; set; }

    /// <summary>
    /// Идентификатор подсистемы, в которой произошла ошибка.
    /// Identifier of the subsystem where the error occurred.
    /// </summary>
    public byte Subsys { get; set; }

    /// <summary>
    /// Код ошибки, указывающий на конкретный тип ошибки или события в подсистеме.
    /// Error code indicating the specific type of error or event in the subsystem.
    /// </summary>
    public byte ECode { get; set; }
}