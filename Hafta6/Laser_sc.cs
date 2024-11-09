using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_sc : MonoBehaviour
{
    [SerializeField]
    float speed = 8.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        calculateDirection();
    }
    void calculateDirection(){
        transform.Translate(Time.deltaTime * new Vector3(0,1,0) * speed);

        if(transform.position.y >= 7){
            if(transform.parent != null){
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
