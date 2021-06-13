---
title: Advanced
description: 応用的な使い方
---

# Advanced / 応用的な使い方
## How to set the  controller bainding. / コントローラーバンディングの設定方法
### 0. Fist / はじめに
この作業は必要なアプリ(SteamVR Input)とそうでないアプリ(Legacy Input)があります。
VRアプリの公式サイトに「トラッカーの役割を設定するように」と記載がある場合、この作業が必要になる可能性が高いです。

There are some apps that need this work (Steam VR Input) and some that don't (Legacy Input).  
If the official website of the VR app says "Set the role of tracker", this is likely to be necessary.  

### 1. Preparation / 事前準備
#### 1. Start SteamVR / SteamVRを起動
![](/VirtualMotionTrackerDocument/image/advA1.png)

#### 2. Register the required amount of VMT. / 必要分のVMTを登録する
Press the Show all button to register all trackers.  
Show allボタンを押すと全トラッカーが認識されます。
![](/VirtualMotionTrackerDocument/image/adv3.png)

#### 3. Launch the app. / アプリを起動

### 2. Tracker roll settings  / トラッカーロールの設定
#### 1. Open Tracker setting / トラッカー設定を開く
SteamVR → Controllers → MANAGE VIVE TRACKERS  
SteamVRの設定→コントローラ→VIVEトラッカーの管理
![](/VirtualMotionTrackerDocument/image/advA2.png)
![](/VirtualMotionTrackerDocument/image/advA3.png)
#### 2. Set tracker role. (Left foot, Ritght foot ...) /「トラッカーの役割」を設定(左足、右足など)
![](/VirtualMotionTrackerDocument/image/advA4.png)
![](/VirtualMotionTrackerDocument/image/advA5.png)

#### 3. Close / 閉じる

### 3. Creating a controller bainding. / コントローラーバンディングの作成
#### 1. Show old binding ui / 古いバインド設定UIを表示
SteamVR→Controllers→SHOW OLD BINDING UI  
SteamVRの設定→コントローラ→古いバインド設定UIを表示  
![](/VirtualMotionTrackerDocument/image/advA3.png)

#### 2. Select the app you want to set  / 設定したいアプリを選択
It will not be displayed if it is not app started.   
アプリを起動していないと表示されません  
![](/VirtualMotionTrackerDocument/image/advB1.png)

#### 3. Select VMT / VMTを選択
From "Current Controller", select the VMT for each part.   
「現在のコントローラ」から、各部位別のVMTを選択します。

(vmt_leftfoot, vmt_rightfoot, etc. If you don't see this, you may not have "Tracker Role" set or you are using something older than VMT_009. Try using the latest VMT.)   
(vmt_leftfoot, vmt_rightfootなど。これが出ない場合は、「トラッカーの役割」が設定されていないか、VMT_009より古いものを使用している可能性があります。最新のVMTを使用してみてください。)

![](/VirtualMotionTrackerDocument/image/advB2.png)
![](/VirtualMotionTrackerDocument/image/advB3.png)

#### 4. Select "Create New Binding" /「バインドの新規作成」を選択
![](/VirtualMotionTrackerDocument/image/advB4.png)

#### 5. Select "Edit Action Pose" /「アクションポーズの編集」を選択
![](/VirtualMotionTrackerDocument/image/advB5.png)

#### 6. Click "Unused" in the pose / ポーズの「未使用」をクリック
![](/VirtualMotionTrackerDocument/image/advB6.png)

#### 7. Select a pose action  / ポーズアクションを選択
![](/VirtualMotionTrackerDocument/image/advB7.png)

#### 8. OK "***pose" (Recomended: right_pose) /「***pose」になればOK (right_poseが推奨)
![](/VirtualMotionTrackerDocument/image/advB8.png)

#### 9. Repeat 3 to 8 for each part. / 各部位にて、3～8を繰り返します。
![](/VirtualMotionTrackerDocument/image/advB9.png)

#### 10. When you're done, click "Back" to save  / 終わったら「戻る」で保存されます
#### 11. Check if the app recognizes it. / アプリで認識しているかを確認します。
If it doesn't work, try swapping poses  
上手く動かない場合は、poseを入れ替えてみる

### If there are extra bindings you didn't want. /余分なBindingがある場合
C:\Program Files (x86)\Steam\config\steamvr.vrsettings  
から必ずバックアップを取った後、「vmt」を含む行をすべて削除してみてください。

C:\Program Files (x86)\Steam\config\steamvr.vrsettings  
Be sure to make a backup from, and then try deleting all the lines that contain "vmt".

Please note that if you make a mistake, all SteamVR settings will be lost.   
編集を誤るとSteamVRの設定がすべて消失するため注意してください。


## 各画面の解説
### Install
Install, uninstall, version information, error information  
インストール、アンインストール、バージョン情報、エラー情報
![](/VirtualMotionTrackerDocument/image/adv1.png)

### RoomSetup
Room matrix setting, position check  
ルーム行列の設定、位置の動作確認  
![](/VirtualMotionTrackerDocument/image/adv2.png)

### Control
All devices off, on, configuration reload, auto-update, load test   
全デバイスのオフ、オン、設定の再読み込み、自動更新、負荷テスト
![](/VirtualMotionTrackerDocument/image/adv3.png)

### Input
Confirmation of operation as a device controller.  
デバイスのコントローラーとしての動作確認
![](/VirtualMotionTrackerDocument/image/adv4.png)

### Device
Serial number of the tool to recognize  
認識しているデバイスのシリアル番号一覧
![](/VirtualMotionTrackerDocument/image/adv5.png)

### Json
Edit configuration file  
設定ファイルの編集  
![](/VirtualMotionTrackerDocument/image/adv6.png)
