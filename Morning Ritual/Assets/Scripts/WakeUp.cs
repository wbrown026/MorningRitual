using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WakeUp : MonoBehaviour
{
    public Text text;
    public SpriteRenderer sky;
    public GameObject warning;
    public GameObject sun;
    public GameObject moon;

    private float time = 0.0f;
    private float step;
    private bool gettingDark = false;
    private float alphaStep = .09090909f;
    private Vector3 startSunMoonPos;
    private float SunMoonStep = 1.375f;
    private bool stoppped = false;

    void Start()
    {
        if (StaticManager.day == 0)
        {
            step = 1.0f;
        }

        startSunMoonPos = sun.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stoppped = true;
        }

        if (!stoppped)
        {
            int intPart = (int)time;
            int decPart = (int)((time - intPart) * 100);

            if (decPart > 60)
            {
                intPart++;
                time = (float)intPart + (float)(decPart / 100);
                if (gettingDark)
                {
                    sky.color = new Color(sky.color.r, sky.color.g, sky.color.b, sky.color.a - alphaStep);
                    moon.transform.Translate(new Vector3(0, SunMoonStep, 0));
                }
                else
                {
                    sky.color = new Color(sky.color.r, sky.color.g, sky.color.b, sky.color.a + alphaStep);
                    sun.transform.Translate(new Vector3(0, SunMoonStep, 0));
                }
            }
            if (intPart > 23)
            {
                intPart = 0;
                time = (float)intPart + (float)(decPart / 100);
                gettingDark = false;
                sun.transform.position = startSunMoonPos;
                moon.transform.position = startSunMoonPos;
            }
            if (intPart > 11)
            {
                gettingDark = true;
            }

            text.text = intPart.ToString("00") + ":" + decPart.ToString("00");

            time += Time.deltaTime * step;
        }
        else
        {
            StaticManager.time = time;
            Destroy(warning);

            // Next scene
        }
    }
}
