using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Cube_Sc : MonoBehaviour
{
    public float speedPublic = 5;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(1,0,0) * Time.deltaTime * speedPublic * vertical);

        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(0,1,0) * Time.deltaTime * speedPublic * horizontal);
    }
}
