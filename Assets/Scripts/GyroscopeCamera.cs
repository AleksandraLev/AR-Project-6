using UnityEngine;

public class GyroscopeCamera : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;
    private Quaternion initialRotation;

    void Start()
    {
        gyroEnabled = EnableGyro();
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            initialRotation = transform.rotation;
            return true;
        }
        return false;
    }

    void Update()
    {
        if (gyroEnabled)
        {
            transform.rotation = initialRotation * GyroToUnity(gyro.attitude);
        }
    }

    private Quaternion GyroToUnity(Quaternion q)
    {
        // Коррекция ориентации телефона: поворот на 90° по X
        Quaternion correction = Quaternion.Euler(90, 0, 0);

        // Преобразуем координаты в систему Unity
        Quaternion converted = new Quaternion(-q.x, -q.y, q.z, q.w);

        return correction * converted;
    }
}
