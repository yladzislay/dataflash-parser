using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.System;

/// <summary>
/// Структура CMD представляет собой формат команды, отправляемой системе управления беспилотным летательным аппаратом (БПЛА).
/// The CMD structure represents the format of a command sent to the unmanned aerial vehicle (UAV) control system.
/// </summary>

/// <remarks>
/// FMT, 143, 46, CMD, QHHHfffffffB, TimeUS,CTot,CNum,CId,Prm1,Prm2,Prm3,Prm4,Lat,Lng,Alt,Frame
/// </remarks>

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct CMD
{
    /// <summary>
    /// Время в микросекундах с момента запуска системы.
    /// Time in microseconds since system startup.
    /// </summary>
    public ulong TimeUS { get; set; }

    /// <summary>
    /// Общее количество команд, которое будет выполняться.
    /// Total number of commands to be executed.
    /// </summary>
    public ushort CTot { get; set; }

    /// <summary>
    /// Номер текущей команды в последовательности.
    /// Current command number in the sequence.
    /// </summary>
    public ushort CNum { get; set; }

    /// <summary>
    /// Идентификатор команды.
    /// Command identifier.
    /// </summary>
    public ushort CId { get; set; }

    /// <summary>
    /// Параметр 1 команды.
    /// Command parameter 1.
    /// </summary>
    public float Prm1 { get; set; }

    /// <summary>
    /// Параметр 2 команды.
    /// Command parameter 2.
    /// </summary>
    public float Prm2 { get; set; }

    /// <summary>
    /// Параметр 3 команды.
    /// Command parameter 3.
    /// </summary>
    public float Prm3 { get; set; }

    /// <summary>
    /// Параметр 4 команды.
    /// Command parameter 4.
    /// </summary>
    public float Prm4 { get; set; }

    /// <summary>
    /// Широта, связанная с командой (если применимо).
    /// Latitude associated with the command (if applicable).
    /// </summary>
    public float Lat { get; set; }

    /// <summary>
    /// Долгота, связанная с командой (если применимо).
    /// Longitude associated with the command (if applicable).
    /// </summary>
    public float Lng { get; set; }

    /// <summary>
    /// Высота, связанная с командой (если применимо).
    /// Altitude associated with the command (if applicable).
    /// </summary>
    public float Alt { get; set; }

    /// <summary>
    /// Тип кадра команды.
    /// Frame type of the command.
    /// </summary>
    public byte Frame { get; set; }
}