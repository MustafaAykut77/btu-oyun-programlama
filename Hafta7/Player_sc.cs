using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_sc : MonoBehaviour
{   
    [SerializeField]
    float speed = 5;
    float speedMultiplier = 2;

    [SerializeField]
    GameObject laserPrefab;

    float fireRate = 0.5f;

    float nextFire = 0f;

    bool isTripleShotActive = false;
    bool isSpeedBonusActive = false;

    [SerializeField]
    GameObject tripleShotPrefab;

    SpawnManager_sc spawnManager_sc;

    [SerializeField]
    int health = 3;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0,0,0);
        spawnManager_sc = GameObject.Find("SpawnManager").GetComponent<SpawnManager_sc>();

        if(spawnManager_sc == null){
            Debug.Log("Spawn_Manager oyun nesnesi bulunamadi");
        }
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

        if(transform.position.y >= 0){
            transform.position = new Vector3(transform.position.x,0,0);
        }
        else if(transform.position.y <= -3.9f){
            transform.position = new Vector3(transform.position.x,-3.9f,0);
        }

        if(transform.position.x > 11.23f){
            transform.position = new Vector3(-11.23f, transform.position.y, 0);
        }
        else if(transform.position.x <= -11.23f){
            transform.position = new Vector3(11.23f, transform.position.y, 0);
        }
    }

    void Fire()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire){
            if(!isTripleShotActive){
                Instantiate(laserPrefab, transform.position+ new Vector3(0,0.5f,0), Quaternion.identity);
            }
            else{
                Instantiate(tripleShotPrefab, transform.position+ new Vector3(-0.73f,0,0), Quaternion.identity);
            }
            nextFire = Time.time + fireRate;
        }
    }

    public void Damage(){
        health--;
        if(health < 1){
            if(spawnManager_sc != null){
                spawnManager_sc.OnPlayerDeath();
            }
            Destroy(this.gameObject);
        }
    }

    public void ActivateTripleShot(){
        isTripleShotActive = true;
        StartCoroutine(TripleShotBonusDisableRoutine());
    }

    public void ActivateSpeedBonus(){
        isSpeedBonusActive = true;
        speed *= speedMultiplier;
        StartCoroutine(SpeedBonusDisableRoutine());
    }

    IEnumerator TripleShotBonusDisableRoutine(){
        yield return new WaitForSeconds(5.0f);
        isTripleShotActive = false;
    }

    IEnumerator SpeedBonusDisableRoutine(){
        yield return new WaitForSeconds(5.0f);
        isTripleShotActive = false;
        speed /= speedMultiplier;
    }
}
