namespace UDIE.Adrupilot.Dataflash.Structure.Helpers;

/// <summary>
/// The EventsEnum enumeration defines various events that can occur during flight operations.
/// Перечисление EventsEnum определяет различные события, которые могут происходить во время полётных операций.
/// </summary>
public enum EventsEnum : byte
{
    /// <summary>
    /// AP state data.
    /// Данные состояния AP.
    /// </summary>
    DATA_AP_STATE                       = 7,

    /// <summary>
    /// Initialization of simple bearing data.
    /// Инициализация данных простого подшипника.
    /// </summary>
    DATA_INIT_SIMPLE_BEARING            = 9,

    /// <summary>
    /// UAV armed.
    /// Беспилотник вооружен.
    /// </summary>
    DATA_ARMED                          = 10,

    /// <summary>
    /// UAV disarmed.
    /// Беспилотник разоружен.
    /// </summary>
    DATA_DISARMED                       = 11,

    /// <summary>
    /// UAV auto-armed.
    /// Беспилотник автоматически вооружен.
    /// </summary>
    DATA_AUTO_ARMED                     = 15,

    /// <summary>
    /// Possible completion of landing.
    /// Возможное завершение посадки.
    /// </summary>
    DATA_LAND_COMPLETE_MAYBE            = 17,

    /// <summary>
    /// Landing completed.
    /// Посадка завершена.
    /// </summary>
    DATA_LAND_COMPLETE                  = 18,

    /// <summary>
    /// Not landed.
    /// Не посажено.
    /// </summary>
    DATA_NOT_LANDED                     = 28,

    /// <summary>
    /// GPS lost.
    /// Потеря GPS.
    /// </summary>
    DATA_LOST_GPS                       = 19,

    /// <summary>
    /// Flip maneuver started.
    /// Начата манёвр переворота.
    /// </summary>
    DATA_FLIP_START                     = 21,

    /// <summary>
    /// Flip maneuver completed.
    /// Манёвр переворота завершен.
    /// </summary>
    DATA_FLIP_END                       = 22,

    /// <summary>
    /// Home point set.
    /// Установлена точка дома.
    /// </summary>
    DATA_SET_HOME                       = 25,

    /// <summary>
    /// Simple mode activated.
    /// Активирован простой режим.
    /// </summary>
    DATA_SET_SIMPLE_ON                  = 26,

    /// <summary>
    /// Simple mode deactivated.
    /// Деактивирован простой режим.
    /// </summary>
    DATA_SET_SIMPLE_OFF                 = 27,

    /// <summary>
    /// Super simple mode activated.
    /// Активирован сверхпростой режим.
    /// </summary>
    DATA_SET_SUPERSIMPLE_ON             = 29,

    /// <summary>
    /// Autotune initialized.
    /// Инициализирована автотюнинг.
    /// </summary>
    DATA_AUTOTUNE_INITIALISED           = 30,

    /// <summary>
    /// Autotune disabled.
    /// Автотюнинг отключен.
    /// </summary>
    DATA_AUTOTUNE_OFF                   = 31,

    /// <summary>
    /// Autotune restarted.
    /// Перезапущен автотюнинг.
    /// </summary>
    DATA_AUTOTUNE_RESTART               = 32,

    /// <summary>
    /// Autotune successful.
    /// Успешный автотюнинг.
    /// </summary>
    DATA_AUTOTUNE_SUCCESS               = 33,

    /// <summary>
    /// Autotune failed.
    /// Неудачный автотюнинг.
    /// </summary>
    DATA_AUTOTUNE_FAILED                = 34,

    /// <summary>
    /// Autotune reached limit.
    /// Достигнут предел автотюнинга.
    /// </summary>
    DATA_AUTOTUNE_REACHED_LIMIT         = 35,

    /// <summary>
    /// Autotune pilot testing.
    /// Тестирование пилота автотюнинга.
    /// </summary>
    DATA_AUTOTUNE_PILOT_TESTING         = 36,

    /// <summary>
    /// Autotune saved gains.
    /// Сохранены коэффициенты автотюнинга.
    /// </summary>
    DATA_AUTOTUNE_SAVEDGAINS            = 37,

    /// <summary>
    /// Trim saved.
    /// Подрезка сохранена.
    /// </summary>
    DATA_SAVE_TRIM                      = 38,

    /// <summary>
    /// Waypoint added.
    /// Точка маршрута добавлена.
    /// </summary>
    DATA_SAVEWP_ADD_WP                  = 39,

    /// <summary>
    /// Fence enabled.
    /// Ограждение включено.
    /// </summary>
    DATA_FENCE_ENABLE                   = 41,

    /// <summary>
    /// Fence disabled.
    /// Ограждение отключено.
    /// </summary>
    DATA_FENCE_DISABLE                  = 42,

    /// <summary>
    /// Acro trainer disabled.
    /// Тренажер акробатики отключен.
    /// </summary>
    DATA_ACRO_TRAINER_DISABLED          = 43,

    /// <summary>
    /// Acro trainer leveling.
    /// Тренажер акробатики выравнивает.
    /// </summary>
    DATA_ACRO_TRAINER_LEVELING          = 44,

    /// <summary>
    /// Acro trainer limited.
    /// Ограничение тренажера акробатики.
    /// </summary>
    DATA_ACRO_TRAINER_LIMITED           = 45,

    /// <summary>
    /// Gripper grab.
    /// Хвататель захватывает.
    /// </summary>
    DATA_GRIPPER_GRAB                   = 46,

    /// <summary>
    /// Gripper release.
    /// Хвататель освобождает.
    /// </summary>
    DATA_GRIPPER_RELEASE                = 47,

    /// <summary>
    /// Parachute disabled.
    /// Парашют отключен.
    /// </summary>
    DATA_PARACHUTE_DISABLED             = 49,

    /// <summary>
    /// Parachute enabled.
    /// Парашют включен.
    /// </summary>
    DATA_PARACHUTE_ENABLED              = 50,

    /// <summary>
    /// Parachute released.
    /// Парашют выпущен.
    /// </summary>
    DATA_PARACHUTE_RELEASED             = 51,

    /// <summary>
    /// Landing gear deployed.
    /// Шасси развернуто.
    /// </summary>
    DATA_LANDING_GEAR_DEPLOYED          = 52,

    /// <summary>
    /// Landing gear retracted.
    /// Шасси втянуто.
    /// </summary>
    DATA_LANDING_GEAR_RETRACTED         = 53,

    /// <summary>
    /// Motors emergency stopped.
    /// Аварийная остановка двигателей.
    /// </summary>
    DATA_MOTORS_EMERGENCY_STOPPED       = 54,

    /// <summary>
    /// Motors emergency stop cleared.
    /// Сброс аварийной остановки двигателей.
    /// </summary>
    DATA_MOTORS_EMERGENCY_STOP_CLEARED  = 55,

    /// <summary>
    /// Motors interlock disabled.
    /// Защита двигателей отключена.
    /// </summary>
    DATA_MOTORS_INTERLOCK_DISABLED      = 56,

    /// <summary>
    /// Motors interlock enabled.
    /// Защита двигателей включена.
    /// </summary>
    DATA_MOTORS_INTERLOCK_ENABLED       = 57,

    /// <summary>
    /// Rotor run-up complete (helicopter only).
    /// Запуск ротора завершен (только вертолет).
    /// </summary>
    DATA_ROTOR_RUNUP_COMPLETE           = 58,

    /// <summary>
    /// Rotor speed below critical (helicopter only).
    /// Скорость вращения ротора ниже критической (только вертолет).
    /// </summary>
    DATA_ROTOR_SPEED_BELOW_CRITICAL     = 59,

    /// <summary>
    /// EKF altitude reset.
    /// Сброс высоты EKF.
    /// </summary>
    DATA_EKF_ALT_RESET                  = 60,

    /// <summary>
    /// Landing canceled by pilot.
    /// Посадка отменена пилотом.
    /// </summary>
    DATA_LAND_CANCELLED_BY_PILOT        = 61,

    /// <summary>
    /// EKF yaw reset.
    /// Сброс курса EKF.
    /// </summary>
    DATA_EKF_YAW_RESET                  = 62,

    /// <summary>
    /// ADS-B avoidance enabled.
    /// Избегание ADS-B включено.
    /// </summary>
    DATA_AVOIDANCE_ADSB_ENABLE          = 63,

    /// <summary>
    /// ADS-B avoidance disabled.
    /// Избегание ADS-B отключено.
    /// </summary>
    DATA_AVOIDANCE_ADSB_DISABLE         = 64,

    /// <summary>
    /// Proximity avoidance enabled.
    /// Избегание близости включено.
    /// </summary>
    DATA_AVOIDANCE_PROXIMITY_ENABLE     = 65,

    /// <summary>
    /// Proximity avoidance disabled.
    /// Избегание близости отключено.
    /// </summary>
    DATA_AVOIDANCE_PROXIMITY_DISABLE    = 66,

    /// <summary>
    /// Primary GPS changed.
    /// Изменена первичная GPS.
    /// </summary>
    DATA_GPS_PRIMARY_CHANGED            = 67,

    /// <summary>
    /// Winch relaxed.
    /// Лебедка расслаблена.
    /// </summary>
    DATA_WINCH_RELAXED                  = 68,

    /// <summary>
    /// Winch length control.
    /// Управление длиной лебедки.
    /// </summary>
    DATA_WINCH_LENGTH_CONTROL           = 69,

    /// <summary>
    /// Winch rate control.
    /// Управление скоростью лебедки.
    /// </summary>
    DATA_WINCH_RATE_CONTROL             = 70
}
