using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    public void MilkChoice()
    {
        SceneManager.LoadScene("MilkLose");

    }

    public void CerealChoice()
    {
        GameObject.Find("MilkOrCereal").SetActive(false);
        GetComponent<SpawnCereal>().enabled = true;
        CerealStuff.SetActive(true);
    }
}
