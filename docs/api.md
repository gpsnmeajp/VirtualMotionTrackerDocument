---
title: API
description: 技術的な使い方・プロトコル
---

# API
[SteamVRで自作のデバイスやソフトを簡単にトラッカーとして認識させる方法(バーチャルモーショントラッカー)](https://qiita.com/gpsnmeajp/items/29adc31f30e531fe8023)

## OSC
What is OSC(Open Sound Control)  
OSCとは  

+ [OpenSound Control - Wikipedia](https://en.wikipedia.org/wiki/Open_Sound_Control)
+ [OpenSound Control - ウィキペディア](https://ja.wikipedia.org/wiki/OpenSound_Control)
+ [Spec 1.0 - OpenSoundControl.org](https://ccrma.stanford.edu/groups/osc/spec-1_0.html)
+ [Open Sound Control (OSC) 1.0 仕様 [日本語訳]](http://veritas-vos-liberabit.com/trans/OSC/OSC-spec-1_0.html)

I recommended to use [uOSC](https://github.com/hecomi/uOSC) in Unity.  
Unityでは[uOSC](https://github.com/hecomi/uOSC)の利用を推奨します。

## Notice

Some applications require SteamVR settings to recognize full body tracking.  
一部のアプリケーションは、フルボディトラッキングを認識させるためにSteamVRの設定が必要です。  
-> Setting: [Advanced](advanced.md)  

## Sample
→[Sample](sample.md)

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
|enable|int| mode (see below) / モード (下記参照)|
|timeoffset|float| Timeoffset/補正時間。Always 0 / 基本的に0です|
|x,y,z|float| Position / 位置座標|
|qx,qy,qz,qw|float| Rotation(Quaternion) / 回転(クォータニオン)|
|rx,ry,rz|float| Rotation(Euler angles, Degree) / 回転(オイラー角, 度数法)|
|serial|string| Joint, Follow target device serial / 追従対象のデバイスシリアル(LHR-xxxxxxx) or HMD(HMD)|

|enable(int)|mode|
|---|---|
|0|Disable / 無効|
|1|Tracker / トラッカー|
|2|Left Controller / 左コントローラ|
|3|Right Controller / 右コントローラ|
|4|Tracking Reference|
|5|Left Controller (Index compatible mode) / 左コントローラ(Index互換モード)|
|6|Right Controller (Index compatible mode) / 右コントローラ(Index互換モード)|
|7|Tracker (VIVE tracker compatible mode) / トラッカー(VIVE Tracker互換モード)|

!!! Note
    TType(Tracker or Controller) only works in first registration time. (from boot up of SteamVR).  
    種別(トラッカー or コントローラ)はデバイス登録時(SteamVR起動時からの初回のみ)反映されます。  

**/VMT/Room/Unity (int)index, (int)enable, (float)timeoffset, (float)x, (float)y, (float)z, (float)qx, (float)qy, (float)qz, (float)qw**  
Unity lik Left-handed space, Quaternion, and Room space. (Recommended)  
Unityと同じ左手系かつ、クォータニオンかつ、ルーム空間(推奨)  

**/VMT/Room/UEuler (int)index, (int)enable, (float)timeoffset, (float)x, (float)y, (float)z, (float)rx, (float)ry, (float)rz**  
Unity lik Left-handed space, Euler angles, and Room space.  
Unityと同じ左手系かつ、オイラー角かつ、ルーム空間(推奨)  

**/VMT/Room/Driver (int)index, (int)enable, (float)timeoffset, (float)x, (float)y, (float)z, (float)qx, (float)qy, (float)qz, (float)qw**   
OpenVR Driver Right-handed space, Quaternion, and Room space.  
OpenVR Driverの右手系かつ、クォータニオンかつ、ルーム空間  


**/VMT/Raw/Unity (int)index, (int)enable, (float)timeoffset, (float)x, (float)y, (float)z, (float)qx, (float)qy, (float)qz, (float)qw**  
Unity lik Left-handed space, Quaternion, and Driver space.  
Unityと同じ左手系かつ、クォータニオンかつ、ドライバー空間  
  
**/VMT/Raw/UEuler (int)index, (int)enable, (float)timeoffset, (float)x, (float)y, (float)z, (float)rx, (float)ry, (float)rz**  
Unity lik Left-handed space, Euler angles, and Driver space.  
Unityと同じ左手系かつ、オイラー角かつ、ドライバー空間  
  
**/VMT/Raw/Driver (int)index, (int)enable, (float)timeoffset, (float)x, (float)y, (float)z, (float)qx, (float)qy, (float)qz, (float)qw**  
OpenVR Driver Right-handed space, Quaternion, and Driver space.  
OpenVRの右手系かつ、クォータニオンかつ、ドライバー空間  


**/VMT/Joint/Unity (int)index, (int)enable, (float)timeoffset, (float)x, (float)y, (float)z, (float)qx, (float)qy, (float)qz, (float)qw, (string)serial**  
Unity lik Left-handed space, Quaternion, and Traget device space(Traget device rotation).  
Unityと同じ左手系かつ、クォータニオンかつ、指定デバイス空間(回転はデバイス基準)  
  
**/VMT/Joint/UEuler (int)index, (int)enable, (float)timeoffset, (float)x, (float)y, (float)z, (float)rx, (float)ry, (float)rz, (string)serial**  
Unity lik Left-handed space, Euler angles, and Traget device space(Traget device rotation).  
Unityと同じ左手系かつ、オイラー角かつ、指定デバイス空間(回転はデバイス基準)  
  
**/VMT/Joint/Driver (int)index, (int)enable, (float)timeoffset, (float)x, (float)y, (float)z, (float)qx, (float)qy, (float)qz, (float)qw, (string)serial**  
OpenVR Driver Right-handed space, Quaternion, and Traget device space(Traget device rotation).  
OpenVRの右手系かつ、クォータニオンかつ、指定デバイス空間(回転はデバイス基準)  


**/VMT/Follow/Unity (int)index, (int)enable, (float)timeoffset, (float)x, (float)y, (float)z, (float)qx, (float)qy, (float)qz, (float)qw, (string)serial**  
Unity lik Left-handed space, Quaternion, and Traget device position(Room Rotation).  
Unityと同じ左手系かつ、クォータニオンかつ、指定デバイス位置(回転はルーム空間)  
  
**/VMT/Follow/UEuler (int)index, (int)enable, (float)timeoffset, (float)x, (float)y, (float)z, (float)rx, (float)ry, (float)rz, (string)serial**  
Unity lik Left-handed space, Euler angles, and Traget device position(Room Rotation).  
Unityと同じ左手系かつ、オイラー角かつ、指定デバイス位置(回転はルーム空間)  
  
**/VMT/Follow/Driver (int)index, (int)enable, (float)timeoffset, (float)x, (float)y, (float)z, (float)qx, (float)qy, (float)qz, (float)qw, (string)serial**  
OpenVR Driver Right-handed space, Quaternion, and Traget device position(Room Rotation).  
OpenVRの右手系かつ、クォータニオンかつ、指定デバイス空間(回転はルーム空間)  


### Controle virtual skeleton / 仮想ボーン制御

See 

+ [SteamVR-Skeletal-Input](https://github.com/ValveSoftware/openvr/wiki/SteamVR-Skeletal-Input)
+ [Hand-Skeleton](https://github.com/ValveSoftware/openvr/wiki/Hand-Skeleton)
+ [Creating-a-Skeletal-Input-Driver](https://github.com/ValveSoftware/openvr/wiki/Creating-a-Skeletal-Input-Driver)

|Identifier / 識別子|Type / 型|Detail / 内容|
|---|---|---|
|index|int| Index(0～57) / インデックス(0～57)|
|boneSetIndex|int| Bone set index(0～5) / ボーンセットのインデックス(0～5)|
|boneIndex|int| Bone index(0～30) / ボーンのインデックス(0～30)|
|timeoffset|float| Timeoffset/補正時間。Always 0 / 基本的に0です|
|value|float| Modulus of deformation of Fist to Open hand(0.0～1.0) / こぶし～開いた手の係数 (0.0～1.0)|
|x,y,z|float| Position / 位置座標|
|qx,qy,qz,qw|float| Rotation(Quaternion) / 回転(クォータニオン)|
|rx,ry,rz|float| Rotation(Euler angles, Degree) / 回転(オイラー角, 度数法)|

|Bone set index / ボーンセットインデックス|Detail / 内容|
|---|---|
|RootAndWrist|0|
|Thumb|1|
|Index|2|
|Middle|3|
|Ring|4|
|Pinky (Little)|5|


|Bone index / ボーンのインデックス|Detail / 内容|
|---|---|
|Root|0|
|Wrist|1|
|Thumb0_ThumbProximal|2|
|Thumb1_ThumbIntermediate|3|
|Thumb2_ThumbDistal|4|
|Thumb3_ThumbEnd|5|
|IndexFinger0_IndexProximal|6|
|IndexFinger1_IndexIntermediate|7|
|IndexFinger2_IndexDistal|8|
|IndexFinger3_IndexDistal2|9|
|IndexFinger4_IndexEnd|10|
|MiddleFinger0_MiddleProximal|11|
|MiddleFinger1_MiddleIntermediate|12|
|MiddleFinger2_MiddleDistal|13|
|MiddleFinger3_MiddleDistal2|14|
|MiddleFinger4_MiddleEnd|15|
|RingFinger0_RingProximal|16|
|RingFinger1_RingIntermediate|17|
|RingFinger2_RingDistal|18|
|RingFinger3_RingDistal2|19|
|RingFinger4_RingEnd|20|
|PinkyFinger0_LittleProximal|21|
|PinkyFinger1_LittleIntermediate|22|
|PinkyFinger2_LittleDistal|23|
|PinkyFinger3_LittleDistal2|24|
|PinkyFinger4_LittleEnd|25|
|Aux_Thumb_ThumbHelper|26|
|Aux_IndexFinger_IndexHelper|27|
|Aux_MiddleFinger_MiddleHelper|28|
|Aux_RingFinger_RingHelper|29|
|Aux_PinkyFinger_LittleHelper|30|

!!! Note
    Bone information is reflected by **Apply** after registering for each bone.  
    ボーン情報は、ボーン単位で登録した後、**Apply**することで反映されます。

!!! Note
    The values of x,y,z, qx,qy,qz, rx,ry,rz should be set according to vr_glove_left_model.fbx, vr_glove_right_model.fbx.  
    x,y,z, qx,qy,qz, rx,ry,rz の値は、vr_glove_left_model.fbx, vr_glove_right_model.fbxにもとづいて設定する必要があります。  
    [See Hand-Skeleton](https://github.com/ValveSoftware/openvr/wiki/Hand-Skeleton)

**/VMT/Skeleton/Scalar (int)index, (int)boneSetIndex, (float)value, (int)0, (int)0**  
Bone set unit, and Linear space. (Strongly Recommended)  
Simple reproduction by hand opening degree value.  
ボーンセット単位、直線空間(強く推奨)  
手の開き具合値による簡易再現

※0, 0 : = Reserved value (blend mode(0=FistToOpenHand), AxisLinkEnable(1=true, 0=false))

**/VMT/Skeleton/Unity (int)index, (int)boneIndex, (float)x, (float)y, (float)z, (float)qx, (float)qy, (float)qz, (float)qw**  
Per one bone, Unity lik Left-handed space, Quaternion, and Hand space. (Recommended)  
It is possible to fully reproduce the hand by bone control including finger spacing and hand twist. See vr_glove_*_model.fbx on SteamVR.  
ボーン1本単位、Unityと同じ左手系かつ、クォータニオンかつ、手空間  
指の間隔や手の捻りまで含めたボーン制御による手の完全再現が可能。SteamVRのvr_glove_*_model.fbxを参照。

**/VMT/Skeleton/UEuler (int)index, (int)boneIndex, (float)x, (float)y, (float)z, (float)rx, (float)ry, (float)rz**  
Per one bone, Unity lik Left-handed space, Euler angles, and Hand space.  
It is possible to fully reproduce the hand by bone control including finger spacing and hand twist. See vr_glove_*_model.fbx on SteamVR.  
ボーン1本単位、Unityと同じ左手系かつ、オイラー角かつ、手空間  
指の間隔や手の捻りまで含めたボーン制御による手の完全再現が可能。SteamVRのvr_glove_*_model.fbxを参照。

**/VMT/Skeleton/Driver (int)index, (int)boneIndex, (float)x, (float)y, (float)z, (float)qx, (float)qy, (float)qz, (float)qw**   
Per one bone, OpenVR Driver Right-handed space, Quaternion, and Hand space.  
It is possible to fully reproduce the hand by bone control including finger spacing and hand twist. See vr_glove_*_model.fbx on SteamVR.  
ボーン1本単位、OpenVR Driverの右手系かつ、クォータニオンかつ、手空間  
指の間隔や手の捻りまで含めたボーン制御による手の完全再現が可能。SteamVRのvr_glove_*_model.fbxを参照。

**/VMT/Skeleton/Apply (int)index, (float)timeoffset**  
Reflect registered bone information. (Required)  
登録したボーン情報を反映する(必須)


### Input / 入力操作
|種類|範囲|
|---|---|
|ButtonIndex(int)| 0～17|
|TriggerIndex(int)| 0-8|
|JoyStickIndex(int)| 0-3|
|timeoffset|float| Timeoffset / 補正時間。Always 0 / 基本的に0です|


|Index Compatible|Button and Axis|
|---|---|
|System|Button 0|
|A|Button 1|
|B|Button 3|
|Trigger|Trigger 0|
|Grip|Trigger 1|
|Grip Force|Trigger 2|
|Finger Index|Trigger 3|
|Finger Middle|Trigger 4|
|Finger Ring|Trigger 5|
|Finger Pinky|Trigger 6|
|Trackpad Force|Trigger 7|
|Trackpad|Joystick 0|
|Thumb|Joystick 1|


**/VMT/Input/Button (int)index, (int)buttonIndex, (float)timeoffset, (int)value**  
Button input.
ボタン入力  
value(int):1=press, 0=Release  

**/VMT/Input/Button/Touch (int)index, (int)buttonIndex, (float)timeoffset, (int)value**  
Button touch input.
ボタンのタッチ入力  
value(int):1=press, 0=Release  

**/VMT/Input/Trigger (int)index, (int)triggerIndex, (float)timeoffset, (float)value**  
Trigger input.
トリガー入力  
value(float):0.0 ～ 1.0  

**/VMT/Input/Trigger/Touch (int)index, (int)triggerIndex, (float)timeoffset, (int)value**  
Trigger touch input.
トリガータッチ入力  
value(int):1=press, 0=Release  

**/VMT/Input/Trigger/Click (int)index, (int)triggerIndex, (float)timeoffset, (int)value**  
Trigger click input.
トリガークリック入力  
value(int):1=press, 0=Release  

**/VMT/Input/Joystick (int)index, (int)joystickIndex, (float)timeoffset, (float)x, (float)y**  
Joystick input.
ジョイスティック入力  
x,y(float):-1.0 ～ 1.0  
  
**/VMT/Input/Joystick/Touch (int)index, (int)joystickIndex, (float)timeoffset, (int)value**  
Joystick touch input.
ジョイスティックタッチ入力  
value(int):1=press, 0=Release  
  
**/VMT/Input/Joystick/Click (int)index, (int)joystickIndex, (float)timeoffset, (int)value**  
Joystick click input.
ジョイスティッククリック入力  
value(int):1=press, 0=Release  
  
### Driver control / ドライバ操作

|種類|範囲|
|---|---|
|ButtonIndex(int)| 0～17|
|TriggerIndex(int)| 0-8|
|JoyStickIndex(int)| 0-3|
|timeoffset|float| Timeoffset / 補正時間。Always 0 / 基本的に0です|
|serial|string| Target device serial / 対象のデバイスシリアル(LHR-xxxxxxx) or HMD(HMD)|
|enable|int| Enable / 有効可否。0=Disable/無効, 1=Enable/有効|

**/VMT/Reset**  
Turn off all tracker.
すべてのトラッカーを電源オフにする  
  
**/VMT/LoadSetting**  
Reload driver setting json.
ドライバーのjson設定を再読込します。  
  
**/VMT/SetRoomMatrix (float)m1,(float)m2,(float)m3,(float)m4,(float)m5,(float)m6,(float)m7,(float)m8,(float)m9,(float)m10,(float)m11,(float)m12**  
**/VMT/Set/RoomMatrix (float)m1,(float)m2,(float)m3,(float)m4,(float)m5,(float)m6,(float)m7,(float)m8,(float)m9,(float)m10,(float)m11,(float)m12**  
Set and Save Room Matrix. Please do not send periodic. it writes setting on drive.    
RoomToDriver空間変換行列を設定し保存します。  
定期的に送信しないでください。これはディスクへの書き込みを行います。

**/VMT/SetRoomMatrix/Temporary (float)m1,(float)m2,(float)m3,(float)m4,(float)m5,(float)m6,(float)m7,(float)m8,(float)m9,(float)m10,(float)m11,(float)m12**  
**/VMT/Set/RoomMatrix/Temporary (float)m1,(float)m2,(float)m3,(float)m4,(float)m5,(float)m6,(float)m7,(float)m8,(float)m9,(float)m10,(float)m11,(float)m12**  
Set Room Matrix temporary. It is volatile on restart.    
RoomToDriver空間変換行列を一時的に設定します。  
こちらは一時的に適用され、再起動すると揮発します。  

**/VMT/SetAutoPoseUpdate (int)enable**  
**/VMT/Set/AutoPoseUpdate (int)enable**  
Set Pose auto update. 姿勢の自動更新をオンにします。  
enable 1=on, 0=off  

**/VMT/Get/Devices/List**  
Get OpenVR device list string.   
OpenVR デバイスのリストを返します。

**/VMT/Subscribe/Device (string)serial**  
Subscribe to OpenVR device coordinates and send every frame.  
OpenVRデバイスの座標を購読し、毎フレーム送信します。  

**/VMT/Unsubscribe/Device (string)serial**  
Unsubscribing to OpenVR device coordinates  
OpenVRデバイスの座標の購読の解除

**/VMT/RequestRestart**  
Prompt user to restart Steam VR  
Steam VRの再起動をユーザーに要求する

**/VMT/SetDiagLog (int)enable**  
**/VMT/Set/DiagLog (int)enable**  
Enable / Disable diagnostic log. (Output to SteamVR Web　Console)
診断用ログを有効/無効にする(SteamVR ウェブコンソールへ出力します)

**/VMT/Config (string)name (string)value**  
Write json configuration.  Please do not send periodic. it writes setting on drive.    
JSON設定への書き込み  
定期的に送信しないでください。これはディスクへの書き込みを行います。  
name(string), value(string)

**/VMT/Set/Destination (string)ip_address (int)port**  
Switch  destination for OSC responses from the Driver.  
DriverからのOSC応答の送信先を指定したものに切り替えます。

**/VMT/Debug (string)command**  
Debug command (See driver source.)  
デバッグコマンド (ドライバソース参照)  
command(string)

### Driver response /ドライバ側応答
**/VMT/Out/Log (int)stat, (string)msg**  
stat(int): Dialog message type / ダイアログメッセージ種別 (0=info,1=warn,2=err)  
msg(string): Message メッセージ  
  
**/VMT/Out/Alive (string)version, (string)installpath**  
version(string): Driver version / ドライババージョン  
installpath(string): Driver install path / ドライバのインストールパス  

**/VMT/Out/Haptic (int)index, (float)frequency, (float)amplitude, (float)duration**  
frequency(float): frequency / 周波数  
amplitude(float): amplitude / 振幅  
duration(float): duration / 長さ  

**/VMT/Out/Unavailable (int)code, (string)reason**  
code(int): Unavailable code / 利用不可コード(0=Available/利用可能, 1=Room Matrix has not been set./ルーム行列が設定されていない)  
reason(string): Reason(Human readable) / 詳細(人間が読む用)  

**/VMT/Out/Devices/List (string)info**  
info(string): device list separated new line / 改行区切りのデバイス一覧

**/VMT/Out/SubscribedDevice (string)serial, (float)x, (float)y, (float)z, (float)qx, (float)qy, (float)qz, (float)qw**  
serial(string): device (string)serial / デバイスシリアル  
x,y,z(float): position / 位置  
qx,qy,qz,qw: Rotation(Quaternion) / 回転(クォータニオン)  

OpenVR Driver Right-handed space, Quaternion, and Driver space.  
OpenVR Driverの右手系かつ、クォータニオンかつ、ドライバー空間  

## Command line / コマンドライン引数
エラーがある場合は、処理は実行されません。

|例|機能|
|---|---|
|c:\vmt_driver\vmt_manager\vmt_manager.exe install| Install driver / ドライバをインストールします|
|c:\vmt_driver\vmt_manager\vmt_manager.exe uninstall| Uninstall driver / ドライバをアンインストールします|
|c:\vmt_driver\vmt_manager\vmt_manager.exe setroommatrix| Set Room Matrix / Set Room Matrixを実行します|

## Tracking Override
SteamVR has the ability to overwrite the orientation of an existing device with the specified device orientation for debugging the device under development.   
SteamVRには、開発中のデバイスのデバッグのため、既存のデバイスの姿勢を指定したデバイスの姿勢で上書きする機能があります。  

[TrackingOverrides](https://github.com/ValveSoftware/openvr/wiki/TrackingOverrides)

As an example, if you add the following description to steamvr.vrsettings, you can control tracker 0 = HMD, 1 = left hand, 2 = right hand.   
例として、steamvr.vrsettingsに以下の記述を追加すると、トラッカー0=HMD, 1=左手, 2=右手の制御ができます。  

```json
   "TrackingOverrides" : {
      "/devices/vmt/VMT_0" : "/user/head",
      "/devices/vmt/VMT_1" : "/user/hand/left",
      "/devices/vmt/VMT_2" : "/user/hand/right"
   },
```


You can check the device path on the SteamVR System Report screen.  
Device Pathは、SteamVRシステムレポート画面で確認することができます。

Device Path can be specified for From, and Device Path or semantic name can be specified for To.  
FromにはDevice Path, ToにはDevice Pathあるいはsemantic nameが指定できます。

Disabling the virtual tracker release the overwrite.  
To work overwrite, the target HMD and controller must be powered on and properly tracked.   
仮想トラッカーを無効にすると、上書きは解除されます。  
上書きを機能させるには、対象のHMDとコントローラの電源が入っており、正常にトラッキングされている状態にする必要があります。  

Buttons and sticks cannot be operated from the virtual tracker.  
The operation from controller of original is accepted.  
この場合、ボタンやスティックの操作は仮想トラッカーからはできません。  
コントローラ本体の操作が受け付けられます。  

If you want to use the posture of the physical tracker or controller to reflect the buttons and fingers in the VMT, you can do so by setting the orientation in the opposite direction.
物理トラッカーやコントローラの姿勢を使い、ボタンや指をVMTで反映したいときは、逆向きに設定することで実現できます。

```json
   "TrackingOverrides" : {
      "/devices/xxxx/xxxx" : "/devices/vmt/VMT_0",
      "/devices/xxxx/yyyy" : "/devices/vmt/VMT_1",
      "/devices/xxxx/zzzz" : "/devices/vmt/VMT_2"
   },
```

|semantic name|
|---|
|/user/hand/right|
|/user/hand/left|
|/user/hand/primary|
|/user/hand/secondary|
|/user/head|
|/user/gamepad|
|/user/treadmill|
|/user/stylus|
|/user/foot/left|
|/user/foot/right|
|/user/shoulder/left|
|/user/shoulder/right|
|/user/elbow/left|
|/user/elbow/right|
|/user/knee/left|
|/user/knee/right|
|/user/waist|
|/user/chest|
|/user/camera|
|/user/keyboard|


## setting.json

```json
{
	"ReceivePort": "OSC Receive port / 受信ポート",
	"SendPort": "OSC Send port / 送信ポート",
	"RoomMatrix": "Room Matrix / ルーム行列",
	"OptoutTrackingRole": "Optout Tracking Role when tracker,tracking reference / トラッキングロールのオプトアウトを行うか(トラッカー、トラッキングリファレンス)",
	"RejectWhenCannotTracking": "Stop when tracking lost / 異常時にトラッキングを停止するか",
	"SkeletonInput": "Skeleton Input Enable / 骨格入力有効",
	"AutoPoseUpdateOnStartup": "Auto Pose Update on Startup / 自動姿勢更新を起動時に有効にする",
	"AddControllerOnStartup": "Add Controller On Startup / コントローラ追加を起動時に実施する",
	"AddCompatibleControllerOnStartup": "Add Controller On Startup(Index Compatible) / コントローラ追加を起動時に実施する(Index 互換)",
	"DiagLogOnStartup": "Diaglo enable on startup / 起動時に診断ログを有効化",
	"AlwaysCompatible": "Controller, Tracker as Always Compatible mode / コントローラ, トラッカーを常時互換モードにする",
}
```
