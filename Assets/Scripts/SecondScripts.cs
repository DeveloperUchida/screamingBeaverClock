using System;
using UnityEngine;

public class SecondScripts : MonoBehaviour
{
    // Start is called before the first frame update
    /* void Start()
     {

     }
     */
    // Update is called once per frame
    void Update()
    {
        int s = DateTime.Now.Second;
        GetComponent<Transform>().localEulerAngles = new Vector3(0, 0, -360 / 60.0f * s);
    }
}
