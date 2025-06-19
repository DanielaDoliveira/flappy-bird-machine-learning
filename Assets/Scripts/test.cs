
using UnityEngine;

public class Test : MonoBehaviour
{
    private Rigidbody2D _player;
    void Start()=>_player = GetComponent<Rigidbody2D>();
    

  
    void Update()
    {
        _player.velocity = new Vector2(_player.velocity.x, _player.velocity.y);
    }
}
