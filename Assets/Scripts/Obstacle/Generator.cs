using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Generator : MonoBehaviour
{
    public GameObject obstacle;
     int rand;
     public float tempoParaGerar = 2;
     [SerializeField]float posicaoInicialParaGerarObstaculo;
    public float[] altura;
    void Start()
    {
        if(posicaoInicialParaGerarObstaculo == 0){
            posicaoInicialParaGerarObstaculo = -6.92f;
            }
        altura= new float[3];   
        altura[0] = 6.49f;
        altura[1] = 4.44f;
        altura[2] = 2.82f;
       InvokeRepeating("Gerar", 0, tempoParaGerar);
    }

    // Update is called once per frame
   

    void Gerar()
    { 
        rand= (int)DateTime.Now.Ticks;
     rand = Random.Range(0,3);

    
         if (rand == 0)
         {
             Instantiate(obstacle, new Vector3(posicaoInicialParaGerarObstaculo, altura[0],0), Quaternion.identity);
         }
         else if (rand == 1)

         {
             Instantiate(obstacle, new Vector3(posicaoInicialParaGerarObstaculo, altura[1], 0), Quaternion.identity);
         }
         else if (rand == 2)
         {
             Instantiate(obstacle, new Vector3(posicaoInicialParaGerarObstaculo, altura[2], 0), Quaternion.identity);
         }

     
       
      
    }

   
 
 
}
