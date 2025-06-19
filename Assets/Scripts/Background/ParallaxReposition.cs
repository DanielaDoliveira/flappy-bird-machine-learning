using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxReposition : MonoBehaviour
{
    private float _larguraDaImagem;

    void Start()
    {
        _larguraDaImagem = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        if (transform.position.x < Camera.main.transform.position.x - _larguraDaImagem)
        {
            transform.position += new Vector3(_larguraDaImagem * 2, 0, 0);
        }
    }
}