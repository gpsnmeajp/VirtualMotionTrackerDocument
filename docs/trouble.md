# Trouble / トラブル

**64bit Windows 10環境でのみ動作します。**  
**Only works on 64bit Windows 10**  

**Steam VRがHMDを認識していない場合、利用できません。(HMD未接続、Oculus Link起動前など)**  
**It should not work when you are not connect HMD. (Ex. disconnected, not started Oculus Link)**  

VMT_005までにあった"起動しない"などのトラブルに関しては、VMT_006を使用するとエラーメッセージが表示されます。  
If you have trouble for VMT 005 such as not starting, use VMT 006 or after will shows error message.  

認識しないソフトがある場合、以下を確認してください。  

+ VMT_009以降を使用しているか
+ [SteamVRトラッカーロールの設定](howto.md)
+ [SteamVRバインディングの割当](binding.md)
+ C:\Program Files (x86)\Steam\config\steamvr.vrsettings からVMT周りの設定を削除してみる(必ずバックアップを取ってください)

Please check below if you meet software won't recognize VMT.  

+ Use after version of VMT_009
+ [SteamVR Tracker Role](note_en.md)
+ [SteamVR binding (Pose)](binding.md)
+ Try remove VMT setting on C:\Program Files (x86)\Steam\config\steamvr.vrsettings (You must backup before change it.)
