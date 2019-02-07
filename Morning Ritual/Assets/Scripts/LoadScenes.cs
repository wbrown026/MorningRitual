﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            StaticManager.easyWin = true;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            StaticManager.chaosMeter = 20;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(sceneName);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
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
