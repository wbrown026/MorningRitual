using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BrushMovement : MonoBehaviour
{
    public Image toothpaste;
    public Text showBrush;
    public float toothpasteSpeed;
    public GameObject counter;

    private Transform startPosition;
    private Transform endPosition;
    private bool goingRight = false;
    private bool goingLeft = true;
    private int count = 0;
    private float toothpasteTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        if (StaticManager.day == 0)
        {
            toothpasteTime = 1f;
        }
        startPosition = GameObject.Find("Start").transform;
        endPosition = GameObject.Find("End").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(StaticManager.day != 0)
        {
            counter.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
        Brush();
        ToothpasteBar();
        SceneChanging();
    }
    
    void Brush()
    {
        showBrush.text = count.ToString();
        //Debug.Log(Vector3.Distance(transform.position, startPosition.position));
        if(goingLeft)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition.position, 20f);
        }
        else if (goingRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition.position, 20f);
        }
        if(Input.GetKeyDown(KeyCode.A) && goingRight)/*&& Vector3.Distance(transform.position, endPosition.position) < 1f*/
        {
            goingLeft = true;
            goingRight = false;
            count += 1;
            Debug.Log(count);
        }
        else if (Input.GetKeyDown(KeyCode.D) && goingLeft) /*Vector3.Distance(transform.position, startPosition.position) < 1f)*/
        {
            Debug.Log("TEST");
            goingRight = true;
            goingLeft = false;
        }
    }

    void ToothpasteBar()
    {
        Debug.Log(StaticManager.numberOfBrushes);
        Debug.Log(StaticManager.day);
        //Debug.Log(toothpasteTime);
        toothpasteTime -= Time.deltaTime * toothpasteSpeed *(StaticManager.day+1);
        toothpaste.fillAmount = toothpasteTime;

    }

    void ChaosMeterChanging()
    {
        if(StaticManager.day != 0 && count == StaticManager.numberOfBrushes)
        {
            StaticManager.chaosMeter += StaticManager.numberOfBrushes;
            Debug.Log(StaticManager.chaosMeter);
        }
        if(StaticManager.day != 0 && count != StaticManager.numberOfBrushes)
        {
            Debug.Log(Mathf.Abs(StaticManager.numberOfBrushes - count));
            StaticManager.chaosMeter -= Mathf.Abs(StaticManager.numberOfBrushes - count);
        }


        if (StaticManager.chaosMeter >= 100)
        {
            StaticManager.chaosMeter = 100;
        }
    }

    void SceneChanging()
    {
        Debug.Log(StaticManager.chaosMeter);
        if (toothpasteTime <= 0 && StaticManager.chaosMeter <= 25)
        {
            ChaosMeterChanging();
            SceneManager.LoadScene("BadShower");
        }
        else if (toothpasteTime <= 0 && StaticManager.day == 0)
        {
            StaticManager.numberOfBrushes = count;
            //GetComponent<BrushMovement>().enabled = false;
            //Next scene
            SceneManager.LoadScene("Shower");
        }
        else if (toothpasteTime <= 0)
        {
            //Next Scene
            ChaosMeterChanging();
            SceneManager.LoadScene("Shower");
        }
    }
}
