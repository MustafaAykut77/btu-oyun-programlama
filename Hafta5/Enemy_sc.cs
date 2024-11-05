using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_sc : MonoBehaviour
{
    [SerializeField]
    float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        float randomX = Random.Range(-9.4f, 9.4f);
        float randomY = Random.Range(8f, 10f);
        transform.position = new Vector3(randomX,randomY,0);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateEnemyMovement();
    }

    void CalculateEnemyMovement(){
        if(transform.position.y <= -5.38f){
            float randomX = Random.Range(-9.4f, 9.4f);
            float randomY = Random.Range(8f, 10f);
            transform.position = new Vector3(randomX,randomY,0);
        }
        else{
            transform.Translate(new Vector3(0,-1,0) * Time.deltaTime * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            Player_sc player_sc = other.transform.GetComponent<Player_sc>();
            player_sc.Damage();
            Destroy(this.gameObject);
        }
        else if(other.tag == "Laser"){
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
