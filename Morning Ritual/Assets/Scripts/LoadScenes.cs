using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadBreakfast()
    {
        SceneManager.LoadScene("Breakfast");
    }

    public void LoadBrush()
    {
        SceneManager.LoadScene("BrushTeeth");
    }

    public void LoadDress()
    {
        SceneManager.LoadScene("GetDressed");
    }

    public void LoadShower()
    {
        SceneManager.LoadScene("Shower");
    }

    public void LoadWake()
    {
        SceneManager.LoadScene("WakeUp");
    }
}
