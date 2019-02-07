using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FillBowl : MonoBehaviour
{

    public GameObject pour;
    public Image bowl;
    public Image time;
    private float timeLimit = 1f;
    private float bowlTime;
    public float bowlSpeed;
    public GameObject help;
    public GameObject spilled;
    private bool spillCheck;
    public float timeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        help.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        TimeLimit();
        MoveMilk();
        SceneChanging();
    }

    void MoveMilk()
    {
        transform.position = Input.mousePosition;
        //Debug.Log(Vector3.Distance(transform.position, pour.transform.position));
        if (Vector3.Distance(transform.position, pour.transform.position) < 100)
        {
            help.SetActive(true);
            if (Input.GetMouseButton(0))
            {
                Quaternion newRotation = Quaternion.AngleAxis(90, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, .05f);
                Fill();

            }
            else
            {
                Quaternion newRotation = Quaternion.AngleAxis(90, Vector3.zero);
                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, .05f);
            }
        }
        else
        {
            help.SetActive(false);
            Quaternion newRotation = Quaternion.AngleAxis(90, Vector3.zero);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, .05f);
        }
    }
    void Fill()
    {
        bowlTime += Time.deltaTime * bowlSpeed * (StaticManager.day + 1);
        bowl.fillAmount = bowlTime;
        if(bowlTime >= 1 && !spillCheck)
        {
            spilled.SetActive(true);
            StaticManager.chaosMeter -= 10;
            spillCheck = true;
        }
    }

    void TimeLimit()
    {
        timeLimit -= Time.deltaTime * timeSpeed * (StaticManager.day + 1);
        time.fillAmount = timeLimit;
    }

    void ChaosMeterChanging()
    {
        if (StaticManager.day != 0 && bowlTime == StaticManager.milkLevel && bowlTime != 1)
        {
            StaticManager.chaosMeter += bowlTime*10;
            Debug.Log(StaticManager.chaosMeter);
        }
        if (StaticManager.day != 0 && bowlTime != StaticManager.milkLevel)
        {
            StaticManager.chaosMeter -= Mathf.Abs(StaticManager.milkLevel - bowlTime)*10;
        }


        if (StaticManager.chaosMeter >= 100)
        {
            StaticManager.chaosMeter = 100;
        }
    }

    void SceneChanging()
    {
        Debug.Log(StaticManager.chaosMeter);
        if (timeLimit <= 0 && StaticManager.chaosMeter <= 25)
        {
            ChaosMeterChanging();
            SceneManager.LoadScene("BadBrushTeeth");
        }
        else if (timeLimit <= 0 && StaticManager.day == 0)
        {
            StaticManager.milkLevel = bowlTime;
            //GetComponent<BrushMovement>().enabled = false;
            //Next scene

            SceneManager.LoadScene("BrushTeeth");
        }
        else if (timeLimit <= 0)
        {
            //Next Scene
            ChaosMeterChanging();
            SceneManager.LoadScene("BrushTeeth");
        }
    }
}
