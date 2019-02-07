using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shower : MonoBehaviour
{
    public ParticleSystem steam;
    public ParticleSystem water;
    public Shake showerHead;
    public Transform handle;
    public float turnRate = 1f;
    public float maxValue = 1000f;
    public Slider thermometer;
    public Slider waterLevel;

    private float oldAngle;
    private float totalAngle = 0.0f;
    private bool settingTemp = true;
    private float waterTime;

    void Start()
    {
        oldAngle = handle.localEulerAngles.z;
        var waterEmission = water.emission;
        waterEmission.enabled = false;
        var steamEmission = steam.emission;
        steamEmission.enabled = false;
        if (StaticManager.day == 0)
        {
            waterTime = 1.0f;
        }
        else
        {
            waterTime = 5.0f * (StaticManager.day + 1);
        }

        if (StaticManager.day > 3)
        {
            thermometer.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (settingTemp)
        {
            // Get angle
            Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(handle.position);
            float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) + 180f;
            float angleDiff = angle - oldAngle;

            if (-totalAngle < 0.0f)
            {
                handle.localEulerAngles = new Vector3(handle.localEulerAngles.x, handle.localEulerAngles.y, 0.0f);
                totalAngle = 0.0f;
            }
            else if (-totalAngle > maxValue)
            {
                handle.localEulerAngles = new Vector3(handle.localEulerAngles.x, handle.localEulerAngles.y, -maxValue);
                totalAngle = -maxValue;
            }
            else
            {
                handle.localEulerAngles = new Vector3(handle.localEulerAngles.x, handle.localEulerAngles.y, totalAngle);
                if (angleDiff > 0.0)
                {
                    totalAngle += turnRate;
                }
                else if (angleDiff < 0.0)
                {
                    totalAngle -= turnRate;
                }
                oldAngle = angle;
            }

            float negAngle = -totalAngle;

            // Enable/Disable water
            var waterEmission = water.emission;
            if (-totalAngle < 50f)
            {
                waterEmission.enabled = false;
                showerHead.SetShake(false);
            }
            else
            {
                waterEmission.enabled = true;
                showerHead.SetShake(true);
            }

            // Steam emission;
            var steamEmission = steam.emission;
            if (-totalAngle < maxValue / 2)
            {
                steamEmission.enabled = false;
            }
            else
            {
                steamEmission.enabled = true;
                steamEmission.rateOverTime = negAngle.Remap((maxValue / 2), maxValue, 0.0f, 20f);
            }

            // Thermometer
            thermometer.value = negAngle.Remap(0.0f, maxValue, 0, 100);

            // Water Level
            waterLevel.value -= Time.deltaTime * waterTime;

            // Set Temp
            if (Input.GetMouseButtonDown(0) || waterLevel.value <= 0)
            {
                settingTemp = false;
            }

        }
        else
        {
            if (StaticManager.day == 0)
            {
                StaticManager.temperature = -totalAngle;
            }
            else
            {
                StaticManager.chaosMeter = Mathf.Abs(StaticManager.temperature - (-totalAngle)) / 100;
            }

            StartCoroutine(Wait(2.0f));
        }

        
    }

    IEnumerator Wait(float length)
    {
        yield return new WaitForSeconds(length);

        // Next Scene

    }
}
