using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;

    private bool didIJump;
    private float horizontal;
    private Rigidbody rbdcomp;

    //private bool onGround;

    // Start is called before the first frame update
    void Start()
    {
        rbdcomp = GetComponent <Rigidbody> ();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))   
        {
            didIJump = true;
        }
        horizontal = Input.GetAxis("Horizontal");

    }

    private void FixedUpdate()
    {
        rbdcomp.velocity = new Vector3(horizontal, rbdcomp.velocity.y, 0);

        if(Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }

        if (didIJump)
        {
            Debug.Log("Space was pressed");
            rbdcomp.AddForce(Vector3.up * 6, ForceMode.VelocityChange);
            didIJump= false;
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
            Meows.instance.AddMeow(); 
        }
    }

}
