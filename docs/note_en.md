# VMT - VirtualMotionTracker Manual
## Caution
Please remove/uninstall old driver before new driver install.  

## How it works
**VMT**  
C++ OpenVR Driver. it receives OSC Protocol.  
  
**VMT Manager**  
C# Management tool.  
Installation, Uninstallation, Room setup.  
  
## Installation
**1. Download and extract VMT**  
[Download](https://github.com/gpsnmeajp/VirtualMotionTracker/releases)  

**2. Launch vmt_manager.exe**  

**3. Allow vmt_manager.exe in firewall**  
<img src="/VirtualMotionTrackerDocument/img/screen1A.png" height="300px"></img>

**4. Click "Install" button**  
Driver path registration for VR System.  
<img src="/VirtualMotionTrackerDocument/img/screen0.png"></img>
<img src="/VirtualMotionTrackerDocument/img/screen1B.png"></img>

**5. Restart SteamVR**  
vmt manager will close automatically.  
  
**6. Allow SteamVR(vrserver.exe) in firewall**  
  
## Room Matrix setup
**1. Launch vmt_manager.exe**  

**2. Start VR HMD and Controller**  
vmt_manager will get room info.  
Please wait for Room Matrix turns green.   
<img src="/VirtualMotionTrackerDocument/img/screen1.png"></img>
<img src="/VirtualMotionTrackerDocument/img/screen2.png"></img>  

**3. Click "Set Room Matrix" button.**  
Room Matrix will save in setting.json.  

## Check
**1. Click "Check VMT_0 Position" Button**  
**2. if SteamVR shows tracker, and "VMT_0 Room Position" green, it's ok.**  
if "VMT_0 Room Position" is red, please retry Room Matrix setup.  
<img src="/VirtualMotionTrackerDocument/img/screen2A.png"></img>
<img src="/VirtualMotionTrackerDocument/img/screen3.png"></img>  

## Test controller input
Please set tracker role before you test controller input.  
<img src="/VirtualMotionTrackerDocument/img/screen2C.png"></img>  

## Configure handheld mode.
If you want to tracker works like Controller or not, please below setting.  
**1. Click "Show all" in Manager**  
<img src="/VirtualMotionTrackerDocument/img/screen2B.png"></img>  
  
**2. SteamVRの設定→デバイス→Viveトラッカーを管理**  
<img src="/VirtualMotionTrackerDocument/img/screen4.png" height="300px"></img>  
  
**3. Viveトラッカーの管理**  
<img src="/VirtualMotionTrackerDocument/img/screen5.png" height="300px"></img>  
  
**4. Set Tracker roles**  
<img src="/VirtualMotionTrackerDocument/img/screen6.png" height="300px"></img>
<img src="/VirtualMotionTrackerDocument/img/screen7.png" height="300px"></img>  

## OSC Protocol

|Direction|Port number|
|---|---|
|App → Driver| 39570|
|Manager → Driver| 39570|
|Manager ← Driver| 39571|

Caution: If Port 39571 used be another application, Manager won't works.  
  
### Virtual tracker control
**Argument**  

|Args|type|detail|
|---|---|---|
|index|int| ID number。0-57|
|enable|int| 0=Disable, 1=Enable(Tracker), 2=Enable(Left Hand Controller), 3=Enable(Right Hand Controller), 4=Enable(TrackingReference) |
|timeoffset|float| TimeOffset, normaly 0|
|x,y,z|float| Position|
|qx,qy,qz,qw|float| Rotaion(Quaternion)|
|serial|string| Target device serial(LHR-xxxxxxx) or HMD(HMD)|

***Type(Tracker or Controller) only works in first registration time.***  

**/VMT/Room/Unity index, enable, timeoffset, x, y, z, qx, qy, qz, qw**  
Unity lik Left-handed space, and Room space. (Recommended)  
  
**/VMT/Room/Driver index, enable, timeoffset, x, y, z, qx, qy, qz, qw**  
Driver Right-handed space, and Room space.  
  
**/VMT/Raw/Unity index, enable, timeoffset, x, y, z, qx, qy, qz, qw**  
Unity lik Left-handed space, and Driver space.  
  
**/VMT/Raw/Driver index, enable, timeoffset, x, y, z, qx, qy, qz, qw**  
Driver Right-handed space, and Driver space.  
  
**/VMT/Joint/Unity index, enable, timeoffset, x, y, z, qx, qy, qz, qw, serial**  
Unity lik Left-handed space, and Traget device space.  
  
**/VMT/Joint/Driver index, enable, timeoffset, x, y, z, qx, qy, qz, qw, serial**  
Driver Right-handed space, and Traget device space.  
  
**/VMT/Follow/Unity index, enable, timeoffset, x, y, z, qx, qy, qz, qw, serial**  
Unity lik Left-handed space, and Traget device position(Room Rotation).  
  
**/VMT/Follow/Driver index, enable, timeoffset, x, y, z, qx, qy, qz, qw, serial**  
Driver Right-handed space, and Traget device position(Room Rotation).  
  
### Input
|Method|Range|
|---|---|
|ButtonIndex(int)| 0～7|
|TriggerIndex(int)| 0, 1|
|JoyStickIndex(int)| 0|


**/VMT/Input/Button index, buttonindex, timeoffset, value**  
Button input.  
value(int):1=press, 0=Release  
  
**/VMT/Input/Trigger index, triggerindex, timeoffset, value**  
Trigger input.  
value(float):0.0 ～ 1.0  

**/VMT/Input/Joystick index, joystickindex, timeoffset, x, y**  
Joystick input.  
x,y(float):-1.0 ～ 1.0  
  
### Driver Management
**/VMT/Reset**  
All tracker will not-tracking state.  
  
**/VMT/LoadSetting**  
Reload json.  
  
**/VMT/SetRoomMatrix m1,m2,m3,m4,m5,m6,m7,m8,m9,m10,m11,m12**  
Set and Save Room Matrix.  
Please do not send periodic. it writes setting on drive.    

**/VMT/SetRoomMatrix/Temporary m1,m2,m3,m4,m5,m6,m7,m8,m9,m10,m11,m12**  
Set Room Matrix temporary.  
It is volatile.    

**/VMT/SetAutoPoseUpdate enable**  
Set Pose auto update. (for joint)  
enable 1=on, 0=off  

### Drivers response  
**/VMT/Out/Log stat,msg**  
stat(int): Status(0=info,1=warn,2=err)  
msg(string): Message  
  
**/VMT/Out/Alive version, installpath**  
version(string): Version  
installpath(string): Driver installed path
  
**/VMT/Out/Haptic index, frequency, amplitude, duration**  
frequency(float): frequency  
amplitude(float): amplitude  
duration(float): duration  

**/VMT/Out/Unavailable code, reason**  
code(int): Unavailable code(0=Available, 1=Room Matrix has not been set.)  
reason(string): Reason(Human readable)  

### Unity sample
Plese use [hecomi/uOSC](https://github.com/hecomi/uOSC)  
Send gameobject transform to virtual tracker.  

<img src="/VirtualMotionTrackerDocument/img/unity.png"></img>
  
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class sendme : MonoBehaviour
{
    const int DISABLE = 0;
    const int ENABLE_TRACKER = 1;
    const int ENABLE_CONTROLLER_L = 2;
    const int ENABLE_CONTROLLER_R = 3;
    const int ENABLE_TRACKING_REFERENCE = 4;

    uOSC.uOscClient client;
    void Start()
    {
        client = GetComponent<uOSC.uOscClient>();
    }

    void Update()
    {
        const int index = 0;
        const int enable = ENABLE_TRACKER;
        const float timeoffset = 0f;

        client.Send("/VMT/Room/Unity", (int)index, (int)enable, (float)timeoffset,
            (float)transform.position.x,
            (float)transform.position.y,
            (float)transform.position.z,
            (float)transform.rotation.x,
            (float)transform.rotation.y,
            (float)transform.rotation.z,
            (float)transform.rotation.w
        );
    }
}
```
## Commandline
|Example|function|
|---|---|
|vmt_manager.exe install|Install driver|
|vmt_manager.exe uninstall|Uninstall driver|

## Tracking Override
https://github.com/ValveSoftware/openvr/wiki/TrackingOverrides

steamvr.vrsettings

```
   "TrackingOverrides" : {
      "/devices/vmt/VMT_0" : "/user/head",
      "/devices/vmt/VMT_1" : "/user/hand/left",
      "/devices/vmt/VMT_2" : "/user/hand/right"
   },
```

## setting.json
Basicaly, set false to old version compatible.

```
{
	"HMDisIndex0": Serial number "HMD" as HMD(Index 0),
	"OptoutTrackingRole": Optout Tracking Role when tracker/tracking reference,
	"ReceivePort": OSC Receive port,
	"RejectWhenCannotTracking": Stop when tracking lost,
	"RoomMatrix": Room Matrix,
	"SendPort": OSC Send port,
	"VelocityEnable": Velocity, angular velocity emuration enable
}
```
