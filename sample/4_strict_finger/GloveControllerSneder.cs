using UnityEngine;

[RequireComponent(typeof(uOSC.uOscClient))]
public class GloveControllerSneder : MonoBehaviour
{
    public bool lefthand = true;

    public Transform Root;
    public Transform Wrist;
    public Transform Thumb0_ThumbProximal;
    public Transform Thumb1_ThumbIntermediate;
    public Transform Thumb2_ThumbDistal;
    public Transform Thumb3_ThumbEnd;
    public Transform IndexFinger0_IndexProximal;
    public Transform IndexFinger1_IndexIntermediate;
    public Transform IndexFinger2_IndexDistal;
    public Transform IndexFinger3_IndexDistal2;
    public Transform IndexFinger4_IndexEnd;
    public Transform MiddleFinger0_MiddleProximal;
    public Transform MiddleFinger1_MiddleIntermediate;
    public Transform MiddleFinger2_MiddleDistal;
    public Transform MiddleFinger3_MiddleDistal2;
    public Transform MiddleFinger4_MiddleEnd;
    public Transform RingFinger0_RingProximal;
    public Transform RingFinger1_RingIntermediate;
    public Transform RingFinger2_RingDistal;
    public Transform RingFinger3_RingDistal2;
    public Transform RingFinger4_RingEnd;
    public Transform PinkyFinger0_LittleProximal;
    public Transform PinkyFinger1_LittleIntermediate;
    public Transform PinkyFinger2_LittleDistal;
    public Transform PinkyFinger3_LittleDistal2;
    public Transform PinkyFinger4_LittleEnd;
    public Transform Aux_Thumb_ThumbHelper;
    public Transform Aux_IndexFinger_IndexHelper;
    public Transform Aux_MiddleFinger_MiddleHelper;
    public Transform Aux_RingFinger_RingHelper;
    public Transform Aux_PinkyFinger_LittleHelper;

    uOSC.uOscClient client;
    void Start()
    {
        client = GetComponent<uOSC.uOscClient>();
    }
    void SendBone(int i, Transform target) {
        client.Send("/VMT/Skeleton/Unity", lefthand?1:2, (int)i,
            -(float)target.transform.localPosition.x,
            (float)target.transform.localPosition.y,
            -(float)target.transform.localPosition.z,
            -(float)target.transform.localRotation.x,
            (float)target.transform.localRotation.y,
            -(float)target.transform.localRotation.z,
            (float)target.transform.localRotation.w
        );
    }
    public void Update()
    {
        int boneIndex = 0;
        SendBone(boneIndex, Root); boneIndex++;
        SendBone(boneIndex, Wrist); boneIndex++;
        SendBone(boneIndex, Thumb0_ThumbProximal); boneIndex++;
        SendBone(boneIndex, Thumb1_ThumbIntermediate); boneIndex++;
        SendBone(boneIndex, Thumb2_ThumbDistal); boneIndex++;
        SendBone(boneIndex, Thumb3_ThumbEnd); boneIndex++;
        SendBone(boneIndex, IndexFinger0_IndexProximal); boneIndex++;
        SendBone(boneIndex, IndexFinger1_IndexIntermediate); boneIndex++;
        SendBone(boneIndex, IndexFinger2_IndexDistal); boneIndex++;
        SendBone(boneIndex, IndexFinger3_IndexDistal2); boneIndex++;
        SendBone(boneIndex, IndexFinger4_IndexEnd); boneIndex++;
        SendBone(boneIndex, MiddleFinger0_MiddleProximal); boneIndex++;
        SendBone(boneIndex, MiddleFinger1_MiddleIntermediate); boneIndex++;
        SendBone(boneIndex, MiddleFinger2_MiddleDistal); boneIndex++;
        SendBone(boneIndex, MiddleFinger3_MiddleDistal2); boneIndex++;
        SendBone(boneIndex, MiddleFinger4_MiddleEnd); boneIndex++;
        SendBone(boneIndex, RingFinger0_RingProximal); boneIndex++;
        SendBone(boneIndex, RingFinger1_RingIntermediate); boneIndex++;
        SendBone(boneIndex, RingFinger2_RingDistal); boneIndex++;
        SendBone(boneIndex, RingFinger3_RingDistal2); boneIndex++;
        SendBone(boneIndex, RingFinger4_RingEnd); boneIndex++;
        SendBone(boneIndex, PinkyFinger0_LittleProximal); boneIndex++;
        SendBone(boneIndex, PinkyFinger1_LittleIntermediate); boneIndex++;
        SendBone(boneIndex, PinkyFinger2_LittleDistal); boneIndex++;
        SendBone(boneIndex, PinkyFinger3_LittleDistal2); boneIndex++;
        SendBone(boneIndex, PinkyFinger4_LittleEnd); boneIndex++;
        SendBone(boneIndex, Aux_Thumb_ThumbHelper); boneIndex++;
        SendBone(boneIndex, Aux_IndexFinger_IndexHelper); boneIndex++;
        SendBone(boneIndex, Aux_MiddleFinger_MiddleHelper); boneIndex++;
        SendBone(boneIndex, Aux_RingFinger_RingHelper); boneIndex++;
        SendBone(boneIndex, Aux_PinkyFinger_LittleHelper); boneIndex++;

        client.Send("/VMT/Skeleton/Apply", lefthand ? 1 : 2, (float)0);

        client.Send("/VMT/Room/Unity", lefthand ? 1 : 2, lefthand ? 5 : 6, (float)0,
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
