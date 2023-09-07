using System;
using UnityEngine;


public class HourScripts : MonoBehaviour
{
    // Start is called before the first frame update
    /*void Start()
    {

    }
*/
    // Update is called once per frame
    void Update()
    {
        int m = DateTime.Now.Minute;
        int h = DateTime.Now.Hour;
        float HHA = -((360 / 12.0f * h) + (30 / 60.0f * m));
        GetComponent<Transform>().localEulerAngles = new Vector3(0, 0, HHA); 
    }
}
