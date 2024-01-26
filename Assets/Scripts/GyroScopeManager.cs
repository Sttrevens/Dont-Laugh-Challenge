using UnityEngine;

public class GyroscopeManager : MonoBehaviour
{
    public VideoManager videoManager;

    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
        else
        {
            Debug.LogError("Gyroscope not supported on this device.");
        }
    }

    void Update()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Quaternion gyroAttitude = Input.gyro.attitude;

            if (Mathf.Abs(gyroAttitude.x) < 0.1f)
            {
                OnDeviceLyingFlat();
            }
            else
            {
                BrowsingMode();
            }
        }
    }

    void OnDeviceLyingFlat()
    {
        Debug.Log("Device is lying flat on the table");
        videoManager.isOnTable = true;
    }

    void BrowsingMode()
    {
        Debug.Log("Device is in hand!");
        videoManager.isOnTable = false;
    }
}