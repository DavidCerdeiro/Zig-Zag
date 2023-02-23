using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fx : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("fx");
        if(musicObj.Length > 1) 
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}