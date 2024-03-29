﻿namespace UDIE.Adrupilot.Dataflash.Structure.Helpers
{
    public enum ModeReasonsEnum // interface to set the vehicles mode
    {
        UNKNOWN,
        RC_COMMAND,
        GCS_COMMAND,
        RADIO_FAILSAFE,
        BATTERY_FAILSAFE,
        GCS_FAILSAFE,
        EKF_FAILSAFE,
        GPS_GLITCH,
        MISSION_END,
        THROTTLE_LAND_ESCAPE,
        FENCE_BREACHED,
        TERRAIN_FAILSAFE,
        BRAKE_TIMEOUT,
        FLIP_COMPLETE,
        AVOIDANCE,
        AVOIDANCE_RECOVERY,
        THROW_COMPLETE,
        TERMINATE,
        TOY_MODE,
        CRASH_FAILSAFE,
        SOARING_FBW_B_WITH_MOTOR_RUNNING,
        SOARING_THERMAL_DETECTED,
        SOARING_THERMAL_ESTIMATE_DETERIORATED,
        VTOL_FAILED_TRANSITION,
        VTOL_FAILED_TAKEOFF,
        FAILSAFE, // general failsafes, prefer specific failsafes over this as much as possible
        INITIALISED,
        SURFACE_COMPLETE,
        BAD_DEPTH,
        LEAK_FAILSAFE,
        SERVOTEST,
        STARTUP,
        SCRIPTING,
        UNAVAILABLE,
        AUTOROTATION_START,
        AUTOROTATION_BAILOUT,
        SOARING_ALT_TOO_HIGH,
        SOARING_ALT_TOO_LOW,
        SOARING_DRIFT_EXCEEDED
    }
}