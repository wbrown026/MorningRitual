using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flash : MonoBehaviour
{
    public float upTime = .5f;
    public float downTime = .5f;

    private string words;
    private float count;
    private bool up = true;
    private Text text;

    private void Start()
    {
        count = upTime;
        text = GetComponent<Text>();
        words = text.text;
    }

    void Update()
    {
        if (count <= 0.0f)
        {
            up = !up;

            if (up)
            {
                text.text = words;
                count = upTime;
            }
            else
            {
                text.text = "";
                count = downTime;
            }
        }

        count -= Time.deltaTime;
    }
}
