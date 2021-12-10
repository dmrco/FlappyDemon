using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    public float lifetime;
    private float timer;

    private void Update(){
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (timer >= lifetime){
            Destroy(gameObject);
        }
        else{
            timer += Time.deltaTime;
        }
    }
}
