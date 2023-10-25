namespace DataflashParser.Helpers.Enums
{
    public enum LogErrorSubsystemEnum : byte
    {
        MAIN = 1,
        RADIO = 2,
        COMPASS = 3,
        OPTFLOW = 4,   // not used
        FAILSAFE_RADIO = 5,
        FAILSAFE_BATT = 6,
        FAILSAFE_GPS = 7,   // not used
        FAILSAFE_GCS = 8,
        FAILSAFE_FENCE = 9,
        FLIGHT_MODE = 10,
        GPS = 11,
        CRASH_CHECK = 12,
        FLIP = 13,
        AUTOTUNE = 14,  // not used
        PARACHUTES = 15,
        EKFCHECK = 16,
        FAILSAFE_EKFINAV = 17,
        BARO = 18,
        CPU = 19,
        FAILSAFE_ADSB = 20,
        TERRAIN = 21,
        NAVIGATION = 22,
        FAILSAFE_TERRAIN = 23,
        EKF_PRIMARY = 24,
        THRUST_LOSS_CHECK = 25,
        FAILSAFE_SENSORS = 26,
        FAILSAFE_LEAK = 27,
        PILOT_INPUT = 28,
        FAILSAFE_VIBE = 29,
    }
}