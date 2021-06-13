---
title: Trouble
description: 問題と解決方法
---

# Trouble / トラブル

## Do not break the VMT files apart. / VMTのファイルはばらばらにしないでください。
All placements within the VMT folder are important. Do not move only part of it.   
VMTのフォルダ内の配置は全て重要です。一部だけを移動することはしないでください。

## Doesn't work with specific VR applications / 特定のVRアプリケーションで動かない
[Advanced](advanced.md) にある設定をしてください  
Make the settings in [Advanced](advanced.md)  

## Unable to communicate with VMT / VMTと通信できません
If you have not installed it, please install it.  
インストールしていない場合は、インストールしてください。  

If it doesn't work after many attempts, check the following and fix it.  

+ Is it blocked by a firewall? → unblock
+ Is it placed in a folder path that includes Space, Japanese, Chinese, or other non-ASCII? → move not included path
+ Is it placed in Program files?  → move other path

何度試してもだめな場合は、以下を確認し、修正してください。  

+ ファイアーウォールで妨害されていないか → 解除してください
+ 日本語、中国語、その他ASCII外文字や空白を含むフォルダパスに置いていないか → 含まない場所においてください
+ Program filesに置いていないか → 別の場所に移動してください
  
![](/VirtualMotionTrackerDocument/image/trouble2.png)

![](/VirtualMotionTrackerDocument/image/firewall.png)

## Room matrix is not set / ルーム行列が設定されていません
"Set Room Matrix"を押してください。  
Click "Set Room Matrix".

![](/VirtualMotionTrackerDocument/image/trouble1.png)

## Room matrix is red / ルーム行列が赤色
SteamVR is not working properly, such as the base station is not turned on or the HMD cannot see the base station.   
ベースステーションの電源が入っていない、HMDからベースステーションが見えないなど、SteamVRが正常に動いていません。

![](/VirtualMotionTrackerDocument/image/troubleB.png)

## Room matrix is defferent / ルーム変換行列が違う
After pressing "Check VMT_0 Position" Button, if the "VMT_0 Room Position" turns red even though you haven't run any applications, the room transformation matrix may have changed.
Occurs when the room scale is set again. Press the "Set Room Matrix" button again. 

Check VMT_0 Positionを押した後、特にアプリケーションを動かしていないのにVMT_0 Room Position が赤色になる場合、ルーム変換行列が変わっている可能性があります。
ルームスケールの設定をやり直した場合などに発生します。再度、"Set RoomMatrix"ボタンを押してください。

![](/VirtualMotionTrackerDocument/image/troubleC.png)


## Communication failure when uninstalling / アンインストール時に通信失敗
If you press OK, it will try to uninstall, but the success rate is higher if you delete the entire VMT folder.   
OKを押すとアンインストールを試しますが、VMTのフォルダごと消すほうが成功率は高いです。

![](/VirtualMotionTrackerDocument/image/trouble3.png)

## Another version of VMT is installed / 違うバージョンのVMTがインストールされている
Uninstall and restart SteamVR.  
Uninstallをし、SteamVRを再起動してください

![](/VirtualMotionTrackerDocument/image/trouble4.png)

## VMT is already installed. / すでにVMTがインストールされている
Uninstall and restart SteamVR.  
Uninstallをし、SteamVRを再起動してください

![](/VirtualMotionTrackerDocument/image/trouble5.png)

## SteamVR is not available / SteamVRが利用できない
In most cases, restarting SteamVR, waiting about a minute, and then starting VMT Manager will work.   
多くの場合、SteamVRを再起動し、1分ほど待ってからVMT Managerを起動すると正常になります。

If it doesn't work, check the following. 

+ Is the HMD connected?
+ Is there an error on SteamVR?
+ Is SteamVR installed successfully? 

正常にならない場合は、以下を確認してください

+ HMDが接続されているか
+ SteamVRにエラーが表示されていないか
+ SteamVRが正常にインストールされているか

![](/VirtualMotionTrackerDocument/image/trouble6.png)

## requireHmd is false  / requireHmdがfalseに設定されている
Steam VR is in a special state. Operation in this state is not guaranteed.  
Steam VRが特殊な状態になっています。この状態での動作は保証していません。

![](/VirtualMotionTrackerDocument/image/trouble7.png)

## VMT is disabled in Steam VR. / VMTがSteam VRで無効にされている

![](/VirtualMotionTrackerDocument/image/trouble8_1.png)

### Open Steam VR settings. / Steam VRの設定を開く

![](/VirtualMotionTrackerDocument/image/trouble8_2.png)

### Open Manage ADD-ONS. / Manage ADD-ONS を開く

![](/VirtualMotionTrackerDocument/image/trouble8_3.png)

### Turn on "vmt" and restart SteamVR. / vmtをオンにして、SteamVRを再起動する

![](/VirtualMotionTrackerDocument/image/trouble8_4.png)

## SteamVR is in safe mode. / SteamVRがセーフモードになっている

![](/VirtualMotionTrackerDocument/image/trouble9_1.png)

### Click "Manage Add-ons". / Manage Add-onsをクリックする

![](/VirtualMotionTrackerDocument/image/trouble9_2.png)

### Click "UNBLOCK ALL" / UNBLOCK ALLをクリックする

![](/VirtualMotionTrackerDocument/image/trouble9_3.png)

### Restart SteamVR

![](/VirtualMotionTrackerDocument/image/trouble9_4.png)

## Not available on 32bit OS. / 32bit OSでは利用できません
Workaround: None  
対処法: なし

![](/VirtualMotionTrackerDocument/image/troubleA.png)
