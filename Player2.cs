using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2f;
    public float moveSpeed;
    private Vector3 moveDirection;
    public float turnSpeed;
    // boosting
     public float boostTime = 1.0f;
     public float currentBoostTime;
     public float boostDelayTime = 5.0f;
     public float currentBoostDelayTime;
     public bool boosting = false;
     public float time;
     public float baseSpeed = 1.0f;
     public float speedBoost = 2.0f;
     public float speed2;
     public Enemy enemy;
     public int health;
     public GameObject initObj;
    
     
    void Start()
    {
        PlayerPrefs.SetInt("strenght",10);
        health =  100;
        enemy = GameObject.Find("enemy").GetComponent<Enemy>();
       
        moveDirection = Vector3.right; 
        currentBoostTime = 0f;
         currentBoostDelayTime = 0f;
         speed2 = baseSpeed;

    }
 void movePlayer()
     {
         if (Input.GetKeyDown(KeyCode.Q) && !boosting && Time.time > currentBoostDelayTime) { //or whatever your boost button is
             currentBoostTime = Time.time + boostTime; //start the timer for the boost
             boosting = true;
             moveSpeed=10;
         }
 
         if ((Time.time > currentBoostTime) && boosting) { // am i boosting? has the boost timer expired?
             boosting = false;
             currentBoostDelayTime = Time.time + boostDelayTime;
             moveSpeed=5;
         }
 
         if (boosting) {
             speed2 = speedBoost;
 
         }
             
         if (!boosting) {
             speed2 = baseSpeed;
 
         }
     }
 
    // Update is called once per frame
    void Update()
    
    {
        time = Time.time; //debug
         movePlayer ();
        Event e = Event.current;
        

if(Input.GetKeyDown(KeyCode.S)){
    PlayerPrefs.SetInt("strenght",20);
    int ps = PlayerPrefs.GetInt("strenght");
    Debug.Log("Strength is set to "+ps);
}
Vector3 currentPosition = transform.position;
if (hola==1 && enemy.health >=0)
{
 Debug.Log("holamalluanderagaya");
                //if(Input.GetKeyDown(KeyCode.G)){
                    Debug.Log("mar gaya maderchod");
                Debug.Log(enemy.health);
                enemy.health=enemy.health-10;

                  
    }
//if(enemy.health<=0)
//Destroy(gameObject);
if(Input.GetKeyDown(KeyCode.C)){
  
    Instantiate(initObj,transform.position,transform.rotation);
}
if(Input.GetButton("Fire1") ) {
  
  Vector3 moveToward = Camera.main.ScreenToWorldPoint( Input.mousePosition );
 
  moveSpeed=5;
  moveDirection = moveToward - currentPosition;
  moveDirection.z = 0; 
  moveDirection.Normalize();
}
  else if(!Input.GetButton("Fire1") && boosting == false){
      moveSpeed=0;
  }
// if (Input.GetKey(KeyCode.Space))
//         {
            
//             moveSpeed=30;
           
//             }
           
//              if (Input.GetKeyUp(KeyCode.Space))
//         {
//             moveSpeed=5;
            
//         }
        
Vector3 target = moveDirection * moveSpeed + currentPosition;
transform.position = Vector3.Lerp( currentPosition, target, Time.deltaTime );

  float targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
transform.rotation = 
  Quaternion.Slerp( transform.rotation, 
                    Quaternion.Euler( 0, 0, targetAngle ), 
                    turnSpeed * Time.deltaTime );

        // if (Input.GetKey(KeyCode.LeftArrow))
        // {
        //     transform.Translate(-speed,0,0);
        // }else if(Input.GetKey(KeyCode.RightArrow)){
        //     transform.Translate(speed,0,0);
        // }
        // else if(Input.GetKey(KeyCode.DownArrow)){
        //     transform.Translate(0,-speed,0);
        // }
        // else if(Input.GetKey(KeyCode.UpArrow)){
        //     transform.Translate(0,speed,0);
        // }
        
    if(health<=0){
        Destroy(this.gameObject);
    }

    }
int hola = 0;

    void OnTriggerEnter2D(Collider2D col){
       // Debug.Log("holamallu");
            if(col.gameObject.tag == "enemy"){
                health = health -5;
                Debug.Log(health);
                Debug.Log("holamalluanderagaya");
                if(Input.GetButton("Fire2")){
                    Debug.Log("triggered");
                    hola = 1;
                }
                if(enemy.health<=0){
                    Debug.Log("holamallukyunahimarra");
                    hola = 0;
                    Destroy(col.gameObject);
               }
            }
        }
    }
    // void OnCollisionEnter2D(Collision2D col){
            
    //     if(col.gameObject.tag == "enemy"){
    //          if(Input.GetKeyDown(KeyCode.G)){
    //                enemy.health = enemy.health-5;
    //             if(enemy.health<=0){
    //                 Debug.Log("holamallukyunahimarra");
    //                 hola = 0;
    //                 Destroy(col.gameObject);
    //            }
    //         }
    //     }
    // }
    


