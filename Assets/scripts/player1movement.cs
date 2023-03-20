using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1movement : MonoBehaviour
{
    public float playermov;
    public float m_Thrust = 2f;
    Rigidbody2D m_Rigidbody;
    public float moveSpeed;
    public float jumpForce;

    public int jumpsAmount;
    int jumpsLeft;
    public Transform GroundCheck;
    public LayerMask GroundLayer;
    public bool isGrounded;
    public bool HitWall;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float hz = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right*hz*playermov*Time.deltaTime);  

        if (Input.GetButton("Jump") && isGrounded == true){
            m_Rigidbody.AddForce(transform.up * m_Thrust);
        }
        if (Input.GetButton("Horizontal") && HitWall == true){
            playermov = playermov*0.5f;
        }
    }
      public void CheckIfGrounded()
    {
            isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheck.GetComponent<CircleCollider2D>().radius, GroundLayer);
    }
      public void CheckIfHitWall()
    {
            HitWall = Physics2D.OverlapCircle(GroundCheck.position, GroundCheck.GetComponent<CircleCollider2D>().radius, GroundLayer);
    }
    
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "GroundLayer"){
            isGrounded=true;
            Debug.Log("Print: " + col);  
        }
    }
     void OnTriggerExit2D(Collider2D col)
    {
        isGrounded=false;

    }
    
    
    /*public void Jump()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckIfGrounded();
            if (jumpsLeft > 0)
            {
                m_Rigidbody.velocity = new Vector2(m_Rigidbody.velocity.x, jumpForce);
                jumpsLeft--;
            }
                               
        }
        
        
    }*/
}




/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1movement : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    public float m_Thrust = 4000f;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Jump"))
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            m_Rigidbody.AddForce(transform.up * m_Thrust);
        }
    }
}
*/