using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public float shakeDelay = .2f;
    public float duration;
    public float magnitude;

    private float count;
    private bool shake = false;

    void Start()
    {
        count = shakeDelay;
    }

    void Update()
    {
        if (count <= 0.0f)
        {
            count = shakeDelay;
            if (shake)
            {
                StartCoroutine(ShakeObject(duration, magnitude));
            }
        }

        count -= Time.deltaTime;
    }

    IEnumerator ShakeObject(float dur, float mag)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * mag;
            float y = Random.Range(-1f, 1f) * mag;

            transform.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }

    public void SetShake(bool value)
    {
        shake = value;
    }
}
