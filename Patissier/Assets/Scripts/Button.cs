using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine UI;

public class Button : MonoBehaviour
{
    public GameObject C1;
    // Start is called before the first frame update
    void Start()
    {
        C1.SetActive(false);
    }
    public void C1()
    {
        SceneManger.LoadScene("Scene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
