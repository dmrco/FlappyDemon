using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Controls : MonoBehaviour
{
    public float tap = 10;
    public Vector3 startPosition;
    public float speed = 1;

    Rigidbody2D rigidBody;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    private Sprite spriteUp;
    private Sprite spriteDown;
    private bool jumping;
    private float timer;


    private void Start(){
        rigidBody = GetComponent<Rigidbody2D>();
        if(PlayerPrefs.GetString("PlayerIcon") == "FlyingEye"){
            spriteRenderer.sprite = spriteArray[2];
            spriteUp = spriteArray[2];
            spriteDown = spriteArray[3];
            transform.localScale = new Vector3(-1,1,0);
        }
        else{
            spriteUp = spriteArray[0];
            spriteDown = spriteArray[1];
            transform.localScale = new Vector3(1,1,0);
        }
    }

    private void Update(){
        if(Input.GetMouseButtonDown(0)){
            rigidBody.velocity = Vector3.zero;
            rigidBody.AddForce(Vector2.up * tap, ForceMode2D.Force);
            spriteRenderer.sprite = spriteUp;
            jumping = true;
        }
        if (jumping){
            timer += Time.deltaTime;
            if(timer >= 1f){
                jumping = false;
                timer = 0;
                spriteRenderer.sprite = spriteDown;
            }
        }
    }

}
