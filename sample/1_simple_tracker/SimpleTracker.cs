using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(uOSC.uOscClient))]
public class SimpleTracker : MonoBehaviour
{
    public Transform target;
    public int index = 0;

    const int DISABLE = 0;
    const int ENABLE_TRACKER = 1;
    const int ENABLE_CONTROLLER_L = 2;
    const int ENABLE_CONTROLLER_R = 3;
    const int ENABLE_TRACKING_REFERENCE = 4;
    const int ENABLE_CONTROLLER_L_COMPATIBLE = 5;
    const int ENABLE_CONTROLLER_R_COMPATIBLE = 6;
    const int ENABLE_TRACKER_COMPATIBLE = 7;

    uOSC.uOscClient client;
    void Start()
    {
        client = GetComponent<uOSC.uOscClient>();
    }

    void Update()
    {
        const int enable = ENABLE_TRACKER;
        const float timeoffset = 0f;

        client.Send("/VMT/Room/Unity", (int)index, (int)enable, (float)timeoffset,
            (float)target.transform.position.x,
            (float)target.transform.position.y,
            (float)target.transform.position.z,
            (float)target.transform.rotation.x,
            (float)target.transform.rotation.y,
            (float)target.transform.rotation.z,
            (float)target.transform.rotation.w
        );
    }
}