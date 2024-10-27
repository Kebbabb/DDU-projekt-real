using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ddestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public static ddestroy instance;


    void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist between scenes
        }
      

    }
}
