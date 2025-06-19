using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsSystem
{
    public int points { get; set; } = 0;
    private TextMeshProUGUI pointsText { get; }

    public PointsSystem(TextMeshProUGUI pointsText, int points)
    {
        this.pointsText = pointsText;
        this.points = points;
    }


    public void MakePoints()
    {
        GerenciadorDeSons.instancia.TocarSomPontos();
        points++;
        pointsText.text = points.ToString();
    }
    
}
