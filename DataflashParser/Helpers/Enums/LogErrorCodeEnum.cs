namespace DataflashParser.Helpers.Enums
{
    public enum LogErrorCodeEnum : byte
    {
        // general error codes
        ERROR_RESOLVED = 0,
        FAILED_TO_INITIALISE = 1,
        UNHEALTHY = 4,
        // subsystem specific error codes -- radio
        RADIO_LATE_FRAME = 2,
        // subsystem specific error codes -- failsafe_thr, batt, gps
        FAILSAFE_RESOLVED = 0,
        FAILSAFE_OCCURRED = 1,
        // subsystem specific error codes -- main
        MAIN_INS_DELAY = 1,
        // subsystem specific error codes -- crash checker
        CRASH_CHECK_CRASH = 1,
        CRASH_CHECK_LOSS_OF_CONTROL = 2,
        // subsystem specific error codes -- flip
        FLIP_ABANDONED = 2,
        // subsystem specific error codes -- terrain
        MISSING_TERRAIN_DATA = 2,
        // subsystem specific error codes -- navigation
        FAILED_TO_SET_DESTINATION = 2,
        RESTARTED_RTL = 3,
        FAILED_CIRCLE_INIT = 4,
        DEST_OUTSIDE_FENCE = 5,

        // parachute failed to deploy because of low altitude or landed
        PARACHUTE_TOO_LOW = 2,
        PARACHUTE_LANDED = 3,
        // EKF check definitions
        EKFCHECK_BAD_VARIANCE = 2,
        EKFCHECK_VARIANCE_CLEARED = 0,
        // Baro specific error codes
        BARO_GLITCH = 2,
        BAD_DEPTH = 3, // sub-only
        // GPS specific error coces
        GPS_GLITCH = 2,
    }
}