---
title: Sample
description: サンプル
---

# Unity sample / Unityサンプル
[Samples source code](https://github.com/gpsnmeajp/VirtualMotionTrackerDocument/tree/main/sample)

Please install asset [hecomi/uOSC](https://github.com/hecomi/uOSC).  
[hecomi/uOSC](https://github.com/hecomi/uOSC)を導入してください。  

![](/VirtualMotionTrackerDocument/image/unity.png)

## [1_simple_tracker](https://github.com/gpsnmeajp/VirtualMotionTrackerDocument/tree/main/sample/1_simple_tracker/)
### [SimpleTracker.cs](https://github.com/gpsnmeajp/VirtualMotionTrackerDocument/tree/main/sample/1_simple_tracker/SimpleTracker.cs)
/VMT/Room/Unity  

### [SimpleTrackerFollow.cs](https://github.com/gpsnmeajp/VirtualMotionTrackerDocument/tree/main/sample/1_simple_tracker/SimpleTrackerFollow.cs)
/VMT/Follow/Unity  

### [SimpleTrackerJoint.cs](https://github.com/gpsnmeajp/VirtualMotionTrackerDocument/tree/main/sample/1_simple_tracker/SimpleTrackerJoint.cs)
/VMT/Joint/Unity  

### [SimpleTrackerRaw.cs](https://github.com/gpsnmeajp/VirtualMotionTrackerDocument/tree/main/sample/1_simple_tracker/SimpleTrackerRaw.cs)
/VMT/Raw/Unity  

## [2_button_and_axis](https://github.com/gpsnmeajp/VirtualMotionTrackerDocument/tree/main/sample/2_button_and_axis)
### [buttonAndAxis.cs](https://github.com/gpsnmeajp/VirtualMotionTrackerDocument/tree/main/sample/2_button_and_axis/buttonAndAxis.cs)

![](https://github.com/gpsnmeajp/VirtualMotionTrackerDocument/blob/main/sample/2_button_and_axis/inputtest.png?raw=true)

## [3_simple_finger](https://github.com/gpsnmeajp/VirtualMotionTrackerDocument/tree/main/sample/3_simple_finger)
### [SimpleFinger.cs](https://github.com/gpsnmeajp/VirtualMotionTrackerDocument/tree/main/sample/3_simple_finger/SimpleFinger.cs)
![](https://github.com/gpsnmeajp/VirtualMotionTrackerDocument/blob/main/sample/3_simple_finger/simple_finger.png?raw=true)


## [4_strict_finger](https://github.com/gpsnmeajp/VirtualMotionTrackerDocument/tree/main/sample/4_strict_finger)
### [GloveControllerSneder.cs](https://github.com/gpsnmeajp/VirtualMotionTrackerDocument/tree/main/sample/4_strict_finger/GloveControllerSneder.cs)
/VMT/Skeleton/Unity  
/VMT/Skeleton/Apply  
/VMT/Room/Unity  

Static Pose → Unity fbx (-x, y, z, -qx, qy, qz, -qw)  
Unity fbx → VMT(/VMT/Skeleton/Unity) (-x, y, -z, -qw, qy, -qz, qw)  

vr_glove_left_model_slim.fbx, vr_glove_right_model_slim.fbx

## [5_watch_hmd](https://github.com/gpsnmeajp/VirtualMotionTrackerDocument/tree/main/sample/5_watch_hmd/)
### [WatchHMD.cs](https://github.com/gpsnmeajp/VirtualMotionTrackerDocument/tree/main/sample/5_watch_hmd/WatchHMD.cs)
/VMT/Subscribe/Device  
/VMT/Out/SubscribedDevice  

![](https://github.com/gpsnmeajp/VirtualMotionTrackerDocument/blob/main/sample/5_watch_hmd/watch_hmd.png?raw=true)

# Developer tool / 開発ツール
## SkeletonPoseTester / 骨格姿勢テスター
You can check the posture of your hand.  
手の姿勢を確認できます。  

[https://github.com/gpsnmeajp/SkeletonPoseTester](https://github.com/gpsnmeajp/SkeletonPoseTester)

![](/VirtualMotionTrackerDocument/image/SkeletonPoseTester.png)

