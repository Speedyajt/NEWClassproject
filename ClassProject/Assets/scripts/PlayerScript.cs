using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed = 75f;
    public float jumpForce;
    public Rigidbody rig;
    public int health;

    public Animator anim;

    public int coinCount;
   void Move() 
    {
        //get the input axis
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 rotation = Vector3.up * x;
       
        //calculate a direction relative to where we are facing
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        Vector3 dir = (transform.forward * z + transform.right * x) * moveSpeed;
        dir.y = rig.velocity.y;

        //set that as our velocity
        rig.velocity = dir;
       // rig.MoveRotation(rig.rotation * angleRot);
       if(Mathf.Abs(x) > 0.1f || Mathf.Abs(z) > 0.1f)
        {
            anim.SetBool("isRunning", true);
        }
       else
        {
            anim.SetBool("isRunning", false);
        }
    }
    void TryJump()
    {

        Ray ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, 1.5f)) { 
            anim.SetTrigger("isJumping");
             rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //input for jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryJump();
        }

        if(health <= 0)
        {
            StartCoroutine("Die");
        }
    
    }
    IEnumerator Die()
    {
        anim.SetBool("die", true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Enemy")
        {
            health -= 5;
        }

        if(other.gameObject.name == "FallCollider")
        {
            SceneManager.LoadScene(0);
        }
    }
}

