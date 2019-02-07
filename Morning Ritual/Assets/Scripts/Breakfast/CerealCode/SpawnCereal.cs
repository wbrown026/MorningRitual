using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnCereal : MonoBehaviour
{
    public GameObject MilkStuff;
    public GameObject cerealBox;
    public Sprite[] shapes;
    private int rand = 0;
    private int spawnTotal = 3;
    private int randSpawn = 0;
    private List<int> randSpawnList = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12});
    // Start is called before the first frame update
    void Start()
    {
        CreateCereal();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateCereal()
    {
        spawnTotal = StaticManager.day + 3;
        for (int i = 0; i < spawnTotal; i++)
        {
            randSpawn = randSpawnList[Random.Range(1, randSpawnList.Count-1)];
            if (GameObject.Find("SpawnPoints").transform.GetChild(randSpawn).childCount > 0)
            {
                randSpawnList.Remove(randSpawn);
            }
            GameObject cereal = Instantiate(cerealBox, GameObject.Find("SpawnPoints").transform.GetChild(randSpawn).transform.position, Quaternion.identity, GameObject.Find("SpawnPoints").transform.GetChild(randSpawn).transform);
            cereal.GetComponent<Image>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            cereal.GetComponent<Button>().onClick.AddListener(SelectCereal);
            int childCnt = cereal.transform.childCount;
            for (int k = 0; k < childCnt; k++)
            {
                rand = Random.Range(0, 3);
                GameObject child = cereal.transform.GetChild(k).gameObject;
                child.GetComponent<Image>().sprite = shapes[rand];
                child.GetComponent<Image>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

            }
        }

        if (StaticManager.day != 0)
        {
            randSpawn = randSpawnList[Random.Range(1, randSpawnList.Count)];
            GameObject correctBox = Instantiate(StaticManager.cereal, GameObject.Find("SpawnPoints").transform.GetChild(randSpawn).transform.position, Quaternion.identity, GameObject.Find("SpawnPoints").transform.GetChild(randSpawn).transform);
            correctBox.GetComponent<Button>().onClick.AddListener(SelectCereal);
            correctBox.transform.localScale = new Vector3(1, 1, 1);
        }

    }

    public void SelectCereal()
    {
        GameObject clickedCereal = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        Debug.Log(clickedCereal);
        //Instantiate(clickedCereal, GameObject.Find("Chosen").transform.position, Quaternion.identity, GameObject.Find("Chosen").transform);
        if (StaticManager.day == 0)
        {
            //StaticManager.day += 1;
            StaticManager.cereal = clickedCereal;
            StaticManager.cereal.transform.parent = null;
            StaticManager.cereal.tag = "Correct";
            DontDestroyOnLoad(StaticManager.cereal);
            GameObject.Find("CerealStuff").SetActive(false);
            MilkStuff.SetActive(true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log(StaticManager.cereal);
        }
        else if(clickedCereal.tag == "Correct")
        {
            //Next scene okay
            Debug.Log("CORRECT");
            //StaticManager.day += 1;
            StaticManager.chaosMeter += 10f;
            GameObject.Find("CerealStuff").SetActive(false);
            MilkStuff.SetActive(true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            //Next scene loss
            //StaticManager.day += 1;
            StaticManager.chaosMeter -= 10f;
            GameObject.Find("CerealStuff").SetActive(false);
            MilkStuff.SetActive(true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


}
