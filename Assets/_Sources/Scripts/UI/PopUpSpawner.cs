using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PopUpSpawner : MonoBehaviour
{

    public static PopUpSpawner Instance;


    [SerializeField] List<GameObject> readyPopUpList = new List<GameObject>();
    [SerializeField] private GameObject Pref;

    private void Awake()
    {
        Instance = this;
        if (Pref != null) readyPopUpList.Add(Pref);
    }

    public void ShowPopUp(Vector2 position, string text, PopUpType type)
    {
        GameObject readyObject = readyPopUpList.FirstOrDefault(p => !p.activeInHierarchy);

        if(readyObject == null)
        {
            readyObject = GameObject.Instantiate(Pref, transform);
            readyPopUpList.Add(readyObject);
        }

        readyObject.GetComponent<PopUp>().SetUp(position, text, type);
        readyObject.gameObject.SetActive(true);
    }

}

