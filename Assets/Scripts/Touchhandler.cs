using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Touchhandler : MonoBehaviour
{
    [SerializeField]private GameObject ballPrefab;
    [SerializeField] private Rigidbody2D pivot;

    [SerializeField] private float detachDelay=0.5f;

   [SerializeField] private float respawnDelay=1.0f;
   private SpringJoint2D currentBallSpring;
   private Rigidbody2D currentBallRigidbody;
   
  
    // Start is called before the first frame update
    private Camera mainCamera;
    

    void Awake() {
      
    }
    void Start()
    {

      mainCamera=Camera.main;
      //  spawnBall();


    }

    // Update is called once per frame
    void Update()
    {
      
       
        // if not touched dont enter the update method
        if(!Touchscreen.current.primaryTouch.press.isPressed) 
        {
            return;
        }
        
        Vector2 touchPos=Touchscreen.current.primaryTouch.position.ReadValue();
       // Debug.Log(touchPos);
        //Convert the Screen point to World point as the ball resides in the world point
        Vector3 worldPosition= mainCamera.ScreenToWorldPoint(touchPos);
        // Assigning the world position to the currentBall position
        ballPrefab.transform.position=worldPosition;
      
        
       
        
        
    }
    private void launchBall()
    {
       // when ball is launced isKinematic is set to false 
       currentBallRigidbody.isKinematic=false;
      // there is a possibilities of touching the screen and hence the ball snaps to the touch , to avoid
      currentBallRigidbody=null;
      
      Invoke(nameof(detachBall),detachDelay);
    }
    private void detachBall()
    {
      currentBallSpring.enabled=false;
      currentBallSpring=null;
      Invoke(nameof(spawnBall), respawnDelay);
    }
    private void spawnBall()
    {
     
        GameObject ballInstance = Instantiate(ballPrefab,transform.position, Quaternion.identity);
        currentBallRigidbody=ballInstance.GetComponent<Rigidbody2D>();  
        /*currentBallSpring=ballInstance.GetComponent<SpringJoint2D>();
        currentBallSpring.connectedBody =pivot;*/
    }
    
}


//https://stackoverflow.com/questions/28469186/game-object-appears-in-scene-view-but-not-in-game-view