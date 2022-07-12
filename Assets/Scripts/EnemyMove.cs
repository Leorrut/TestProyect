using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float speed = 3f;

    public int enemyType;
    public PathOfVision pathvision;
    public WayPoint waypoint;
    public Vector3 downObject;
    public Vector3 thisposition;
    public Transform waypointTarget;
    public int waypointNumber;
    public GameObject icon;
    public GameObject icon2;
    void Start()
    {

        pathvision = FindObjectOfType<PathOfVision>();
        waypoint = FindObjectOfType<WayPoint>();
        transform.LookAt(new Vector3(waypointTarget.position.x, transform.position.y, waypointTarget.position.z));
     
    }

    private void Update()
    {
        if(pathvision.detected ==true)
        {
            Vector3 playerPositionXZ = new Vector3(pathvision.player.position.x, transform.position.y, pathvision.player.position.z);
            enemyType = default;
            icon2.SetActive(true);
            switch (enemyType)
            {
                case 5:

                    break;
                case 4:
                  
                    break;
                case 3:

                    break;
                case 2:

                    break;
                case 1:
       
                    break;
                default:
                    
                    transform.LookAt(playerPositionXZ);
                    transform.position = Vector3.MoveTowards(transform.position, playerPositionXZ, pathvision.folowVelocity * Time.deltaTime);
                    break;
            }
        }
        else
        {
            switch (enemyType)
            {
                case 5:

                    break;
                case 4:
                    waypointNumber = 4;
                  //  transform.LookAt(downObject);
                    //transform.position = Vector3.MoveTowards(transform.position, downObject, pathvision.folowVelocity * Time.deltaTime);
                    break;
                case 3:

                    break;
                case 2:

                    break;
                case 1:
                    
                    break;
                default:
                    transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));

                    break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sound" && pathvision.detected == false)
        {
            enemyType = 4;

            icon.SetActive(true);
            
        }



        if (other.tag == "WayPoint" && pathvision.detected == false)
        {
           
            switch (waypointNumber)
            {
                case 4:
                    if (downObject.x<this.transform.position.x)
                    {
                        LeanTween.rotateY(this.gameObject, 90, 2);

                    }
                    else
                    {
                        LeanTween.rotateY(this.gameObject, -90, 2);
                    }
                   
                    break;
                case 3:
                    LeanTween.rotateY(this.gameObject, -90, 2);
                    break;
                case 2:

                    break;
                case 1:
                    LeanTween.rotateY(this.gameObject, -90, 2);
                    waypointNumber++;
                    StartCoroutine(MoveAgain());
                    speed = 0;
                    break;
                case 0:
                    LeanTween.rotateY(this.gameObject, 90, 2);
                    waypointNumber++;
                    speed = 0;
                    StartCoroutine(MoveAgain());
                    break;
            }

        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(waypointNumber ==2)
        {
            waypointNumber = 0;
        }
    }

    IEnumerator MoveAgain()
    {

        yield return new WaitForSeconds(2f);
       
        speed = 3f;
 
    }
}
