using System.Runtime.InteropServices;

namespace UDIE.Adrupilot.Dataflash.Structure.Formats.System;

/// <summary>
/// Структура MULT предназначена для отображения символа на числовой множитель.
/// The MULT structure is designed to map a single character to a numeric multiplier.
/// </summary>

/// <remarks>
/// FMT, 203, 20, MULT, Qbd, TimeUS,Id,Mult
/// </remarks>

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct MULT
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
    /// Числовой множитель.
    /// Numeric multiplier.
    /// </summary>
    public double Mult { get; set; }
}