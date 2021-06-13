# VMT - VirtualMotionTracker 説明書
## 注意
アップデートの際は、古いドライバを予めアンインストールするか、フォルダごと消してください。  
古いドライバが読み込まれて動かないことがあります。  

## 仕組み
**VMT**  
C++製OpenVRドライバです。OSCでの仮想トラッカー姿勢の受信と、SteamVRへの姿勢の受け渡しを行います。  
座標変換はここでやっています。正常に動いていればSteamVRとともに起動し、終了します。  
SteamVRのWeb Consoleからエラーなどを確認することができます。  
設定はドライバフォルダのsetting.jsonに記録されます。  
    
**VMT Manager**  
C#製管理ツールです。ドライバのインストールやアンインストール、設定や調整、動作確認の際に使用します。  
必要なときだけ起動してください。毎度起動する必要はありません。  
ルームセットアップをやり直したときは、このツールでの設定(Set RoomMatrix)もやり直してください。  
 
## [＊ドライバのインストールと初期設定](howto.md)
[ルームセットアップを実施しないと、位置や姿勢がずれます。](howto.md)
  
## OSCプロトコル

|方向|ポート番号|
|---|---|
|App → Driver| 39570|
|Manager → Driver| 39570|
|Manager ← Driver| 39571|

注意: 39571が使用されているとManagerは起動しません。  
  
### 仮想トラッカー制御
**仮想トラッカーの引数**  

|識別子|型|内容|
|---|---|---|
|index|int| 識別番号。現在0～57まで利用できます。|
|enable|int| 有効可否。0=無効, 1=有効(トラッカー), 2=有効(左コントローラ), 3=有効(右コントローラ), 4=有効(TrackingReference)|
|timeoffset|float| 補正時間。通常0です。|
|x,y,z|float| 座標|
|qx,qy,qz,qw|float| 回転(クォータニオン)|
|serial|string| 対象デバイスシリアル番号(LHR-xxxxxxx) or HMD(HMD)|

※種別(トラッカー or コントローラ)は初回のみ反映されます。  

**/VMT/Room/Unity index, enable, timeoffset, x, y, z, qx, qy, qz, qw**  
Unityと同じ左手系、かつ、ルーム空間(ルーム空間変換あり)で仮想トラッカーを操作します。  
通常はこれを使用します。  
  
**/VMT/Room/Driver index, enable, timeoffset, x, y, z, qx, qy, qz, qw**   
OpenVRの右手系、かつ、ルーム空間(ルーム空間変換あり)で仮想トラッカーを操作します。  
  
**/VMT/Raw/Unity index, enable, timeoffset, x, y, z, qx, qy, qz, qw**  
Unityと同じ左手系、かつ、ドライバー空間(ルーム空間変換なし)で仮想トラッカーを操作します。  
  
**/VMT/Raw/Driver index, enable, timeoffset, x, y, z, qx, qy, qz, qw**  
OpenVRの右手系、かつ、ドライバー空間(ルーム空間変換なし)で仮想トラッカーを操作します。  
  
**/VMT/Joint/Unity index, enable, timeoffset, x, y, z, qx, qy, qz, qw, serial**  
Unityと同じ左手系、かつ、指定デバイス空間(回転はデバイス基準)で仮想トラッカーを操作します。  
  
**/VMT/Joint/Driver index, enable, timeoffset, x, y, z, qx, qy, qz, qw, serial**  
OpenVRの右手系、かつ、指定デバイス空間(回転はデバイス基準)で仮想トラッカーを操作します。  
  
**/VMT/Follow/Unity index, enable, timeoffset, x, y, z, qx, qy, qz, qw, serial**  
Unityと同じ左手系、かつ、指定デバイス位置(回転はルーム空間)で仮想トラッカーを操作します。  
  
**/VMT/Follow/Driver index, enable, timeoffset, x, y, z, qx, qy, qz, qw, serial**  
OpenVRの右手系、かつ、指定デバイス空間(回転はルーム空間)で仮想トラッカーを操作します。  
  
### 入力操作
|種類|範囲|
|---|---|
|ButtonIndex(int)| 0～7|
|TriggerIndex(int)| 0, 1|
|JoyStickIndex(int)| 0|

**/VMT/Input/Button index, buttonindex, timeoffset, value**  
ボタン入力をします。  
value(int):1=press, 0=Release  
  
**/VMT/Input/Trigger index, triggerindex, timeoffset, value**  
トリガー入力をします。  
value(float):0.0 ～ 1.0  

**/VMT/Input/Joystick index, joystickindex, timeoffset, x, y**  
ジョイスティック入力をします。  
x,y(float):-1.0 ～ 1.0  
  
### ドライバ操作
**/VMT/Reset**  
すべてのトラッカーを非トラッキング状態にします。  
  
**/VMT/LoadSetting**  
ドライバーのjson設定を再読込します。  
  
**/VMT/SetRoomMatrix m1,m2,m3,m4,m5,m6,m7,m8,m9,m10,m11,m12**  
RoomToDriver空間変換行列を設定し保存します。  
設定と同時にjsonに書き込むため、毎フレーム送るなど頻繁な送信は禁止します。  

**/VMT/SetRoomMatrix/Temporary m1,m2,m3,m4,m5,m6,m7,m8,m9,m10,m11,m12**  
RoomToDriver空間変換行列を一時的に設定します。  
こちらは一時的に適用され、再起動すると揮発します。  

**/VMT/SetAutoPoseUpdate enable**  
姿勢の自動更新をオンにします。(jointが自動追従するようになります)  
enable 1=on, 0=off  

### ドライバ側応答
**/VMT/Out/Log stat,msg**  
stat(int): 状態(0=info,1=warn,2=err)  
msg(string): メッセージ  
  
**/VMT/Out/Alive version, installpath**  
version(string): バージョン  
installpath(string): ドライバのインストールパス  

**/VMT/Out/Haptic index, frequency, amplitude, duration**  
frequency(float): 周波数  
amplitude(float): 振幅  
duration(float): 長さ  

**/VMT/Out/Unavailable code, reason**  
code(int): 利用不可コード(0=利用可能, 1=ルーム行列が設定されていない)  
reason(string): 詳細(人間が読む用)  
  
### Unityサンプル
[hecomi/uOSC](https://github.com/hecomi/uOSC)を導入してください。  
アタッチされたGameObjectの座標をトラッカーとして送信します。  
  
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
## コマンドライン引数
|例|機能|
|---|---|
|vmt_manager.exe install|ドライバをインストールします|
|vmt_manager.exe uninstall|ドライバをアンインストールします|

## Tracking Override
SteamVRには、開発中のデバイスのデバッグのため、既存のデバイスの姿勢を、  
指定したデバイスの姿勢で上書きする機能があります。  
https://github.com/ValveSoftware/openvr/wiki/TrackingOverrides

例として、steamvr.vrsettingsに以下の記述を追加すると、トラッカー0=HMD, 1=左手, 2=右手の制御ができます。  

```
   "TrackingOverrides" : {
      "/devices/vmt/VMT_0" : "/user/head",
      "/devices/vmt/VMT_1" : "/user/hand/left",
      "/devices/vmt/VMT_2" : "/user/hand/right"
   },
```

ボタンやスティックの操作は仮想トラッカーからはできません。  
コントローラ本体の操作が受け付けられます。  
  
仮想トラッカーを無効にすると、上書きは解除されます。  
上書きを有効にする際は、対象のHMDとコントローラの電源が入っており、正常にトラッキングされている状態にする必要があります。  
  
## setting.json
基本的にfalseにすることで古い挙動に戻ります(旧バージョンに対する互換性)。

```
{
	"HMDisIndex0": 「HMD」というシリアルをIndex 0(HMD)として扱うか,
	"OptoutTrackingRole": トラッキングロールのオプトアウトを行うか(トラッカー、トラッキングリファレンス),
	"ReceivePort": 受信ポート,
	"RejectWhenCannotTracking": 異常時にトラッキングを停止するか,
	"RoomMatrix": ルーム行列,
	"SendPort": 送信ポート,
	"VelocityEnable": 速度・角速度エミュレーション
}
```
