using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class Wheel : MonoBehaviour
{
    public GameObject controlSphere = null;
    public GameObject addition = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        List<InputDevice> m_device = new List<InputDevice> ();
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Right, m_device);
        if (m_device.Count == 1)
        {
            CheckController(m_device[0]);
        }
        else
        {

        }
    }

    private void CheckController(InputDevice d)
    {
        bool primaryButtonDown = false;
        Vector2 joystickRotation = Vector2.zero;

        float rotateVertical;
        float rotateHorizontal;

        d.TryGetFeatureValue(CommonUsages.primary2DAxisTouch,out primaryButtonDown);
        d.TryGetFeatureValue(CommonUsages.primary2DAxis, out joystickRotation);

        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (primaryButtonDown && sceneIndex != 1 && sceneIndex != 2)
        {
            controlSphere.SetActive(true);
            addition.SetActive(true);

            rotateVertical = joystickRotation.y * 2f;
            rotateHorizontal = joystickRotation.x * 2f;
            controlSphere.transform.Rotate(rotateVertical, 0, rotateHorizontal);
        }
        else
        {
            controlSphere.SetActive(false);
            addition.SetActive(false);
        }
    }

}
