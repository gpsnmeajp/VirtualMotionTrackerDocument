---
title: How it works
description: 仕組みについて
---

# How it works / 仕組み

![](/VirtualMotionTrackerDocument/image/Architecture.png)

## VMT Driver 
C++ OpenVR driver. Receives the virtual tracker attitude on OSC and transfers the attitude to SteamVR.
It transforms coordinate. it will start up with SteamVR and exit.

You can check for errors etc. from the SteamVR web console.
The settings are recorded in the driver folder setting.json. 

C++製OpenVRドライバです。OSCでの仮想トラッカー姿勢の受信と、SteamVRへの姿勢の受け渡しを行います。  
座標変換はここでやっています。SteamVRとともに起動し、終了します。  
SteamVRのWeb Consoleからエラーなどを確認することができます。  
設定はドライバフォルダのsetting.jsonに記録されます。  
   
## VMT Manager 
C# made management tool. It is used for driver installation / uninstallation, setting / adjustment, and operation check.

Start it only when you need it. You don't have to start it every time.

If you redo the room setup, please redo the setting (Set Room Matrix) with this tool. 

C#製管理ツールです。ドライバのインストールやアンインストール、設定や調整、動作確認の際に使用します。  
必要なときだけ起動してください。毎度起動する必要はありません。  
ルームセットアップをやり直したときは、このツールでの設定(Set RoomMatrix)もやり直してください。  

## Hardship story / 苦労話

+ [Virtual Motion Trackerを作ったときのノウハウ](https://qiita.com/gpsnmeajp/items/9c41654e6c89c6b9702f)
+ [Virtual Motion TrackerとSkeletal Input苦労録](https://qiita.com/gpsnmeajp/items/b3d53f41c1a1fa3aefe5)

## Functions
もしあなたがOpenVR Driver開発中で、下記のような関数の設定にお悩みでしたら、本プロジェクトのソースが参考になります。  
If you are developing the OpenVR Driver and have trouble use the functions like the ones below, this project source will be helpful.

+ GetRawTrackedDevicePoses
+ TrackedDeviceToPropertyContainer
+ TrackedDeviceAdded
+ UpdateBooleanComponent
+ UpdateScalarComponent
+ UpdateSkeletonComponent