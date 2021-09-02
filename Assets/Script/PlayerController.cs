using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private SpriteRenderer _renderer;
    private Animator _animator;
    private Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        setRunAnimation();
        _rigidbody.velocity = new Vector2(10,_rigidbody.velocity.y);
        
        
        
        if (Input.GetKeyDown(KeyCode.UpArrow)  || Input.GetKeyDown(KeyCode.Space) )
        {
            var upSpeed = 30f;
            _rigidbody.velocity = Vector2.up * upSpeed;

            setJumpAnimation();
            
        }
        
        
        if (Input.GetKey(KeyCode.DownArrow) )
        {
            _rigidbody.velocity = new Vector2(10,_rigidbody.velocity.y);
            setSlideAnimation();
            
        }
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" )
        {
            Destroy(collision.gameObject);
        }
    }

    
    private void setIdleAnimation(){
        _animator.SetInteger("Estado",0);
    }
    
    private void setRunAnimation(){
        _animator.SetInteger("Estado",1);
    }
    
    private void setJumpAnimation(){
        _animator.SetInteger("Estado",2);
    }
    
    private void setSlideAnimation(){
        _animator.SetInteger("Estado",3);
    }
    
}
