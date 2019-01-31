using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCereal : MonoBehaviour
{
    public GameObject cerealBox;
    public Sprite[] shapes;
    private int rand = 0;
    private int spawnTotal = 3;
    private int randSpawn = 0;
    private List<int> randSpawnList = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 });
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
        for (int i = 0; i < spawnTotal; i++)
        {
            randSpawn = randSpawnList[Random.Range(0, randSpawnList.Count)];
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

    }

    public void SelectCereal()
    {
        GameObject clickedCereal = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        Instantiate(clickedCereal, GameObject.Find("Chosen").transform.position, Quaternion.identity, GameObject.Find("Chosen").transform);
        if (StaticManager.day == 0)
        {
            StaticManager.cereal = clickedCereal;
            Debug.Log(StaticManager.cereal);
        }

        if(clickedCereal == StaticManager.cereal)
        {
            //Next scene okay
        }
        else
        {
            //Next scene loss
            StaticManager.chaosMeter -= 10f;
        }
    }


}
