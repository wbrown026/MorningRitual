using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrushMovement : MonoBehaviour
{
    public Image toothpaste;
    public Text showBrush;
    public float toothpasteSpeed;

    private Transform startPosition;
    private Transform endPosition;
    private bool goingRight = false;
    private bool goingLeft = false;
    private int count = 0;
    private float toothpasteTime = 100f;
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
        Brush();
        ToothpasteBar();
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
        if(Input.GetKeyDown(KeyCode.A) && Vector3.Distance(transform.position, endPosition.position) < 1f)
        {
            goingLeft = true;
            goingRight = false;
            count += 1;
            Debug.Log(count);
        }
        else if (Input.GetKeyDown(KeyCode.D) && Vector3.Distance(transform.position, startPosition.position) < 1f)
        {
            Debug.Log("TEST");
            goingRight = true;
            goingLeft = false;
        }
    }

    void ToothpasteBar()
    {
        Debug.Log(toothpasteTime);
        toothpasteTime -= Time.deltaTime * toothpasteSpeed;
        toothpaste.fillAmount = toothpasteTime;
        if (toothpasteTime <= 0)
        {
            StaticManager.numberOfBrushes = count;
            GetComponent<BrushMovement>().enabled = false;
            //Next scene
        }
    }
}
