using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class buttonAndAxis : MonoBehaviour
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

    float Trigger0 = 0;
    float Trigger1 = 0;

    float JoystickX = 0;
    float JoystickY = 0;
    private void OnGUI()
    {
        bool Button0 = GUI.RepeatButton(new Rect(0, 20 * 0, 100, 20), "System");
        client.Send("/VMT/Input/Button", (int)index, (int)0, (float)timeoffset, Button0 ? 1 : 0);

        bool Button1 = GUI.RepeatButton(new Rect(0, 20 * 1, 100, 20), "A");
        client.Send("/VMT/Input/Button", (int)index, (int)1, (float)timeoffset, Button1 ? 1 : 0);

        bool Button3 = GUI.RepeatButton(new Rect(0, 20 * 2, 100, 20), "B");
        client.Send("/VMT/Input/Button", (int)index, (int)3, (float)timeoffset, Button3 ? 1 : 0);

        GUI.Label(new Rect(0, 20 * 3, 100, 20), "Trigger");
        Trigger0 = GUI.HorizontalSlider(new Rect(0, 20 * 4, 100, 20), Trigger0, 0, 1);
        client.Send("/VMT/Input/Trigger", (int)index, (int)0, (float)timeoffset, (float)Trigger0);

        GUI.Label(new Rect(0, 20 * 5, 100, 20), "Grip");
        Trigger1 = GUI.HorizontalSlider(new Rect(0, 20 * 6, 100, 20), Trigger1, 0, 1);
        client.Send("/VMT/Input/Trigger", (int)index, (int)1, (float)timeoffset, (float)Trigger1);

        GUI.Label(new Rect(0, 20 * 7, 100, 20), "Trackpad");
        JoystickX = GUI.HorizontalSlider(new Rect(0, 20 * 8, 100, 20), JoystickX, 0, 1);
        JoystickY = GUI.HorizontalSlider(new Rect(0, 20 * 9, 100, 20), JoystickY, 0, 1);
        client.Send("/VMT/Input/Joystick", (int)index, (int)0, (float)timeoffset, (float)JoystickX, (float)JoystickY);

        bool JoystickTouch = GUI.RepeatButton(new Rect(0, 20 * 10, 100, 20), "Touch");
        client.Send("/VMT/Input/Joystick/Touch", (int)index, (int)0, (float)timeoffset, JoystickTouch ? 1 : 0);

    }

    void Update()
    {
        
    }
}
