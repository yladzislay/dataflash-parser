using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.System;

/// <summary>
/// Структура FMT определяет формат сообщений DataFlash.
/// The FMT structure defines the format of DataFlash messages.
/// </summary>

/// <remarks>
/// FMT, 128, 89, FMT, BBnNZ, Type,Length,Name,Format,Columns
/// </remarks>

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct FMT
{
    /// <summary>
    /// Тип сообщения.
    /// Message type.
    /// </summary>
    public byte Type { get; set; }

    /// <summary>
    /// Длина сообщения.
    /// Message length.
    /// </summary>
    public byte Length { get; set; }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    private readonly byte[] _Name;

    /// <summary>
    /// Имя сообщения.
    /// Message name.
    /// </summary>
    public string Name => Encoding.ASCII.GetString(_Name).Trim('\0');

    /// <summary>
    /// Формат сообщения.
    /// Message format.
    /// </summary>
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
    public string Format { get; set; }

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    private readonly string _Columns;

    /// <summary>
    /// Список имен столбцов.
    /// List of column names.
    /// </summary>
    public IEnumerable<string> Columns => _Columns.Split(",");
}