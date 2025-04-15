using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*Ao adicionar o script no nosso player
 o comando RequireComponent
 já adiciona o componente Rigidbody2D no nosso objeto 
 automaticamente */
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public Rigidbody2D jogadorRb; 
    public int forcaDoPulo;   
    public Animator playerAnimator;
    public PointsSystem pointsSystem;
   
    void Start()
    {
        
    }
   

    
    public void ClickInput()
   {
       //Adiciona força à fisica do jogador 
       //Vector2.Up ->forçar para cima
       //Impulse -> o tipo de força. Queremos um impulso para cima
       //no slide falar sobre a força do pulo

       jogadorRb.AddForce(Vector2.up * forcaDoPulo, ForceMode2D.Impulse);
   }

   public void MorteDoPlayer()
   {
      GerenciadorDeSons.instancia.TocarSomDano();
       //Carrega a tela de Game Over
       SceneManager.LoadScene("GameOver");
   }

   public void OnCollisionEnter2D(Collision2D collision)
   {
       if (collision.gameObject.CompareTag("Obstáculo"))
       {
         
           if (pointsSystem.points > PlayerPrefs.GetInt("POINTS"))
           {
               PlayerPrefs.SetInt("POINTS", pointsSystem.points);
              
           }
           playerAnimator.Play("Dead");
       }
      
   }

   
}
