using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{   
    [SerializeField]
    float speed = 5;

    [SerializeField]
    GameObject laserPrefab;

    float fireRate = 0.5f;

    float nextFire = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        Fire();
    }
    void CalculateMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, vertical, 0);
        transform.Translate(direction * Time.deltaTime * speed);
    }

    void Fire()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire){
            Instantiate(laserPrefab, transform.position+ new Vector3(0,0.6f,0), Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
