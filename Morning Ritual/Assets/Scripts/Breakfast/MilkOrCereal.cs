using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkOrCereal : MonoBehaviour
{
    public GameObject CerealStuff;
    public GameObject MilkStuff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MilkChoice()
    {
        GameObject.Find("MilkOrCereal").SetActive(false);
        MilkStuff.SetActive(true);

    }

    public void CerealChoice()
    {
        GameObject.Find("MilkOrCereal").SetActive(false);
        GetComponent<SpawnCereal>().enabled = true;
        CerealStuff.SetActive(true);
    }
}
