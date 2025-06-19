using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class ParallaxTextureScroller : MonoBehaviour
{
    public float parallaxSpeed = 0.5f;  // Velocidade do parallax
    private float width;  // Largura do plano de fundo
    private float startPosition;

    void Start()
    {
        // Calcula a largura do objeto
        startPosition = transform.position.x;
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // Mover o objeto para simular o efeito parallax
        float moveAmount = Time.deltaTime * parallaxSpeed;
        transform.position = new Vector3(transform.position.x - moveAmount, transform.position.y, transform.position.z);

        // Quando o objeto passar do limite, ele retorna para a posição inicial
        if (transform.position.x < startPosition - width)
        {
            transform.position = new Vector3(startPosition, transform.position.y, transform.position.z);
        }
    }
}