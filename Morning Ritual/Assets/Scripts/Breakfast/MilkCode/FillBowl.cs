using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillBowl : MonoBehaviour
{

    public GameObject pour;
    public Image bowl;
    private float bowlTime;
    public float bowlSpeed;
    public GameObject help;

    // Start is called before the first frame update
    void Start()
    {
        help.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        MoveMilk();
    }

    void MoveMilk()
    {
        transform.position = Input.mousePosition;
        Debug.Log(Vector3.Distance(transform.position, pour.transform.position));
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
        bowlTime += Time.deltaTime * bowlSpeed;
        bowl.fillAmount = bowlTime;
    }
}
