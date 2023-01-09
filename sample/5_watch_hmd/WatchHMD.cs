using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(uOSC.uOscClient))]
[RequireComponent(typeof(uOSC.uOscServer))]
public class WatchHMD : MonoBehaviour
{
    public Transform target;

    uOSC.uOscClient client;
    uOSC.uOscServer server;
    void Start()
    {
        client = GetComponent<uOSC.uOscClient>();
        server = GetComponent<uOSC.uOscServer>();
        server.onDataReceived.AddListener(OnDataReceived);

        client.Send("/VMT/Subscribe/Device", "HMD");
    }

    public void OnDataReceived(uOSC.Message message)
    {
        if (message.address == "/VMT/Out/SubscribedDevice") {
            string srial = (string)message.values[0];
            float x = (float)message.values[1];
            float y = (float)message.values[2];
            float z = (float)message.values[3];
            float qx = (float)message.values[4];
            float qy = (float)message.values[5];
            float qz = (float)message.values[6];
            float qw = (float)message.values[7];

            target.position = new Vector3(x, y, -z);
            target.rotation = new Quaternion(qx, qy, -qz, -qw);
        }
    }

    void Update()
    {
    }
}