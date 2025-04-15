using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public int velocidade;
    public float timeToDestroy;
    
    void Update()
    {   
        transform.position +=  (Vector3.left * velocidade)* Time.deltaTime;
        Destroy(gameObject, timeToDestroy);
    }


    


}
