﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWork : MonoBehaviour {

    private Transform target;
    
    void Start()
    {        
        target = GameObject.Find("Player").transform;
    }
    
    void Update()
    {        
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
    }
}
