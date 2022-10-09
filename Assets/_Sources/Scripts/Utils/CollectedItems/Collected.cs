using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collected : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        Invoke("Disable", 1f);       
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }

}
