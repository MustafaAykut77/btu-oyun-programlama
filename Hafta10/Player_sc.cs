using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_sc : MonoBehaviour
{
    [SerializeField]
    float speed = 5;
    float speedMultiplier = 2;

    [SerializeField]
    GameObject laserPrefab;

    [SerializeField]
    GameObject shieldVisualizer;

    [SerializeField]
    GameObject rightEngine, leftEngine;

    AudioSource audioSource;

    [SerializeField]
    AudioClip laserSoundClip;

    float fireRate = 0.5f;

    float nextFire = 0f;

    bool isTripleShotActive = false;
    bool isShieldActive = false;

    [SerializeField]
    GameObject tripleShotPrefab;

    SpawnManager_sc spawnManager_sc;
    UIManager_sc uiManager_sc;

    int score = 0;

    public int health = 3;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager_sc = GameObject.Find("SpawnManager").GetComponent<SpawnManager_sc>();
        uiManager_sc = GameObject.Find("Canvas").GetComponent<UIManager_sc>();
        audioSource = GetComponent<AudioSource>();

        if(spawnManager_sc == null){
            Debug.LogError("spawnManager_sc bulunamadi");
        }
        if(uiManager_sc == null){
            Debug.LogError("uiManager_sc bulunamadi");
        }
        if(audioSource == null)
        {
            Debug.LogError("Player_scc:Start audioSource is NULL");
        }
        else
        {
            audioSource.clip = laserSoundClip;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if(Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire ){
            if(!isTripleShotActive){
                Instantiate(laserPrefab, transform.position+ new Vector3(0,0.5f,0), Quaternion.identity);
            }
            else{
                Instantiate(tripleShotPrefab, transform.position+ new Vector3(-0.712f,-0.47f,0), Quaternion.identity);
            }
            audioSource.Play();
            nextFire = Time.time + fireRate;
        }
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

    public void Damage(){
        if(isShieldActive){
            isShieldActive = false;
            shieldVisualizer.SetActive(false);
            return;
        }
        health--;
        if(health == 2)
        {
            leftEngine.SetActive(true);
        }
        else if(health == 1)
        {
            rightEngine.SetActive(true);
        }
        if(uiManager_sc != null){
            uiManager_sc.UpdateLivesImg(health);
        }

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
        speed *= speedMultiplier;
        StartCoroutine(SpeedBonusDisableRoutine());
    }

    public void ActivateShieldBonus(){
        shieldVisualizer.SetActive(true);
        isShieldActive = true;
        StartCoroutine(ShieldBonusDisableRoutine());
    }

    IEnumerator TripleShotBonusDisableRoutine(){
        yield return new WaitForSeconds(5.0f);
        isTripleShotActive = false;
    }

    IEnumerator SpeedBonusDisableRoutine(){
        yield return new WaitForSeconds(5.0f);
        speed /= speedMultiplier;
    }

    IEnumerator ShieldBonusDisableRoutine(){
        yield return new WaitForSeconds(10.0f);
        shieldVisualizer.SetActive(false);
        isShieldActive = false;
    }

    public void UpdateScore(int points){
        score += points;
        if(uiManager_sc != null){
            uiManager_sc.UpdateScoreTMP(score);
        }
    }
}
