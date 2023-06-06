using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManage : MonoBehaviour
{
    public GameObject levelFinish;
    public GameObject trofeo;
    // Start is called before the first frame update
    void Start()
    {
        trofeo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 1)
        {
            trofeo.SetActive(true);
            
        }
    }
}
