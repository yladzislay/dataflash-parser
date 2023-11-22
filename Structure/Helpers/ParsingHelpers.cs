using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UDIE.Adrupilot.Dataflash.Structure.Formats.Battery;
using UDIE.Adrupilot.Dataflash.Structure.Formats.Communication;
using UDIE.Adrupilot.Dataflash.Structure.Formats.Custom.Engine;
using UDIE.Adrupilot.Dataflash.Structure.Formats.Custom.Powerboard;
using UDIE.Adrupilot.Dataflash.Structure.Formats.Custom.Unsorted;
using UDIE.Adrupilot.Dataflash.Structure.Formats.Engine;
using UDIE.Adrupilot.Dataflash.Structure.Formats.Navigation;
using UDIE.Adrupilot.Dataflash.Structure.Formats.Position;
using UDIE.Adrupilot.Dataflash.Structure.Formats.Sensors;
using UDIE.Adrupilot.Dataflash.Structure.Formats.System;
using UDIE.Adrupilot.Dataflash.Structure.Formats.Unsorted;

namespace UDIE.Adrupilot.Dataflash.Structure.Helpers
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
                // 0 - 128
                128 => ParseMessage<FMT>(message),
                129 => ParseMessage<PARM>(message),
                130 => ParseMessage<GPS>(message),
                131 => ParseMessage<GPS2>(message),
                132 => ParseMessage<GPSB>(message),
                133 => ParseMessage<IMU>(message),
                134 => ParseMessage<MSG>(message),
                135 => ParseMessage<RCIN>(message),
                136 => ParseMessage<RCOU>(message),
                137 => ParseMessage<RSSI>(message),
                138 => ParseMessage<IMU2>(message),
                139 => ParseMessage<BARO>(message),
                140 => ParseMessage<POWR>(message),
                141 => ParseMessage<AHR2>(message),
                142 => ParseMessage<SIM>(message),
                143 => ParseMessage<CMD>(message),
                144 => ParseMessage<RAD>(message),
                145 => ParseMessage<ST>(message),
                146 => ParseMessage<CAM>(message),
                147 => ParseMessage<IMU3>(message),
                148 => ParseMessage<TERR>(message),
                149 => ParseMessage<UBX1>(message),
                150 => ParseMessage<UBX2>(message),
                151 => ParseMessage<UBY1>(message),
                152 => ParseMessage<UBY2>(message),
                153 => ParseMessage<ESC1>(message),
                154 => ParseMessage<ESC2>(message),
                155 => ParseMessage<ESC3>(message),
                156 => ParseMessage<ESC4>(message),
                157 => ParseMessage<ESC5>(message),
                158 => ParseMessage<ESC6>(message),
                159 => ParseMessage<ESC7>(message),
                160 => ParseMessage<ESC8>(message),
                161 => ParseMessage<BAR2>(message),
                162 => ParseMessage<ARSP>(message),
                163 => ParseMessage<ATT>(message),
                164 => ParseMessage<BAT>(message),
                165 => ParseMessage<BAT2>(message),
                166 => ParseMessage<BCL>(message),
                167 => ParseMessage<BCL2>(message),
                168 => ParseMessage<MAG>(message),
                169 => ParseMessage<MAG2>(message),
                170 => ParseMessage<MAG3>(message),
                171 => ParseMessage<MODE>(message),
                172 => ParseMessage<GRAW>(message),
                173 => ParseMessage<GRXH>(message),
                174 => ParseMessage<GRXS>(message),
                175 => ParseMessage<SBFE>(message),
                176 => ParseMessage<ACC1>(message),
                177 => ParseMessage<ACC2>(message),
                178 => ParseMessage<ACC3>(message),
                179 => ParseMessage<GYR1>(message),
                180 => ParseMessage<GYR2>(message),
                181 => ParseMessage<GYR3>(message),
                182 => ParseMessage<POS>(message),
                183 => ParseMessage<PIDR>(message),
                184 => ParseMessage<PIDP>(message),
                185 => ParseMessage<PIDY>(message),
                186 => ParseMessage<PIDA>(message),
                187 => ParseMessage<PIDS>(message),
                188 => ParseMessage<DSTL>(message),
                189 => ParseMessage<VIBE>(message),
                190 => ParseMessage<IMT>(message),
                191 => ParseMessage<IMT2>(message),
                192 => ParseMessage<IMT3>(message),
                193 => ParseMessage<ORGN>(message),
                194 => ParseMessage<RPM>(message),
                195 => ParseMessage<GPA>(message),
                196 => ParseMessage<GPA2>(message),
                197 => ParseMessage<GPAB>(message),
                198 => ParseMessage<RFND>(message),
                199 => ParseMessage<BAR3>(message),
                200 => ParseMessage<DMS>(message),
                201 => ParseMessage<FMTU>(message),
                202 => ParseMessage<UNIT>(message),
                203 => ParseMessage<MULT>(message),
                204 => ParseMessage<SBPH>(message),
                // 205 - 208
                209 => ParseMessage<SBRH>(message),
                210 => ParseMessage<SBRM>(message),
                211 => ParseMessage<SBRE>(message),
                212 => ParseMessage<TRIG>(message),
                213 => ParseMessage<GMB1>(message),
                214 => ParseMessage<GMB2>(message),
                215 => ParseMessage<GMB3>(message),
                216 => ParseMessage<RATE>(message),
                217 => ParseMessage<RALY>(message),
                218 => ParseMessage<VISO>(message),
                // 219
                220 => ParseMessage<BCN>(message),
                221 => ParseMessage<PRX>(message),
                // 222
                223 => ParseMessage<SRTL>(message),
                224 => ParseMessage<ISBH>(message),
                225 => ParseMessage<ISBD>(message),
                226 => ParseMessage<ASP2>(message),
                227 => ParseMessage<PM>(message),
                // 228-229
                230 => ParseMessage<PBRD>(message),
                231 => ParseMessage<EM>(message),
                232 => ParseMessage<EM2>(message),
                233 => ParseMessage<ESM1>(message),
                234 => ParseMessage<ESM2>(message),
                235 => ParseMessage<ROTO>(message),
                // 236 - 245
                246 => ParseMessage<PSCZ>(message),
                247 => ParseMessage<PSC>(message),
                248 => ParseMessage<CUV>(message),
                249 => ParseMessage<SRV2>(message),
                250 => ParseMessage<SRV1>(message),
                251 => ParseMessage<CTRL>(message),
                252 => ParseMessage<NKT2>(message),
                253 => ParseMessage<NKT1>(message),
                // 254-255
                _ => null
            };
        }

        public static T ParseMessage<T>(IEnumerable bytes) where T : struct
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