using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject obstacle;
    public float timeBetween;
    private float timer;

    public float maxHeight;
    public float minHeight;

    private void Update(){
        if(timer <= 0){
            float rand = Random.Range(minHeight, maxHeight);
            Vector2 newPosition = new Vector2(transform.position.x, rand);
            Instantiate(obstacle, newPosition, Quaternion.identity);
            timer = timeBetween;
        }
        else{
            timer -= Time.deltaTime;
        }
    }   
}
