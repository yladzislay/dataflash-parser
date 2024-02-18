namespace UDIE.Adrupilot.Dataflash.Structure.Helpers;

/// <summary>
/// The ModesEnum enumeration defines various flight modes that can be engaged by the autopilot.
/// Перечисление ModesEnum определяет различные режимы полёта, которые могут быть активированы автопилотом.
/// </summary>
public enum ModesEnum
{
    /// <summary>
    /// Manual airframe angle with manual throttle.
    /// Ручной угол аппарата с ручным регулированием газа.
    /// </summary>
    STABILIZE =     0,

    /// <summary>
    /// Manual body-frame angular rate with manual throttle.
    /// Ручная скорость вращения кузова с ручным регулированием газа.
    /// </summary>
    ACRO =          1,

    /// <summary>
    /// Manual airframe angle with automatic throttle.
    /// Ручной угол аппарата с автоматическим регулированием газа.
    /// </summary>
    ALT_HOLD =      2,

    /// <summary>
    /// Fully automatic waypoint control using mission commands.
    /// Полностью автоматическое управление точками маршрута с использованием команд миссии.
    /// </summary>
    AUTO =          3,

    /// <summary>
    /// Fully automatic fly to coordinate or fly at velocity/direction using ground control station (GCS) immediate commands.
    /// Полностью автоматический полёт к координатам или полёт с заданной скоростью/направлением с использованием немедленных команд наземной станции управления (GCS).
    /// </summary>
    GUIDED =        4,

    /// <summary>
    /// Automatic horizontal acceleration with automatic throttle.
    /// Автоматическое горизонтальное ускорение с автоматическим регулированием газа.
    /// </summary>
    LOITER =        5,

    /// <summary>
    /// Automatic return to launching point.
    /// Автоматический возврат к точке запуска.
    /// </summary>
    RTL =           6,

    /// <summary>
    /// Automatic circular flight with automatic throttle.
    /// Автоматический круговой полёт с автоматическим регулированием газа.
    /// </summary>
    CIRCLE =        7,

    /// <summary>
    /// Automatic landing with horizontal position control.
    /// Автоматическая посадка с горизонтальным управлением положением.
    /// </summary>
    LAND =          9,

    /// <summary>
    /// Semi-autonomous position, yaw, and throttle control.
    /// Полуавтономное управление положением, курсом и регулированием газа.
    /// </summary>
    DRIFT =        11,

    /// <summary>
    /// Manual earth-frame angular rate control with manual throttle.
    /// Ручное управление угловой скоростью в земной системе координат с ручным регулированием газа.
    /// </summary>
    SPORT =        13,

    /// <summary>
    /// Automatically flip the vehicle on the roll axis.
    /// Автоматический переворот аппарата по крену.
    /// </summary>
    FLIP =         14,

    /// <summary>
    /// Automatically tune the vehicle's roll and pitch gains.
    /// Автоматическая настройка коэффициентов крена и тангажа аппарата.
    /// </summary>
    AUTOTUNE =     15,

    /// <summary>
    /// Automatic position hold with manual override, with automatic throttle.
    /// Автоматическое удержание положения с ручным переключением и автоматическим регулированием газа.
    /// </summary>
    POSHOLD =      16,

    /// <summary>
    /// Full-brake using inertial/GPS system, no pilot input.
    /// Полная остановка с использованием инерциальной/GPS системы, без управления пилота.
    /// </summary>
    BRAKE =        17,

    /// <summary>
    /// Throw to launch mode using inertial/GPS system, no pilot input.
    /// Режим запуска из броска с использованием инерциальной/GPS системы, без управления пилота.
    /// </summary>
    THROW =        18,

    /// <summary>
    /// Automatic avoidance of obstacles in the macro scale - e.g. full-sized aircraft.
    /// Автоматическое избегание препятствий в макромасштабе - например, полноразмерные воздушные суда.
    /// </summary>
    AVOID_ADSB =   19,

    /// <summary>
    /// Guided mode but only accepts attitude and altitude.
    /// Режим управления, но принимает только крен и высоту.
    /// </summary>
    GUIDED_NOGPS = 20,

    /// <summary>
    /// SMART_RTL returns to home by retracing its steps.
    /// SMART_RTL возвращает в точку дома, следуя тем же шагам.
    /// </summary>
    SMART_RTL =    21,

    /// <summary>
    /// FLOWHOLD holds position with optical flow without rangefinder.
    /// FLOWHOLD удерживает положение с помощью оптического потока без дальномера.
    /// </summary>
    FLOWHOLD  =    22,

    /// <summary>
    /// Follow attempts to follow another vehicle or ground station.
    /// Режим следования пытается следовать за другим транспортным средством или наземной станцией.
    /// </summary>
    FOLLOW    =    23,

    /// <summary>
    /// ZIGZAG mode is able to fly in a zigzag manner with predefined point A and point B.
    /// Режим ZIGZAG способен летать зигзагообразно между заранее определённой точкой A и точкой B.
    /// </summary>
    ZIGZAG    =    24,

    /// <summary>
    /// System ID mode produces automated system identification signals in the controllers.
    /// Режим идентификации системы генерирует автоматические сигналы идентификации системы в контроллерах.
    /// </summary>
    SYSTEMID  =    25,

    /// <summary>
    /// Autonomous autorotation.
    /// Автономная авторотация.
    /// </summary>
    AUTOROTATE =   26
}