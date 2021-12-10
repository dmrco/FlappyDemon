using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    public GameObject replay;
    public GameObject player;

    void Start(){
        replay = GameObject.Find("Canvas").transform.GetChild(1).gameObject;
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player")){
            replay.SetActive(true);
            Destroy(player);
        }
    }
}
