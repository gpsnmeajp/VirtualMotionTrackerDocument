---
title: API
description: 技術的な使い方・プロトコル
---

# API

## Unity sample / Unity sample
Please install asset [hecomi/uOSC](https://github.com/hecomi/uOSC).  
Sends the coordinates of the attached GameObject as a tracker. 

[hecomi/uOSC](https://github.com/hecomi/uOSC)を導入してください。  
アタッチされたGameObjectの座標をトラッカーとして送信します。  
  
![](/VirtualMotionTrackerDocument/image/unity.png)
  
```c#
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

## OSC Protocol / OSCプロトコル

|Direction / 方向| Port / ポート番号|
|---|---|
|App → Driver| 39570|
|Manager → Driver| 39570|
|Manager ← Driver| 39571|

!!! Caution
    Note: Manager will not work if port 39571 is used. 
    注意: 39571が使用されているとManagerは動作しません。  
  
### Controle virtual tracker / 仮想トラッカー制御

|Identifier / 識別子|Type / 型|Detail / 内容|
|---|---|---|
|index|int| Index(0～57). インデックス(0～57)|
|enable|int| Enable / 有効可否。0=Disable/無効, 1=Tracker/トラッカー, 2=Left Controller/左コントローラ, 3=Right Controller/右コントローラ, 4=TrackingReference|
|timeoffset|float| Timeoffset/補正時間。Always 0/基本的に0です|
|x,y,z|float| Position/位置座標|
|qx,qy,qz,qw|float| Rotation(Quaternion)/回転(クォータニオン)|
|serial|string| Joint, Follow target device serial / 追従対象のデバイスシリアル(LHR-xxxxxxx) or HMD(HMD)|

!!! Note
    TType(Tracker or Controller) only works in first registration time. (from boot up of SteamVR).
    種別(トラッカー or コントローラ)はデバイス登録時(SteamVR起動時からの初回のみ)反映されます。  

**/VMT/Room/Unity index, enable, timeoffset, x, y, z, qx, qy, qz, qw**  
Unity lik Left-handed space, and Room space. (Recommended)  
Unityと同じ左手系、かつ、ルーム空間(推奨)  
  
**/VMT/Room/Driver index, enable, timeoffset, x, y, z, qx, qy, qz, qw**   
OpenVR Driver Right-handed space, and Room space.  
OpenVR Driverの右手系、かつ、ルーム空間  
  
**/VMT/Raw/Unity index, enable, timeoffset, x, y, z, qx, qy, qz, qw**  
Unity lik Left-handed space, and Driver space.  
Unityと同じ左手系、かつ、ドライバー空間  
  
**/VMT/Raw/Driver index, enable, timeoffset, x, y, z, qx, qy, qz, qw**  
OpenVR Driver Right-handed space, and Driver space.  
OpenVRの右手系、かつ、ドライバー空間  
  
**/VMT/Joint/Unity index, enable, timeoffset, x, y, z, qx, qy, qz, qw, serial**  
Unity lik Left-handed space, and Traget device space(Traget device rotation).  
Unityと同じ左手系、かつ、指定デバイス空間(回転はデバイス基準)  
  
**/VMT/Joint/Driver index, enable, timeoffset, x, y, z, qx, qy, qz, qw, serial**  
OpenVR Driver Right-handed space, and Traget device space(Traget device rotation).  
OpenVRの右手系、かつ、指定デバイス空間(回転はデバイス基準)  
  
**/VMT/Follow/Unity index, enable, timeoffset, x, y, z, qx, qy, qz, qw, serial**  
Unity lik Left-handed space, and Traget device position(Room Rotation).  
Unityと同じ左手系、かつ、指定デバイス位置(回転はルーム空間)  
  
**/VMT/Follow/Driver index, enable, timeoffset, x, y, z, qx, qy, qz, qw, serial**  
OpenVR Driver Right-handed space, and Traget device position(Room Rotation).  
OpenVRの右手系、かつ、指定デバイス空間(回転はルーム空間)  
  
### 入力操作
|種類|範囲|
|---|---|
|ButtonIndex(int)| 0～7|
|TriggerIndex(int)| 0, 1|
|JoyStickIndex(int)| 0|

**/VMT/Input/Button index, buttonindex, timeoffset, value**  
Button input.
ボタン入力  
value(int):1=press, 0=Release  
  
**/VMT/Input/Trigger index, triggerindex, timeoffset, value**  
Trigger input.
トリガー入力  
value(float):0.0 ～ 1.0  

**/VMT/Input/Joystick index, joystickindex, timeoffset, x, y**  
Joystick input.
ジョイスティック入力  
x,y(float):-1.0 ～ 1.0  
  
### ドライバ操作
**/VMT/Reset**  
Turn off all tracker.
すべてのトラッカーを電源オフにする  
  
**/VMT/LoadSetting**  
Reload driver setting json.
ドライバーのjson設定を再読込します。  
  
**/VMT/SetRoomMatrix m1,m2,m3,m4,m5,m6,m7,m8,m9,m10,m11,m12**  
Set and Save Room Matrix. Please do not send periodic. it writes setting on drive.    
RoomToDriver空間変換行列を設定し保存します。  
定期的に送信しないでください。これはディスクへの書き込みを行います。

**/VMT/SetRoomMatrix/Temporary m1,m2,m3,m4,m5,m6,m7,m8,m9,m10,m11,m12**  
Set Room Matrix temporary. It is volatile on restart.    
RoomToDriver空間変換行列を一時的に設定します。  
こちらは一時的に適用され、再起動すると揮発します。  

**/VMT/SetAutoPoseUpdate enable**  
Set Pose auto update. 姿勢の自動更新をオンにします。
enable 1=on, 0=off  

### ドライバ側応答
**/VMT/Out/Log stat,msg**  
stat(int): Dialog message type / ダイアログメッセージ種別 (0=info,1=warn,2=err)  
msg(string): Message メッセージ  
  
**/VMT/Out/Alive version, installpath**  
version(string): Driver version / ドライババージョン  
installpath(string): Driver install path / ドライバのインストールパス  

**/VMT/Out/Haptic index, frequency, amplitude, duration**  
frequency(float): frequency / 周波数  
amplitude(float): amplitude / 振幅  
duration(float): duration / 長さ  

**/VMT/Out/Unavailable code, reason**  
code(int): Unavailable code / 利用不可コード(0=Available/利用可能, 1=Room Matrix has not been set./ルーム行列が設定されていない)  
reason(string): Reason(Human readable) / 詳細(人間が読む用)  
  
## コマンドライン引数
|例|機能|
|---|---|
|vmt_manager.exe install| Install driver / ドライバをインストールします|
|vmt_manager.exe uninstall| Uninstall driver / ドライバをアンインストールします|

## Tracking Override
SteamVR has the ability to overwrite the orientation of an existing device with the specified device orientation for debugging the device under development.   
SteamVRには、開発中のデバイスのデバッグのため、既存のデバイスの姿勢を指定したデバイスの姿勢で上書きする機能があります。  

[https://github.com/ValveSoftware/openvr/wiki/TrackingOverrides](https://github.com/ValveSoftware/openvr/wiki/TrackingOverrides)

As an example, if you add the following description to steamvr.vrsettings, you can control tracker 0 = HMD, 1 = left hand, 2 = right hand.   
例として、steamvr.vrsettingsに以下の記述を追加すると、トラッカー0=HMD, 1=左手, 2=右手の制御ができます。  

```json
   "TrackingOverrides" : {
      "/devices/vmt/VMT_0" : "/user/head",
      "/devices/vmt/VMT_1" : "/user/hand/left",
      "/devices/vmt/VMT_2" : "/user/hand/right"
   },
```

Buttons and sticks cannot be operated from the virtual tracker.
The operation from controller of original is accepted.
ボタンやスティックの操作は仮想トラッカーからはできません。  
コントローラ本体の操作が受け付けられます。  
  
Disabling the virtual tracker release the overwrite.  
To work overwrite, the target HMD and controller must be powered on and properly tracked.   
仮想トラッカーを無効にすると、上書きは解除されます。  
上書きを機能させるには、対象のHMDとコントローラの電源が入っており、正常にトラッキングされている状態にする必要があります。  

## setting.json
Basicaly, set false to old version compatible.  
基本的にfalseにすることで古い挙動に戻ります(旧バージョンに対する互換性)。  

```json
{
	"HMDisIndex0": Serial number "HMD" as HMD(Index 0)/「HMD」というシリアルをIndex 0(HMD)として扱うか,
	"OptoutTrackingRole": Optout Tracking Role when tracker,tracking reference / トラッキングロールのオプトアウトを行うか(トラッカー、トラッキングリファレンス),
	"ReceivePort": OSC Receive port / 受信ポート,
	"RejectWhenCannotTracking": Stop when tracking lost / 異常時にトラッキングを停止するか,
	"RoomMatrix": Room Matrix / ルーム行列,
	"SendPort": OSC Send port / 送信ポート,
	"VelocityEnable": Velocity, angular velocity emuration enable / 速度・角速度エミュレーション
}
```
