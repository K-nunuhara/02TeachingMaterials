using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Singleton
    public static InputManager instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            TimeManager.instance.changeGameSpeed(TimeManager.GameSpeedType.SLOW);
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            TimeManager.instance.changeGameSpeed(TimeManager.GameSpeedType.NORMAL);
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            TimeManager.instance.changeGameSpeed(TimeManager.GameSpeedType.FAST);
        }
    }
}
