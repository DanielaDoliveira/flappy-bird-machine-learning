using UnityEngine;
using UnityEngine.SceneManagement;


public class Player
    {
        private Rigidbody2D jogadorRb { get; }
        private int forcaDoPulo { get; } = 10;
        private Animator playerAnimator{get; }

        public Player(Rigidbody2D jogadorRb, int forcaDoPulo, Animator playerAnimator)
        {
            this.jogadorRb = jogadorRb;
            this.forcaDoPulo = forcaDoPulo;
            this.playerAnimator = playerAnimator;
        }

        public void Control() => jogadorRb.AddForce(Vector2.up * forcaDoPulo, ForceMode2D.Impulse);

        public void Dead()
        {
          //  GerenciadorDeSons.instancia.TocarSomDano();
           // SceneManager.LoadScene("GameOver");
        }
    }
