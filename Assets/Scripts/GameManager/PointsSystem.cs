using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsSystem : MonoBehaviour
{
   public int points;
    public TextMeshProUGUI pointsText;
   
    
    void Start()
    {
        points = 0;
    }

   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("POINT"))
        {
            GerenciadorDeSons.instancia.TocarSomPontos();
            points++;
            pointsText.text = points.ToString();
        }
    }
}
