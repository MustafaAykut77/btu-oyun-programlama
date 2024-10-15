using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
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
        transform.Translate(Time.deltaTime * new Vector3(0,1,0));

        if(transform.position.y >= 7){
            Destroy(this.gameObject);
        }
    }
}
