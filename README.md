# ParsePID

*	Author: subdiesel, Subaru Diesel Crew <http://subdiesel.wordpress.com/>

*	Project homepage and source code: <http://github.com/SubaruDieselCrew/ParsePID/>



## CONTENTS

1.	[Purpose](#purpose)
2.	[License](#license)
3.	[Requirements](#requirements)
4.	[Build](#build)
5.	[Data Files](#data_files)
6.	[Demo Output](#demo_output)
	*	[2011 Impreza Turbo Diesel 2.0 6MT, Euro 5, CID JZ4A110B](#JZ4A110B)
	*	[2014 Forester FB25 non-Turbo, CVT, CID EA1M220F](#EA1M220F)
	*	[2015 Forester Turbo Diesel 2.0 CVT, Euro 6, CID JF7C100D](#JF7C100D)

---

## <a name="purpose"></a> 1) Purpose

*ParsePID* is a console application to analyse **Extended/Enhanced OBD-II mode 22 capabilities**, specifically for **Subaru diesel and petrol** control units supporting this protocol.

Protocol details: [Subaru Diesel Crew: Extended OBD-II](https://subdiesel.wordpress.com/generic/protocols/extended-obd-ii/)

---

## <a name="license"></a> 2) License

GPLv3. See text file [COPYING.txt](COPYING.txt) for license text.

[http://fsf.org/](http://fsf.org/ "Free Software Foundation")

You can also get license text in different formats and further details there.

[http://www.gnu.org/licenses/gpl.html](http://www.gnu.org/licenses/gpl.html)

[http://www.gnu.org/licenses/gpl-faq.html](http://www.gnu.org/licenses/gpl-faq.html)

---

## <a name="requirements"></a> 3) Requirements

*	**.NET 4** or later, or any compatible runtime.

Compiled executable should be platform-independent.

Currently this project is mainly developed and tested using *mono* and *monodevelop* on Linux.

Links:

*	<http://www.mono-project.com/>

*	<http://monodevelop.com/>

*	<http://www.microsoft.com/net>

---

## <a name="build"></a> 4) Build

Either use an IDE (Integrated Development Environment) like *MonoDevelop* or *Visual Studio*, or just type in commands.

### 4.1) Manually

#### 4.1.1) Mono (Linux)

Mono provides `xbuild` command line tool.
Besides main runtime package (often named `mono`, `mono-runtime` or `mono-core`), on some Linux distributions required additional packages might be called *mono-devel* ([Ubuntu](http://packages.ubuntu.com/search?keywords=mono-devel), [Debian](https://packages.debian.org/search?keywords=mono-devel&searchon=names)) or *mono-dev*.

`xbuild /property:Configuration=Release ParsePID.sln`

or

`xbuild /property:Configuration=Debug ParsePID.sln`

or just `xbuild` (defaults to debug build, picks solution/project file in current directory)

run:

`bin/Release/ParsePID.exe`

or, respectively:

`bin/Debug/ParsePID.exe`

#### 4.1.2) Windows

Like on Linux, just replace `xbuild` with `msbuild`.
You might need to find and specify exact path of `msbuild.exe`, exact location depends on Windows and .NET version.

If not in path, consider adding tools directory to environment variable `%PATH%`, either temporarily (see below) or in Windows system settings.

Windows 8.1 x64 and Windows 10 tested example:
	
Open *Command Prompt* window and type:

	SET PATH=%PATH%;C:\Windows\Microsoft.NET\Framework\v4.0.30319\
	
	msbuild

run:

`bin/Debug/ParsePID.exe`

### 4.2) Integrated Development Environment (IDE)

*	*MonoDevelop* (Linux) / *Xamarin Studio* (Windows)
<http://monodevelop.com/>

	Multi-platform, tested on Linux and Windows.
	
	It is **open source**, written in C#, uses *Mono*'s `xbuild` for compilation.
	
	So far, ParsePID has been written using *MonoDevelop* on Linux exclusively.

*	*Visual Studio*
	<http://www.visualstudio.com/>

	Obviously Windows-only, uses `msbuild` under the hood.
	
	Free *Community* edition is more than capable, older *Express* versions should also work.

*	Others: not tested yet

---

## <a name="data_files"></a> 5) Data Files

See `data` subfolder for (demo) data files. No guarantees for correctness as usual.
The program uses pre-compiled paths if arguments are missing.

### 5.1) Parameter Definitions

*	`Subaru_mode22_def.csv`

	Subaru Diesel Crew, <https://subdiesel.wordpress.com/generic/protocols/extended-obd-ii/>

### 5.2) Response Data

*	`2011 Impreza Diesel Responses.txt`

	2011 Impreza Turbo Diesel 2.0 6MT, Euro 5, CID `JZ4A110B`

	courtesy of Subaru Diesel Crew

*	`2014 Forester FB25 non-Turbo Responses.txt`

	engine FB25, CVT, non-turbo, CID `EA1M220F`

	contribution by Alexander

*	`2015 Forester Diesel CVT Responses.txt`

	2015 Forester Turbo Diesel 2.0 CVT, Euro 6, CID `JF7C100D`

	courtesy of Subaru Diesel Crew

---

## <a name="demo_output"></a> 6) Demo Output

### <a name="JZ4A110B"></a>6.1) Using "2011 Impreza Diesel Responses.txt"

	ParsePID: Parse Subaru OBD-II mode 22 definitions and support responses.
	Usage:
	ParsePID.exe <ResponseFile> <DefinitionsFile>
	or: ParsePID.exe <ResponseFile>
	or for using predefined file paths: ParsePID.exe

	Parsing parameter definitions from file "data/Subaru_mode22_def.csv"
	Parsed 65 parameters.

	Parsing support responses from file "data/2011 Impreza Diesel Responses.txt"
	[SupportResponse: PID=0x0000 | SupportValue=0x183B8013]
	[SupportResponse: PID=0x0020 | SupportValue=0xA001A015]
	[SupportResponse: PID=0x0040 | SupportValue=0x44D00041]
	[SupportResponse: PID=0x0060 | SupportValue=0x00000001]
	[SupportResponse: PID=0x0080 | SupportValue=0x00000001]
	[SupportResponse: PID=0x00A0 | SupportValue=0x00000001]
	[SupportResponse: PID=0x00C0 | SupportValue=0x00000001]
	[SupportResponse: PID=0x00E0 | SupportValue=0x00000000]
	[SupportResponse: PID=0x1000 | SupportValue=0xFFC00003]
	[SupportResponse: PID=0x1020 | SupportValue=0x4079C001]
	[SupportResponse: PID=0x1040 | SupportValue=0x00000001]
	[SupportResponse: PID=0x1060 | SupportValue=0xA0000001]
	[SupportResponse: PID=0x1080 | SupportValue=0x01000001]
	[SupportResponse: PID=0x10A0 | SupportValue=0x86104001]
	[SupportResponse: PID=0x10C0 | SupportValue=0x00000001]
	[SupportResponse: PID=0x10E0 | SupportValue=0x20000001]
	[SupportResponse: PID=0x1100 | SupportValue=0x00000FFF]
	[SupportResponse: PID=0x1120 | SupportValue=0xF0FF0E01]
	[SupportResponse: PID=0x1140 | SupportValue=0x00FC3FE1]
	[SupportResponse: PID=0x1160 | SupportValue=0xFFFFFFFF]
	[SupportResponse: PID=0x1180 | SupportValue=0xFFFF0001]
	[SupportResponse: PID=0x11A0 | SupportValue=0x00000001]
	[SupportResponse: PID=0x11C0 | SupportValue=0x5D507ED9]
	[SupportResponse: PID=0x11E0 | SupportValue=0x00003001]
	[SupportResponse: PID=0x1200 | SupportValue=0x00000001]
	[SupportResponse: PID=0x1220 | SupportValue=0x0003F001]
	[SupportResponse: PID=0x1240 | SupportValue=0x184EB3FF]
	[SupportResponse: PID=0x1260 | SupportValue=0x40000000]
	Parsed 28 support responses.

	Results:
	PID 0x0004 : N/A
	PID 0x0005 : Coolant Temperature [°C]
	PID 0x000B : N/A
	PID 0x000C : N/A
	PID 0x000D : N/A
	PID 0x000F : N/A
	PID 0x0010 : N/A
	PID 0x0011 : N/A
	PID 0x001C : N/A
	PID 0x001F : N/A
	PID 0x0021 : N/A
	PID 0x0023 : Fuel Rail Pressure (diesel, or gasoline direct inject) [kPa]
	PID 0x0030 : N/A
	PID 0x0031 : N/A
	PID 0x0033 : N/A
	PID 0x003C : Exhaust Gas Temperature (EGT) at Catalyst Inlet [°C]
	PID 0x003E : Exhaust Gas Temperature (EGT) at DPF Inlet [°C]
	PID 0x0042 : N/A
	PID 0x0046 : N/A
	PID 0x0049 : N/A
	PID 0x004A : N/A
	PID 0x004C : N/A
	PID 0x005A : N/A
	PID 0x1001 : N/A
	PID 0x1002 : N/A
	PID 0x1003 : N/A
	PID 0x1004 : N/A
	PID 0x1005 : N/A
	PID 0x1006 : N/A
	PID 0x1007 : N/A
	PID 0x1008 : N/A
	PID 0x1009 : N/A
	PID 0x100A : N/A
	PID 0x101F : N/A
	PID 0x1022 : N/A
	PID 0x102A : Injector Code Cylinder #1 []
	PID 0x102B : Injector Code Cylinder #2 []
	PID 0x102C : Injector Code Cylinder #3 []
	PID 0x102D : Injector Code Cylinder #4 []
	PID 0x1030 : N/A
	PID 0x1031 : N/A
	PID 0x1032 : N/A
	PID 0x1061 : N/A
	PID 0x1063 : N/A
	PID 0x1088 : N/A
	PID 0x10A1 : Mass Airflow Sensor Voltage [V]
	PID 0x10A6 : Accelerator Pedal Angle [%]
	PID 0x10A7 : Fuel Temperature [°C]
	PID 0x10AC : Primary Boost Control [%]
	PID 0x10B2 : Alternator Duty [%]
	PID 0x10E3 : Memorised Cruise Speed [km/h]
	PID 0x1115 : N/A
	PID 0x1116 : Final Injection Amount [mm³/st]
	PID 0x1117 : N/A
	PID 0x1118 : N/A
	PID 0x1119 : N/A
	PID 0x111A : N/A
	PID 0x111B : Exhaust Gas Recirculation (EGR) Target Valve Opening Angle [deg]
	PID 0x111C : Exhaust Gas Recirculation (EGR) Valve Opening Angle [deg]
	PID 0x111D : N/A
	PID 0x111E : N/A
	PID 0x111F : Inlet Air Temperature (after air filter) [°C]
	PID 0x1121 : Target Engine Speed [rpm]
	PID 0x1122 : N/A
	PID 0x1123 : N/A
	PID 0x1124 : N/A
	PID 0x1129 : N/A
	PID 0x112A : Mileage after Injector Learning [km]
	PID 0x112B : Mileage after Injector Replacement [km]
	PID 0x112C : Interior Heater [steps]
	PID 0x112D : Quantity Correction Cylinder #1 [ms]
	PID 0x112E : Quantity Correction Cylinder #2 [ms]
	PID 0x112F : Quantity Correction Cylinder #3 [ms]
	PID 0x1130 : Quantity Correction Cylinder #4 [ms]
	PID 0x1135 : Battery Current [A]
	PID 0x1136 : Battery Temperature [°C]
	PID 0x1137 : Alternator Control Mode []
	PID 0x1149 : Cumulative Ash Ratio [%]
	PID 0x114A : Pressure Difference between DPF Inlet and Outlet [kPa]
	PID 0x114B : Estimated Catalyst Temperature [°C]
	PID 0x114C : Estimated DPF Temperature [°C]
	PID 0x114D : Soot Accumulation Ratio [%]
	PID 0x114E : Oil Dilution Ratio [%]
	PID 0x1153 : N/A
	PID 0x1154 : N/A
	PID 0x1155 : Estimated Distance to Oil Change [km]
	PID 0x1156 : Running Distance since last DPF Regeneration [km]
	PID 0x1157 : DPF Regeneration Count [Times]
	PID 0x1158 : Micro-Quantity-Injection Final Learning Values Cylinder #1 [ms]
	PID 0x1159 : Micro-Quantity-Injection Final Learning Values Cylinder #2 [ms]
	PID 0x115A : Micro-Quantity-Injection Final Learning Values Cylinder #3 [ms]
	PID 0x115B : Micro-Quantity-Injection Final Learning Values Cylinder #4 [ms]
	PID 0x1161 : Individual Pump Difference Learning Value [mA]
	PID 0x1162 : Final Main Injection Period [ms]
	PID 0x1163 : N/A
	PID 0x1164 : N/A
	PID 0x1165 : N/A
	PID 0x1166 : N/A
	PID 0x1167 : N/A
	PID 0x1168 : N/A
	PID 0x1169 : N/A
	PID 0x116A : N/A
	PID 0x116B : N/A
	PID 0x116C : N/A
	PID 0x116D : N/A
	PID 0x116E : N/A
	PID 0x116F : N/A
	PID 0x1170 : N/A
	PID 0x1171 : N/A
	PID 0x1172 : N/A
	PID 0x1173 : N/A
	PID 0x1174 : N/A
	PID 0x1175 : N/A
	PID 0x1176 : N/A
	PID 0x1177 : N/A
	PID 0x1178 : N/A
	PID 0x1179 : N/A
	PID 0x117A : N/A
	PID 0x117B : N/A
	PID 0x117C : N/A
	PID 0x117D : N/A
	PID 0x117E : N/A
	PID 0x117F : N/A
	PID 0x1181 : N/A
	PID 0x1182 : N/A
	PID 0x1183 : N/A
	PID 0x1184 : N/A
	PID 0x1185 : N/A
	PID 0x1186 : N/A
	PID 0x1187 : N/A
	PID 0x1188 : N/A
	PID 0x1189 : Oil Dilution Amount [kg]
	PID 0x118A : N/A
	PID 0x118B : N/A
	PID 0x118C : N/A
	PID 0x118D : N/A
	PID 0x118E : N/A
	PID 0x118F : N/A
	PID 0x1190 : N/A
	PID 0x11C2 : N/A
	PID 0x11C4 : N/A
	PID 0x11C5 : N/A
	PID 0x11C6 : N/A
	PID 0x11C8 : N/A
	PID 0x11CA : N/A
	PID 0x11CC : N/A
	PID 0x11D2 : N/A
	PID 0x11D3 : N/A
	PID 0x11D4 : N/A
	PID 0x11D5 : N/A
	PID 0x11D6 : N/A
	PID 0x11D7 : N/A
	PID 0x11D9 : N/A
	PID 0x11DA : N/A
	PID 0x11DC : N/A
	PID 0x11DD : N/A
	PID 0x11F3 : N/A
	PID 0x11F4 : N/A
	PID 0x122F : Clutch Switch []
	PID 0x1230 : Stop Light Switch []
	PID 0x1231 : Cruise Control Set/Coast Switch []
	PID 0x1232 : Cruise Control Resume/Accelerate Switch []
	PID 0x1233 : Brake Switch []
	PID 0x1234 : Cruise Control Main Toggle Switch []
	PID 0x1244 : N/A
	PID 0x1245 : N/A
	PID 0x124A : Cruise Control Cancel Switch []
	PID 0x124D : N/A
	PID 0x124E : N/A
	PID 0x124F : Glow Relay Switch []
	PID 0x1251 : N/A
	PID 0x1253 : N/A
	PID 0x1254 : Injector Learning []
	PID 0x1257 : N/A
	PID 0x1258 : N/A
	PID 0x1259 : N/A
	PID 0x125A : N/A
	PID 0x125B : DPF Active Regeneration Switch []
	PID 0x125C : N/A
	PID 0x125D : N/A
	PID 0x125E : N/A
	PID 0x125F : N/A
	PID 0x1262 : N/A
	Supported PIDs total: 183 | known: 55 | unknown: 128

### <a name="EA1M220F"></a> 6.2) Using "2014 Forester FB25 non-Turbo Responses.txt"

	ParsePID: Parse Subaru OBD-II mode 22 definitions and support responses.
	Usage:
	ParsePID.exe <ResponseFile> <DefinitionsFile>
	or: ParsePID.exe <ResponseFile>
	or for using predefined file paths: ParsePID.exe

	Parsing parameter definitions from file "data/Subaru_mode22_def.csv"
	Parsed 65 parameters.

	Parsing support responses from file "data/2014 Forester FB25 non-Turbo Responses.txt"
	[SupportResponse: PID=0x1000 | SupportValue=0xFFC0000D]
	[SupportResponse: PID=0x1020 | SupportValue=0x50000019]
	[SupportResponse: PID=0x1040 | SupportValue=0x00000001]
	[SupportResponse: PID=0x1060 | SupportValue=0xA0000001]
	[SupportResponse: PID=0x1080 | SupportValue=0x01800001]
	[SupportResponse: PID=0x10A0 | SupportValue=0xAC04DFD5]
	[SupportResponse: PID=0x10C0 | SupportValue=0x80000007]
	[SupportResponse: PID=0x10E0 | SupportValue=0x2A000001]
	[SupportResponse: PID=0x1100 | SupportValue=0x003C1001]
	[SupportResponse: PID=0x1120 | SupportValue=0x80001E01]
	[SupportResponse: PID=0x1140 | SupportValue=0x00000001]
	[SupportResponse: PID=0x1160 | SupportValue=0x0C001801]
	[SupportResponse: PID=0x1180 | SupportValue=0x00000001]
	[SupportResponse: PID=0x11A0 | SupportValue=0x00000001]
	[SupportResponse: PID=0x11C0 | SupportValue=0x5D557EDD]
	[SupportResponse: PID=0x11E0 | SupportValue=0x3000F801]
	[SupportResponse: PID=0x1200 | SupportValue=0x00000001]
	[SupportResponse: PID=0x1220 | SupportValue=0x0007F001]
	[SupportResponse: PID=0x1240 | SupportValue=0x00500001]
	[SupportResponse: PID=0x1260 | SupportValue=0x0C001FF7]
	[SupportResponse: PID=0x1280 | SupportValue=0x00000001]
	[SupportResponse: PID=0x12A0 | SupportValue=0xC0000000]
	Parsed 22 support responses.

	Results:
	PID 0x1001 : N/A
	PID 0x1002 : N/A
	PID 0x1003 : N/A
	PID 0x1004 : N/A
	PID 0x1005 : N/A
	PID 0x1006 : N/A
	PID 0x1007 : N/A
	PID 0x1008 : N/A
	PID 0x1009 : N/A
	PID 0x100A : N/A
	PID 0x101D : N/A
	PID 0x101E : N/A
	PID 0x1022 : N/A
	PID 0x1024 : N/A
	PID 0x103C : N/A
	PID 0x103D : N/A
	PID 0x1061 : N/A
	PID 0x1063 : N/A
	PID 0x1088 : N/A
	PID 0x1089 : N/A
	PID 0x10A1 : Mass Airflow Sensor Voltage [V]
	PID 0x10A3 : Fuel Injector #1 Pulse Width [ms]
	PID 0x10A5 : Learned Ignition Timing [deg]
	PID 0x10A6 : Accelerator Pedal Angle [%]
	PID 0x10AE : N/A
	PID 0x10B1 : N/A
	PID 0x10B2 : Alternator Duty [%]
	PID 0x10B4 : Intake VVT Advance Angle Right [deg]
	PID 0x10B5 : Intake VVT Advance Angle Left [deg]
	PID 0x10B6 : N/A
	PID 0x10B7 : N/A
	PID 0x10B8 : N/A
	PID 0x10B9 : N/A
	PID 0x10BA : N/A
	PID 0x10BC : N/A
	PID 0x10BE : N/A
	PID 0x10C1 : N/A
	PID 0x10DE : N/A
	PID 0x10DF : N/A
	PID 0x10E3 : Memorised Cruise Speed [km/h]
	PID 0x10E5 : N/A
	PID 0x10E7 : N/A
	PID 0x110B : N/A
	PID 0x110C : N/A
	PID 0x110D : N/A
	PID 0x110E : N/A
	PID 0x1114 : N/A
	PID 0x1121 : Target Engine Speed [rpm]
	PID 0x1134 : N/A
	PID 0x1135 : Battery Current [A]
	PID 0x1136 : Battery Temperature [°C]
	PID 0x1137 : Alternator Control Mode []
	PID 0x1165 : N/A
	PID 0x1166 : N/A
	PID 0x1174 : N/A
	PID 0x1175 : N/A
	PID 0x11C2 : N/A
	PID 0x11C4 : N/A
	PID 0x11C5 : N/A
	PID 0x11C6 : N/A
	PID 0x11C8 : N/A
	PID 0x11CA : N/A
	PID 0x11CC : N/A
	PID 0x11CE : N/A
	PID 0x11D0 : N/A
	PID 0x11D2 : N/A
	PID 0x11D3 : N/A
	PID 0x11D4 : N/A
	PID 0x11D5 : N/A
	PID 0x11D6 : N/A
	PID 0x11D7 : N/A
	PID 0x11D9 : N/A
	PID 0x11DA : N/A
	PID 0x11DC : N/A
	PID 0x11DD : N/A
	PID 0x11DE : N/A
	PID 0x11E3 : N/A
	PID 0x11E4 : N/A
	PID 0x11F1 : N/A
	PID 0x11F2 : N/A
	PID 0x11F3 : N/A
	PID 0x11F4 : N/A
	PID 0x11F5 : N/A
	PID 0x122E : N/A
	PID 0x122F : Clutch Switch []
	PID 0x1230 : Stop Light Switch []
	PID 0x1231 : Cruise Control Set/Coast Switch []
	PID 0x1232 : Cruise Control Resume/Accelerate Switch []
	PID 0x1233 : Brake Switch []
	PID 0x1234 : Cruise Control Main Toggle Switch []
	PID 0x124A : Cruise Control Cancel Switch []
	PID 0x124C : Oil Level Switch []
	PID 0x1265 : N/A
	PID 0x1266 : N/A
	PID 0x1274 : N/A
	PID 0x1275 : N/A
	PID 0x1276 : N/A
	PID 0x1277 : N/A
	PID 0x1278 : N/A
	PID 0x1279 : N/A
	PID 0x127A : N/A
	PID 0x127B : N/A
	PID 0x127C : N/A
	PID 0x127E : N/A
	PID 0x127F : N/A
	PID 0x12A1 : N/A
	PID 0x12A2 : N/A
	Supported PIDs total: 107 | known: 20 | unknown: 87

### <a name="JF7C100D"></a> 6.3) Using "2015 Forester Diesel CVT Responses.txt"

	ParsePID: Parse Subaru OBD-II mode 22 definitions and support responses.
	Usage:
	ParsePID.exe <ResponseFile> <DefinitionsFile>
	or: ParsePID.exe <ResponseFile>
	or for using predefined file paths: ParsePID.exe

	Parsing parameter definitions from file "data/Subaru_mode22_def.csv"
	Parsed 65 parameters.

	Parsing support responses from file "data/2015 Forester Diesel CVT Responses.txt"
	[SupportResponse: PID=0x1000 | SupportValue=0xFFC00007]
	[SupportResponse: PID=0x1020 | SupportValue=0x4079C01F]
	[SupportResponse: PID=0x1040 | SupportValue=0x00000001]
	[SupportResponse: PID=0x1060 | SupportValue=0xA0000001]
	[SupportResponse: PID=0x1080 | SupportValue=0x01000001]
	[SupportResponse: PID=0x10A0 | SupportValue=0x86104051]
	[SupportResponse: PID=0x10C0 | SupportValue=0x00400003]
	[SupportResponse: PID=0x10E0 | SupportValue=0x20000001]
	[SupportResponse: PID=0x1100 | SupportValue=0x00000FFD]
	[SupportResponse: PID=0x1120 | SupportValue=0xF0FF1203]
	[SupportResponse: PID=0x1140 | SupportValue=0x00BC3FE9]
	[SupportResponse: PID=0x1160 | SupportValue=0xFFFFFBFF]
	[SupportResponse: PID=0x1180 | SupportValue=0xFFFF0001]
	[SupportResponse: PID=0x11A0 | SupportValue=0xFE01FFE1]
	[SupportResponse: PID=0x11C0 | SupportValue=0x1D507ED9]
	[SupportResponse: PID=0x11E0 | SupportValue=0x00003001]
	[SupportResponse: PID=0x1200 | SupportValue=0x00000001]
	[SupportResponse: PID=0x1220 | SupportValue=0x0001F001]
	[SupportResponse: PID=0x1240 | SupportValue=0x185CB1BF]
	[SupportResponse: PID=0x1260 | SupportValue=0x41000015]
	[SupportResponse: PID=0x1280 | SupportValue=0x030021C1]
	[SupportResponse: PID=0x12A0 | SupportValue=0x00000001]
	[SupportResponse: PID=0x12C0 | SupportValue=0x00001861]
	[SupportResponse: PID=0x12E0 | SupportValue=0x00C00001]
	Parsed 24 support responses.

	Results:
	PID 0x1001 : N/A
	PID 0x1002 : N/A
	PID 0x1003 : N/A
	PID 0x1004 : N/A
	PID 0x1005 : N/A
	PID 0x1006 : N/A
	PID 0x1007 : N/A
	PID 0x1008 : N/A
	PID 0x1009 : N/A
	PID 0x100A : N/A
	PID 0x101E : N/A
	PID 0x101F : N/A
	PID 0x1022 : N/A
	PID 0x102A : Injector Code Cylinder #1 []
	PID 0x102B : Injector Code Cylinder #2 []
	PID 0x102C : Injector Code Cylinder #3 []
	PID 0x102D : Injector Code Cylinder #4 []
	PID 0x1030 : N/A
	PID 0x1031 : N/A
	PID 0x1032 : N/A
	PID 0x103C : N/A
	PID 0x103D : N/A
	PID 0x103E : N/A
	PID 0x103F : N/A
	PID 0x1061 : N/A
	PID 0x1063 : N/A
	PID 0x1088 : N/A
	PID 0x10A1 : Mass Airflow Sensor Voltage [V]
	PID 0x10A6 : Accelerator Pedal Angle [%]
	PID 0x10A7 : Fuel Temperature [°C]
	PID 0x10AC : Primary Boost Control [%]
	PID 0x10B2 : Alternator Duty [%]
	PID 0x10BA : N/A
	PID 0x10BC : N/A
	PID 0x10CA : N/A
	PID 0x10DF : N/A
	PID 0x10E3 : Memorised Cruise Speed [km/h]
	PID 0x1115 : N/A
	PID 0x1116 : Final Injection Amount [mm³/st]
	PID 0x1117 : N/A
	PID 0x1118 : N/A
	PID 0x1119 : N/A
	PID 0x111A : N/A
	PID 0x111B : Exhaust Gas Recirculation (EGR) Target Valve Opening Angle [deg]
	PID 0x111C : Exhaust Gas Recirculation (EGR) Valve Opening Angle [deg]
	PID 0x111D : N/A
	PID 0x111E : N/A
	PID 0x1121 : Target Engine Speed [rpm]
	PID 0x1122 : N/A
	PID 0x1123 : N/A
	PID 0x1124 : N/A
	PID 0x1129 : N/A
	PID 0x112A : Mileage after Injector Learning [km]
	PID 0x112B : Mileage after Injector Replacement [km]
	PID 0x112C : Interior Heater [steps]
	PID 0x112D : Quantity Correction Cylinder #1 [ms]
	PID 0x112E : Quantity Correction Cylinder #2 [ms]
	PID 0x112F : Quantity Correction Cylinder #3 [ms]
	PID 0x1130 : Quantity Correction Cylinder #4 [ms]
	PID 0x1134 : N/A
	PID 0x1137 : Alternator Control Mode []
	PID 0x113F : N/A
	PID 0x1149 : Cumulative Ash Ratio [%]
	PID 0x114B : Estimated Catalyst Temperature [°C]
	PID 0x114C : Estimated DPF Temperature [°C]
	PID 0x114D : Soot Accumulation Ratio [%]
	PID 0x114E : Oil Dilution Ratio [%]
	PID 0x1153 : N/A
	PID 0x1154 : N/A
	PID 0x1155 : Estimated Distance to Oil Change [km]
	PID 0x1156 : Running Distance since last DPF Regeneration [km]
	PID 0x1157 : DPF Regeneration Count [Times]
	PID 0x1158 : Micro-Quantity-Injection Final Learning Values Cylinder #1 [ms]
	PID 0x1159 : Micro-Quantity-Injection Final Learning Values Cylinder #2 [ms]
	PID 0x115A : Micro-Quantity-Injection Final Learning Values Cylinder #3 [ms]
	PID 0x115B : Micro-Quantity-Injection Final Learning Values Cylinder #4 [ms]
	PID 0x115D : N/A
	PID 0x1161 : Individual Pump Difference Learning Value [mA]
	PID 0x1162 : Final Main Injection Period [ms]
	PID 0x1163 : N/A
	PID 0x1164 : N/A
	PID 0x1165 : N/A
	PID 0x1166 : N/A
	PID 0x1167 : N/A
	PID 0x1168 : N/A
	PID 0x1169 : N/A
	PID 0x116A : N/A
	PID 0x116B : N/A
	PID 0x116C : N/A
	PID 0x116D : N/A
	PID 0x116E : N/A
	PID 0x116F : N/A
	PID 0x1170 : N/A
	PID 0x1171 : N/A
	PID 0x1172 : N/A
	PID 0x1173 : N/A
	PID 0x1174 : N/A
	PID 0x1175 : N/A
	PID 0x1177 : N/A
	PID 0x1178 : N/A
	PID 0x1179 : N/A
	PID 0x117A : N/A
	PID 0x117B : N/A
	PID 0x117C : N/A
	PID 0x117D : N/A
	PID 0x117E : N/A
	PID 0x117F : N/A
	PID 0x1181 : N/A
	PID 0x1182 : N/A
	PID 0x1183 : N/A
	PID 0x1184 : N/A
	PID 0x1185 : N/A
	PID 0x1186 : N/A
	PID 0x1187 : N/A
	PID 0x1188 : N/A
	PID 0x1189 : Oil Dilution Amount [kg]
	PID 0x118A : N/A
	PID 0x118B : N/A
	PID 0x118C : N/A
	PID 0x118D : N/A
	PID 0x118E : N/A
	PID 0x118F : N/A
	PID 0x1190 : N/A
	PID 0x11A1 : N/A
	PID 0x11A2 : N/A
	PID 0x11A3 : N/A
	PID 0x11A4 : N/A
	PID 0x11A5 : N/A
	PID 0x11A6 : N/A
	PID 0x11A7 : N/A
	PID 0x11B0 : N/A
	PID 0x11B1 : N/A
	PID 0x11B2 : N/A
	PID 0x11B3 : N/A
	PID 0x11B4 : N/A
	PID 0x11B5 : N/A
	PID 0x11B6 : N/A
	PID 0x11B7 : N/A
	PID 0x11B8 : N/A
	PID 0x11B9 : N/A
	PID 0x11BA : N/A
	PID 0x11BB : N/A
	PID 0x11C4 : N/A
	PID 0x11C5 : N/A
	PID 0x11C6 : N/A
	PID 0x11C8 : N/A
	PID 0x11CA : N/A
	PID 0x11CC : N/A
	PID 0x11D2 : N/A
	PID 0x11D3 : N/A
	PID 0x11D4 : N/A
	PID 0x11D5 : N/A
	PID 0x11D6 : N/A
	PID 0x11D7 : N/A
	PID 0x11D9 : N/A
	PID 0x11DA : N/A
	PID 0x11DC : N/A
	PID 0x11DD : N/A
	PID 0x11F3 : N/A
	PID 0x11F4 : N/A
	PID 0x1230 : Stop Light Switch []
	PID 0x1231 : Cruise Control Set/Coast Switch []
	PID 0x1232 : Cruise Control Resume/Accelerate Switch []
	PID 0x1233 : Brake Switch []
	PID 0x1234 : Cruise Control Main Toggle Switch []
	PID 0x1244 : N/A
	PID 0x1245 : N/A
	PID 0x124A : Cruise Control Cancel Switch []
	PID 0x124C : Oil Level Switch []
	PID 0x124D : N/A
	PID 0x124E : N/A
	PID 0x1251 : N/A
	PID 0x1253 : N/A
	PID 0x1254 : Injector Learning []
	PID 0x1258 : N/A
	PID 0x1259 : N/A
	PID 0x125B : DPF Active Regeneration Switch []
	PID 0x125C : N/A
	PID 0x125D : N/A
	PID 0x125E : N/A
	PID 0x125F : N/A
	PID 0x1262 : N/A
	PID 0x1268 : N/A
	PID 0x127C : N/A
	PID 0x127E : N/A
	PID 0x1287 : N/A
	PID 0x1288 : N/A
	PID 0x1293 : N/A
	PID 0x1298 : N/A
	PID 0x1299 : N/A
	PID 0x129A : N/A
	PID 0x12D4 : N/A
	PID 0x12D5 : N/A
	PID 0x12DA : N/A
	PID 0x12DB : N/A
	PID 0x12E9 : N/A
	PID 0x12EA : N/A
	Supported PIDs total: 197 | known: 46 | unknown: 151

---
