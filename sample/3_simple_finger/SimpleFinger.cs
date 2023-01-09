using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFinger : MonoBehaviour
{
    public int index = 1;
    const int ENABLE_CONTROLLER_L_COMPATIBLE = 5;

    const float timeoffset = 0f;

    uOSC.uOscClient client;
    void Start()
    {
        Application.targetFrameRate = 30;
        client = GetComponent<uOSC.uOscClient>();

        const int enable = ENABLE_CONTROLLER_L_COMPATIBLE;

        client.Send("/VMT/Joint/UEuler", (int)index, (int)enable, (float)timeoffset,
            -0.15f, 0f, 0.26f,
            -60f, 60f, 0f,"HMD"
        );
    }

    float Finger1 = 0;
    float Finger2 = 0;
    float Finger3 = 0;
    float Finger4 = 0;
    float Finger5 = 0;
    private void OnGUI()
    {
        GUI.Label(new Rect(0, 20 * 0, 100, 20), "Finger1");
        Finger1 = GUI.HorizontalSlider(new Rect(0, 20 * 1, 100, 20), Finger1, 1, 0);
        client.Send("/VMT/Input/Trigger", (int)index, (int)2, (float)timeoffset, (float)Finger1);
        client.Send("/VMT/Skeleton/Scalar", (int)index, (int)1, 1f - (float)Finger1, 0,0);

        GUI.Label(new Rect(0, 20 * 2, 100, 20), "Finger2");
        Finger2 = GUI.HorizontalSlider(new Rect(0, 20 * 3, 100, 20), Finger2, 0, 1);
        client.Send("/VMT/Input/Trigger", (int)index, (int)3, (float)timeoffset, (float)Finger2);
        client.Send("/VMT/Skeleton/Scalar", (int)index, (int)2, 1f - (float)Finger2, 0, 0);

        GUI.Label(new Rect(0, 20 * 4, 100, 20), "Finger3");
        Finger3 = GUI.HorizontalSlider(new Rect(0, 20 * 5, 100, 20), Finger3, 0, 1);
        client.Send("/VMT/Input/Trigger", (int)index, (int)4, (float)timeoffset, (float)Finger3);
        client.Send("/VMT/Skeleton/Scalar", (int)index, (int)3, 1f - (float)Finger3, 0, 0);

        GUI.Label(new Rect(0, 20 * 6, 100, 20), "Finger4");
        Finger4 = GUI.HorizontalSlider(new Rect(0, 20 * 7, 100, 20), Finger4, 0, 1);
        client.Send("/VMT/Input/Trigger", (int)index, (int)5, (float)timeoffset, (float)Finger4);
        client.Send("/VMT/Skeleton/Scalar", (int)index, (int)4, 1f - (float)Finger4, 0, 0);

        GUI.Label(new Rect(0, 20 * 8, 100, 20), "Finger5");
        Finger5 = GUI.HorizontalSlider(new Rect(0, 20 * 9, 100, 20), Finger5, 0, 1);
        client.Send("/VMT/Input/Trigger", (int)index, (int)6, (float)timeoffset, (float)Finger5);
        client.Send("/VMT/Skeleton/Scalar", (int)index, (int)5, 1f - (float)Finger5, 0, 0);

        client.Send("/VMT/Skeleton/Apply", (int)index, (float)timeoffset);

    }

    void Update()
    {

    }

}
