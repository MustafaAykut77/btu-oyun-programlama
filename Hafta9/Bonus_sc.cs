using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bonus_sc : MonoBehaviour
{
    [SerializeField]
    float speed = 3.0f;

    [SerializeField]
    int bonusId;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,-1,0) * speed * Time.deltaTime);
        if(transform.position.y < -5.8f){
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            Player_sc player_sc = other.transform.GetComponent<Player_sc>();
            if(player_sc != null){
                switch(bonusId){
                    case 0:
                        player_sc.ActivateTripleShot();
                        break;
                    case 1:
                        player_sc.ActivateSpeedBonus();
                        break;
                    case 2:
                        player_sc.ActivateShieldBonus();
                        break;
                    default:
                        Debug.Log("Default value in switch case");
                        break;
                }
                
            }
            Destroy(this.gameObject);
        }
    }
}
