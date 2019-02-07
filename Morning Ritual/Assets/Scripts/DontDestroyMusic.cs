using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyMusic : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject[] songs = GameObject.FindGameObjectsWithTag("Music");
        if (songs.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name.Contains("Bad"))
        {
            gameObject.GetComponent<AudioSource>().pitch = .2f;
        }
        else
        {
            gameObject.GetComponent<AudioSource>().pitch = 1f;
        }
    }
}
