using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Cube_Sc : MonoBehaviour
{
    float speedPrivate = 3;

    public float speedPublic = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1,0,0) * Time.deltaTime * speedPrivate);
    }
}