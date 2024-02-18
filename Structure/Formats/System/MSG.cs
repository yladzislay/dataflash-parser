using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.System;

/// <summary>
/// Структура MSG предназначена для хранения текстовых сообщений.
/// The MSG structure is designed to store text messages.
/// </summary>

/// <remarks>
/// FMT, 134, 75, MSG, QZ, TimeUS,Message
/// </remarks>

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct MSG
{
    /// <summary>
    /// Время в микросекундах с момента запуска системы.
    /// Time in microseconds since system startup.
    /// </summary>
    public ulong TimeUS { get; set; }

    /// <summary>
    /// Текстовое сообщение.
    /// The text message.
    /// </summary>
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    public string Message { get; set; }
}