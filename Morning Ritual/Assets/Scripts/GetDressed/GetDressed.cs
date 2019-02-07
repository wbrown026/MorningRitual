using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetDressed : MonoBehaviour
{

    public GameObject drawer;
    [Range(1.0f, 1.5f)]
    public float shirtSize = 1.5f;
    public List<GameObject> days;

    private GameObject currentShirt;

    void Start()
    {
        days[StaticManager.day].SetActive(true);
    }

    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && currentShirt != null)
        {
            Color color = currentShirt.GetComponent<SpriteRenderer>().color;
            if (StaticManager.day == 0)
            {
                StaticManager.shirtColor = color;
                Debug.Log(StaticManager.shirtColor);
            }
            else
            {
                if (StaticManager.shirtColor != color)
                {
                    StaticManager.chaosMeter -= (color.r + color.g + color.b) * 10f;
                }
            }

            Animator anim = drawer.GetComponent<Animator>();
            anim.Play("DrawerClose");
            StartCoroutine(Wait(2.0f));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Shirt")
        {
            collision.transform.localScale *= shirtSize;
            collision.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, -2.0f);
            currentShirt = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Shirt")
        {
            collision.transform.localScale /= shirtSize;
            collision.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, -1.0f);
            currentShirt = null;
        }
    }

    IEnumerator Wait(float length)
    {
        yield return new WaitForSeconds(length);
        Debug.Log(StaticManager.day);
        if (StaticManager.day == 6)
        {
            SceneManager.LoadScene("YouWin");
        }
        else if (StaticManager.easyWin)
        {
            StaticManager.day = 5;
            StaticManager.easyWin = false;
        }
        // Next Scene
        if (StaticManager.chaosMeter <= 25)
        {
            StaticManager.day += 1;
            SceneManager.LoadScene("BadWakeUp");
        }
        else
        {
            StaticManager.day += 1;
            SceneManager.LoadScene("WakeUp");
        }
    }
}
