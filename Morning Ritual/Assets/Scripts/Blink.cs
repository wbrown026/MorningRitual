using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public float upTime = .5f;
    public float downTime = .5f;

    public GameObject good;
    private float count;
    private bool up = true;
    public GameObject bad;

    private void Start()
    {
        count = upTime;
    }

    void Update()
    {
        if (count <= 0.0f)
        {
            up = !up;

            if (up)
            {
                bad.SetActive(true);
                count = upTime;
            }
            else
            {
                bad.SetActive(false);
                count = downTime;
            }
        }

        count -= Time.deltaTime;
    }
}
