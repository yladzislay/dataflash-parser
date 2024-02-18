namespace UDIE.Adrupilot.Dataflash.Structure.Helpers;

/// <summary>
/// Перечисление ModeReasonsEnum определяет причины изменения режима полёта.
/// The ModeReasonsEnum enumeration defines reasons for changing flight modes.
/// </summary>
public enum ModeReasonsEnum
{
    /// <summary>
    /// Неизвестная причина.
    /// Unknown reason.
    /// </summary>
    UNKNOWN,

    /// <summary>
    /// Команда с пульта управления.
    /// Remote control command.
    /// </summary>
    RC_COMMAND,

    /// <summary>
    /// Команда с наземного пункта управления.
    /// Ground control station command.
    /// </summary>
    GCS_COMMAND,

    /// <summary>
    /// Радиосвязь потеряна.
    /// Radio failsafe activated.
    /// </summary>
    RADIO_FAILSAFE,

    /// <summary>
    /// Аварийное отключение из-за низкого уровня заряда батареи.
    /// Emergency shutdown due to low battery voltage.
    /// </summary>
    BATTERY_FAILSAFE,

    /// <summary>
    /// Аварийное отключение из-за потери связи с наземным пунктом управления.
    /// Emergency shutdown due to lost ground control station connection.
    /// </summary>
    GCS_FAILSAFE,

    /// <summary>
    /// Аварийное отключение из-за ошибки крейсерского фильтра расширенной калибровки (EKF).
    /// Emergency shutdown due to extended kalman filter (EKF) cruiser filter error.
    /// </summary>
    EKF_FAILSAFE,

    /// <summary>
    /// Возникла ошибка с GPS.
    /// GPS glitch detected.
    /// </summary>
    GPS_GLITCH,

    /// <summary>
    /// Окончание миссии.
    /// Mission ended.
    /// </summary>
    MISSION_END,

    /// <summary>
    /// Предельный уровень тяги достигнут в режиме посадки.
    /// Maximum thrust level reached during landing mode.
    /// </summary>
    THROTTLE_LAND_ESCAPE,

    /// <summary>
    /// Обнаружено нарушение ограждения.
    /// Fence breached.
    /// </summary>
    FENCE_BREACHED,

    /// <summary>
    /// Аварийное отключение из-за ошибки террейн-модуля.
    /// Emergency shutdown due to terrain module error.
    /// </summary>
    TERRAIN_FAILSAFE,

        /// <summary>
    /// Тайм-аут торможения.
    /// Brake timeout.
    /// </summary>
    BRAKE_TIMEOUT,

    /// <summary>
    /// Завершение флипа.
    /// Flip complete.
    /// </summary>
    FLIP_COMPLETE,

    /// <summary>
    /// Избежание столкновения.
    /// Collision avoidance.
    /// </summary>
    AVOIDANCE,

    /// <summary>
    /// Восстановление после избежания столкновения.
    /// Collision avoidance recovery.
    /// </summary>
    AVOIDANCE_RECOVERY,

    /// <summary>
    /// Завершение броска.
    /// Throw complete.
    /// </summary>
    THROW_COMPLETE,

    /// <summary>
    /// Прекращение работы.
    /// Termination.
    /// </summary>
    TERMINATE,

    /// <summary>
    /// Игрушечный режим.
    /// Toy mode.
    /// </summary>
    TOY_MODE,

    /// <summary>
    /// Аварийное отключение из-за краша.
    /// Emergency shutdown due to crash.
    /// </summary>
    CRASH_FAILSAFE,

    /// <summary>
    /// Парящий режим FBW-B с работающим двигателем.
    /// Soaring FBW-B with motor running.
    /// </summary>
    SOARING_FBW_B_WITH_MOTOR_RUNNING,

    /// <summary>
    /// Обнаружена термальная воздушная масса.
    /// Thermal detected.
    /// </summary>
    SOARING_THERMAL_DETECTED,

    /// <summary>
    /// Оценка термальной воздушной массы ухудшилась.
    /// Thermal estimate deteriorated.
    /// </summary>
    SOARING_THERMAL_ESTIMATE_DETERIORATED,

    /// <summary>
    /// Неудачная трансформация в ВТОЛ.
    /// VTOL transition failed.
    /// </summary>
    VTOL_FAILED_TRANSITION,

    /// <summary>
    /// Неудачный взлёт в ВТОЛ.
    /// VTOL takeoff failed.
    /// </summary>
    VTOL_FAILED_TAKEOFF,

    /// <summary>
    /// Режим аварийной защиты.
    /// Failsafe mode.
    /// </summary>
    FAILSAFE,

    /// <summary>
    /// Инициализация.
    /// Initialization.
    /// </summary>
    INITIALISED,

    /// <summary>
    /// Завершение работы на поверхности.
    /// Surface completion.
    /// </summary>
    SURFACE_COMPLETE,

    /// <summary>
    /// Плохая глубина.
    /// Bad depth.
    /// </summary>
    BAD_DEPTH,

    /// <summary>
    /// Аварийное отключение из-за утечки.
    /// Emergency shutdown due to leak.
    /// </summary>
    LEAK_FAILSAFE,

    /// <summary>
    /// Тест сервоприводов.
    /// Servo test.
    /// </summary>
    SERVOTEST,

    /// <summary>
    /// Запуск.
    /// Startup.
    /// </summary>
    STARTUP,

    /// <summary>
    /// Сценарий.
    /// Scripting.
    /// </summary>
    SCRIPTING,

    /// <summary>
    /// Недоступность.
    /// Unavailability.
    /// </summary>
    UNAVAILABLE,

    /// <summary>
    /// Начало авторотации.
    /// Autorotation start.
    /// </summary>
    AUTOROTATION_START,

    /// <summary>
    /// Аварийное выход из авторотации.
    /// Emergency bailout from autorotation.
    /// </summary>
    AUTOROTATION_BAILOUT,

    /// <summary>
    /// Высота взлёта в парящем режиме слишком высока.
    /// Soaring altitude too high.
    /// </summary>
    SOARING_ALT_TOO_HIGH,

    /// <summary>
    /// Высота взлёта в парящем режиме слишком низкая.
    /// Soaring altitude too low.
    /// </summary>
    SOARING_ALT_TOO_LOW,

    /// <summary>
    /// Превышено допустимое отклонение парящего режима.
    /// Soaring drift exceeded.
    /// </summary>
    SOARING_DRIFT_EXCEEDED
}