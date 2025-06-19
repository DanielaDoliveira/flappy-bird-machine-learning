
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
     private Rigidbody2D _jogadorRb; 
     public int forcaDoPulo;   
     private Animator _playerAnimator;

     [Header("Points Text (TMP):")]
     [SerializeField]private TextMeshProUGUI pointsText;
    private Player _player;
    private PointsSystem _pointsSystem;
    private int points = 0;

    private void Start()
    {
        _jogadorRb = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
        _pointsSystem = new PointsSystem(pointsText,points);
        _player = new Player(_jogadorRb, forcaDoPulo,_playerAnimator);
      
      
    }

    public void ClickInput() => _player.Control();
   

   public void MorteDoPlayer() => _player.Dead();
   

   public void OnCollisionEnter2D(Collision2D collision)
   {
       if (collision.gameObject.CompareTag("Obstáculo"))
       {
           if (_pointsSystem.points > PlayerPrefs.GetInt("POINTS"))
           {
               PlayerPrefs.SetInt("POINTS", _pointsSystem.points);
             
           }
          
           _playerAnimator.Play("Dead");
        
       }
      
   }
   private void OnTriggerEnter2D(Collider2D other)
   {
       if (other.gameObject.CompareTag("POINT"))
       {
        
           _pointsSystem.MakePoints();
       }
       
   }

   
}
