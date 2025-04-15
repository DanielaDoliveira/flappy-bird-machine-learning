using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    //
    private Vector2 posicaoInicialDaImagem;
    public SpriteRenderer spriteRenderer;
    private float tamanhoDaImagem, tamanhoRealDaImagem;
    [SerializeField] private float speed;

    void Awake()
    {
        posicaoInicialDaImagem = transform.position; //captura a posição inicial da imagem quando é criada
        tamanhoDaImagem = spriteRenderer.size.x  * 3; // largura de uma imagem multiplicado por 4
        float escala = transform.localScale.x;  //pega o tamanho escalonado da imagem 
        tamanhoRealDaImagem = tamanhoDaImagem * escala;
    }

    // Update is called once per frame
    void Update()
    {
        float deslocamento = Mathf.Repeat(speed * Time.time, tamanhoDaImagem); //repete o deslocamento entre a posição inicial e a final (largura total da imagem).
        transform.position = posicaoInicialDaImagem + Vector2.left * deslocamento;// movimentação da imagem
    }
}

