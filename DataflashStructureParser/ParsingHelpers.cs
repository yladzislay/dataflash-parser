using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DataflashStructureParser.Formats.Battary;
using DataflashStructureParser.Formats.Communication;
using DataflashStructureParser.Formats.Custom.Engine;
using DataflashStructureParser.Formats.Custom.Powerboard;
using DataflashStructureParser.Formats.Custom.Unsorted;
using DataflashStructureParser.Formats.Engine;
using DataflashStructureParser.Formats.KalmanFilter.NKF;
using DataflashStructureParser.Formats.KalmanFilter.XKF;
using DataflashStructureParser.Formats.Navigation;
using DataflashStructureParser.Formats.Position;
using DataflashStructureParser.Formats.Sensors;
using DataflashStructureParser.Formats.System;
using DataflashStructureParser.Formats.Unsorted;

namespace DronesCloud.Logs.Extensions
{
    public static class ParsingHelpers
    {
        public static double Toc(this short value) => value / 100.0;
        public static double ToC(this ushort value) => value / 100.0;
        public static double Toe(this int value) => value / 100.0;
        public static double ToE(this uint value) => value / 100.0;
        public static double ToL(this int value) => value / 10000000.0;
        

        public static dynamic ByteArrayToStructure(byte type, IEnumerable<byte> message)
        {
            return type switch
            {
                128 => ByteArrayToStructure<FMT>(message),
                202 => ByteArrayToStructure<UNIT>(message),
                201 => ByteArrayToStructure<FMTU>(message),
                203 => ByteArrayToStructure<MULT>(message),
                129 => ByteArrayToStructure<PARM>(message),
                130 => ByteArrayToStructure<GPS>(message),
                131 => ByteArrayToStructure<GPS2>(message),
                132 => ByteArrayToStructure<GPSB>(message),
                195 => ByteArrayToStructure<GPA>(message),
                196 => ByteArrayToStructure<GPA2>(message),
                197 => ByteArrayToStructure<GPAB>(message),
                133 => ByteArrayToStructure<IMU>(message),
                134 => ByteArrayToStructure<MSG>(message),
                135 => ByteArrayToStructure<RCIN>(message),
                136 => ByteArrayToStructure<RCOU>(message),
                137 => ByteArrayToStructure<RSSI>(message),
                139 => ByteArrayToStructure<BARO>(message),
                140 => ByteArrayToStructure<POWR>(message),
                143 => ByteArrayToStructure<CMD>(message),
                144 => ByteArrayToStructure<RAD>(message),
                146 => ByteArrayToStructure<CAM>(message),
                212 => ByteArrayToStructure<TRIG>(message),
                162 => ByteArrayToStructure<ARSP>(message),
                226 => ByteArrayToStructure<ASP2>(message),
                164 => ByteArrayToStructure<BAT>(message),
                165 => ByteArrayToStructure<BAT2>(message),
                166 => ByteArrayToStructure<BCL>(message),
                167 => ByteArrayToStructure<BCL2>(message),
                163 => ByteArrayToStructure<ATT>(message),
                168 => ByteArrayToStructure<MAG>(message),
                171 => ByteArrayToStructure<MODE>(message),
                198 => ByteArrayToStructure<RFND>(message),
                200 => ByteArrayToStructure<DMS>(message),
                220 => ByteArrayToStructure<BCN>(message),
                221 => ByteArrayToStructure<PRX>(message),
                227 => ByteArrayToStructure<PM>(message),
                223 => ByteArrayToStructure<SRTL>(message),
                230 => ByteArrayToStructure<PBRD>(message),
                231 => ByteArrayToStructure<EM>(message),
                232 => ByteArrayToStructure<EM2>(message),
                233 => ByteArrayToStructure<ESM1>(message),
                234 => ByteArrayToStructure<ESM2>(message),
                235 => ByteArrayToStructure<ROTO>(message),
                138 => ByteArrayToStructure<IMU2>(message),
                147 => ByteArrayToStructure<IMU3>(message),
                141 => ByteArrayToStructure<AHR2>(message),
                182 => ByteArrayToStructure<POS>(message),
                142 => ByteArrayToStructure<SIM>(message),
                64 => ByteArrayToStructure<NKF1>(message),
                65 => ByteArrayToStructure<NKF2>(message),
                66 => ByteArrayToStructure<NKF3>(message),
                67 => ByteArrayToStructure<NKF4>(message),
                68 => ByteArrayToStructure<NKF5>(message),
                69 => ByteArrayToStructure<NKF6>(message),
                70 => ByteArrayToStructure<NKF7>(message),
                71 => ByteArrayToStructure<NKF8>(message),
                72 => ByteArrayToStructure<NKF9>(message),
                73 => ByteArrayToStructure<NKF0>(message),
                74 => ByteArrayToStructure<NKQ1>(message),
                75 => ByteArrayToStructure<NKQ2>(message),
                76 => ByteArrayToStructure<XKF1>(message),
                77 => ByteArrayToStructure<XKF2>(message),
                78 => ByteArrayToStructure<XKF3>(message),
                79 => ByteArrayToStructure<XKF4>(message),
                80 => ByteArrayToStructure<XKF5>(message),
                81 => ByteArrayToStructure<XKF6>(message),
                82 => ByteArrayToStructure<XKF7>(message),
                83 => ByteArrayToStructure<XKF8>(message),
                84 => ByteArrayToStructure<XKF9>(message),
                85 => ByteArrayToStructure<XKF0>(message),
                86 => ByteArrayToStructure<XKQ1>(message),
                87 => ByteArrayToStructure<XKQ2>(message),
                88 => ByteArrayToStructure<XKFD>(message),
                89 => ByteArrayToStructure<XKV1>(message),
                90 => ByteArrayToStructure<XKV2>(message),

                148 => ByteArrayToStructure<TERR>(message),
                149 => ByteArrayToStructure<UBX1>(message),
                150 => ByteArrayToStructure<UBX2>(message),
                151 => ByteArrayToStructure<UBY1>(message),
                152 => ByteArrayToStructure<UBY2>(message),

                172 => ByteArrayToStructure<GRAW>(message),
                173 => ByteArrayToStructure<GRXH>(message),
                174 => ByteArrayToStructure<GRXS>(message),
                175 => ByteArrayToStructure<SBFE>(message),

                153 => ByteArrayToStructure<ESC1>(message),
                154 => ByteArrayToStructure<ESC2>(message),
                155 => ByteArrayToStructure<ESC3>(message),
                156 => ByteArrayToStructure<ESC4>(message),
                157 => ByteArrayToStructure<ESC5>(message),
                158 => ByteArrayToStructure<ESC6>(message),
                159 => ByteArrayToStructure<ESC7>(message),
                160 => ByteArrayToStructure<ESC8>(message),

                169 => ByteArrayToStructure<MAG2>(message),
                170 => ByteArrayToStructure<MAG3>(message),

                176 => ByteArrayToStructure<ACC1>(message),
                177 => ByteArrayToStructure<ACC2>(message),
                178 => ByteArrayToStructure<ACC3>(message),

                179 => ByteArrayToStructure<GYR1>(message),
                180 => ByteArrayToStructure<GYR2>(message),
                181 => ByteArrayToStructure<GYR3>(message),

                183 => ByteArrayToStructure<PIDR>(message),
                184 => ByteArrayToStructure<PIDP>(message),
                185 => ByteArrayToStructure<PIDY>(message),
                228 => ByteArrayToStructure<PID1>(message),
                229 => ByteArrayToStructure<PID2>(message),
                186 => ByteArrayToStructure<PIDA>(message),
                187 => ByteArrayToStructure<PIDS>(message),

                188 => ByteArrayToStructure<DSTL>(message),

                161 => ByteArrayToStructure<BAR2>(message),

                199 => ByteArrayToStructure<BAR3>(message),
                189 => ByteArrayToStructure<VIBE>(message),
                190 => ByteArrayToStructure<IMT>(message),
                191 => ByteArrayToStructure<IMT2>(message),
                192 => ByteArrayToStructure<IMT3>(message),

                224 => ByteArrayToStructure<ISBH>(message),
                225 => ByteArrayToStructure<ISBD>(message),

                193 => ByteArrayToStructure<ORGN>(message),
                222 => ByteArrayToStructure<DSF>(message),
                194 => ByteArrayToStructure<RPM>(message),
                213 => ByteArrayToStructure<GMB1>(message),
                214 => ByteArrayToStructure<GMB2>(message),
                215 => ByteArrayToStructure<GMB3>(message),

                216 => ByteArrayToStructure<RATE>(message),
                217 => ByteArrayToStructure<RALY>(message),
                218 => ByteArrayToStructure<VISO>(message),
                204 => ByteArrayToStructure<SBPH>(message),
                209 => ByteArrayToStructure<SBRH>(message),
                210 => ByteArrayToStructure<SBRM>(message),
                211 => ByteArrayToStructure<SBRE>(message),

                11 => ByteArrayToStructure<ATUN>(message),
                12 => ByteArrayToStructure<ATDE>(message),
                14 => ByteArrayToStructure<PTUN>(message),
                3 => ByteArrayToStructure<OF>(message),
                2 => ByteArrayToStructure<CTUN>(message),

                13 => ByteArrayToStructure<MOTB>(message),

                4 => ByteArrayToStructure<EV>(message),
                6 => ByteArrayToStructure<D16>(message),
                7 => ByteArrayToStructure<DU16>(message),
                8 => ByteArrayToStructure<D32>(message),
                9 => ByteArrayToStructure<DU32>(message),
                10 => ByteArrayToStructure<DFLT>(message),
                5 => ByteArrayToStructure<ERR>(message),
                15 => ByteArrayToStructure<HELI>(message),
                16 => ByteArrayToStructure<PL>(message),
                17 => ByteArrayToStructure<GUID>(message),
                253 => ByteArrayToStructure<NKT1>(message),
                252 => ByteArrayToStructure<NKT2>(message),
                251 => ByteArrayToStructure<CTRL>(message),
                250 => ByteArrayToStructure<SRV1>(message),
                249 => ByteArrayToStructure<SRV2>(message),
                248 => ByteArrayToStructure<CUV>(message),
                247 => ByteArrayToStructure<PSC>(message),
                246 => ByteArrayToStructure<PSCZ>(message),
                _ => null
            };
        }

        private static T ByteArrayToStructure<T>(IEnumerable bytes) where T : struct
        {
            var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);

            try
            {
                return Marshal.PtrToStructure<T>(handle.AddrOfPinnedObject());
            }
            catch
            {
                return new T();
            }
            finally
            {
                handle.Free();
            }
        }
    }
}