using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float strafeforce;
    public float jumpforce;
    public Rigidbody hips;
    public bool isGrounded;
    public ParticleSystem jumpEfect;
    public Joystick joy;
    private float referencex;
    private float referencez;

    void Start()
    {
        hips = GetComponent<Rigidbody>();
        joy = Joystick.FindObjectOfType<DynamicJoystick> ();
    }

   
    void FixedUpdate()
    {
        Vector3 directions = Vector3.forward * joy.Vertical + Vector3.right * joy.Horizontal;
   

         hips.AddForce(directions * speed * Time.deltaTime, ForceMode.Impulse);


        if (isGrounded)
            {
            referencex = transform.position.x;
            referencez = transform.position.z;
            if(referencex != directions.x && referencez != directions.y)
            {
                StartCoroutine(jumpTIme(0.05f));
            }    
      
            }




    }


    IEnumerator jumpTIme(float time)
    {
        yield return new WaitForSeconds(time);
        hips.AddForce(new Vector3(0, jumpforce, 0));

        isGrounded = false;
        jumpEfect.Play();
    }
}
