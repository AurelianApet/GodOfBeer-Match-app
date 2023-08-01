using System;
using System.Collections;
using System.Net.Sockets;
using System.Net;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using SimpleJSON;

public class splash : MonoBehaviour
{
    // Start is called before the first frame update
    public float delay_time = 0.5f;

    IEnumerator Start()
    {
        //Screen.fullScreen = false;
        yield return new WaitForSeconds(delay_time);
        SceneManager.LoadScene("main");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
