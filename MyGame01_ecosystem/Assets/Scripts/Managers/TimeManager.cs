using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // Singleton
    public static TimeManager instance { get; private set; }

    public float[] gameSpeeds = { 0.5f, 1.0f, 2.0f };
    public int currentGameSpeed = 1;
    public enum GameSpeedType
    {
        SLOW = 0,
        NORMAL = 1,
        FAST = 2,
    }
    public int[] intervalA = { 3000, 1500, 750 };

    public float getCurrentGameSpeedValue()
    {
        return gameSpeeds[currentGameSpeed];
    }

    public string getCurrentGameSpeedName()
    {
        switch (currentGameSpeed)
        {
            case (int)GameSpeedType.SLOW:
                return GameSpeedType.SLOW.ToString();
            case (int)GameSpeedType.NORMAL:
                return GameSpeedType.NORMAL.ToString();
            case (int)GameSpeedType.FAST:
                return GameSpeedType.FAST.ToString();
        }
        return "[Warning] Something Wrong.";
    }

    public void changeGameSpeed(GameSpeedType type)
    {
        this.currentGameSpeed = (int)type;
        Time.timeScale = gameSpeeds[currentGameSpeed];
    }

    public int getCurrentGameSpeedIntervalA()
    {
        return this.intervalA[currentGameSpeed];
    }

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

    void Start()
    {
        changeGameSpeed(GameSpeedType.NORMAL);
    }
}
