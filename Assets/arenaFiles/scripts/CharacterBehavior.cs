using UnityEngine;
using System.Collections;
using UnitySampleAssets.CrossPlatformInput;

public class CharacterBehavior : MonoBehaviour {

    public float speed=6;
    public bool isWalking;
   
    public Vector3 velocity;
    public Vector3 move;
    public Rigidbody rgbody;
    public string horizontalAxis= "Horizontal";
    public string verticalAxis= "Vertical";

    public bool pushed = false;
    private Animator animator;
    public GameObject enemyPlayer;

    // Use this for initialization
    void Start() {
        animator = GetComponent<Animator>();
        rgbody = GetComponent<Rigidbody>();

        isWalking = false;
       
        animator.SetBool("_isWalking", isWalking);
        velocity = new Vector3(0, 0, 0);

        if (transform.tag == "Player1") enemyPlayer = GameObject.FindWithTag("Player2");
        else enemyPlayer = GameObject.FindWithTag("Player1");
    }


    // Update is called once per frame
    void Update() {

        //get the movement input on X and Z axis 
        float h = CrossPlatformInputManager.GetAxis(horizontalAxis);
        float v = CrossPlatformInputManager.GetAxis(verticalAxis);

        //if there is any input, mark that the character is walking
        if (h != 0 || v != 0)
            isWalking = true;
        //if there is no input, mark that the character is not walking
        else isWalking = false;

        // always move along the camera forward as it is the direction that it being aimed at
        move = v * Vector3.forward + h * Vector3.right;

        //communicate the movement to the rigidbody component on the character, through the velocity field
        rgbody.velocity = move * speed;

        //rotate the character so it's looking in the direction it's going.
        //by finding a point in front of his moving direction
        Vector3 lookAtPoint = new Vector3(h*9,0,v*9);
        transform.LookAt(lookAtPoint,Vector3.up);

        //update the animator on whether or not the character is moving;
        animator.SetBool("_isWalking", isWalking);


        //check if the push button was pressed
        /*   if (!pushed)
           {
               pushed = CrossPlatformInputManager.GetButtonDown("Push"+transform.tag);
           }
           else Push();*/

        if (transform.position.y < -0.3f)
        {
            transform.position =new Vector3(transform.position.x, -10f, transform.position.z);
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn() {
        yield return new WaitForSeconds(1);
        transform.position = new Vector3(2,0,0);
    }
    void Push()
    {
        
        if (enemyPlayer != null)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position,enemyPlayer.transform.position+Vector3.up, out hit))
            {
               
                print(hit.transform.tag);
            }
          
        }
       
        pushed = false;
    }

}

