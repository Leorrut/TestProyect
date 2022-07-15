using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class EnemyMove : MonoBehaviour
{
    private float speed = 3f;

    public int enemyType;
    public PathOfVision pathvision;
    public WayPoint waypoint;
    public Vector3 downObject;
    public GameObject rangeofvision;
    public Transform waypointTarget;
    public int waypointNumber;
    public GameObject icon;
    public GameObject icon2;
    public Transform ObjectDown;
    public bool alerta;
    void Start()
    {
        NavMeshAgent agente = GetComponent<NavMeshAgent>();
       // pathvision = FindObjectOfType<PathOfVision>();
        waypoint = FindObjectOfType<WayPoint>();
        transform.LookAt(new Vector3(waypointTarget.position.x, transform.position.y, waypointTarget.position.z));
     
    }

    private void Update()
    {
        if (pathvision.detected == true)
        {
            var colorRender = rangeofvision.GetComponent<Renderer>();

            colorRender.material.SetColor("_Color", Color.red);
            Vector3 playerPositionXZ = new Vector3(pathvision.player.position.x, transform.position.y, pathvision.player.position.z);
            enemyType = default;
            icon2.SetActive(true);

            NavMeshAgent agente = GetComponent<NavMeshAgent>();
            agente.destination = playerPositionXZ;
            transform.position = Vector3.MoveTowards(transform.position, playerPositionXZ, pathvision.folowVelocity * Time.deltaTime);
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

                    var rotacionInicial = transform.rotation;

                    transform.LookAt(ObjectDown);
                    var rotacionFinal = transform.rotation;
                    transform.rotation = rotacionInicial;
                    LeanTween.value(gameObject, (float value) =>
                    {
                        var rotacionYA = Quaternion.Slerp(rotacionInicial, rotacionFinal, value);
                        transform.rotation = rotacionYA;

                    }, 0f, 1f, 1f);
                    enemyType = 1;

                    NavMeshAgent agente = GetComponent<NavMeshAgent>();
                    agente.destination = downObject;
                    transform.position = Vector3.MoveTowards(transform.position, downObject, pathvision.folowVelocity * Time.deltaTime);
                    alerta = false;
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
        if (alerta == true)
        {
            //enemyType = 4;
            //icon.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sound" && pathvision.detected == false)
        {
            Debug.Log("alerta");
            enemyType = 4;

            icon.SetActive(true);
            
        }



        if (other.tag == "WayPoint" && pathvision.detected == false)
        {
           
            switch (waypointNumber)
            {
                case 4:
                    LeanTween.rotateY(this.gameObject, 180, 2);
                    waypointNumber++;
                    StartCoroutine(MoveAgain());
                    speed = 0;
                    break;
                case 3:
                    LeanTween.rotateY(this.gameObject, 0, 2);
                    waypointNumber++;
                    StartCoroutine(MoveAgain());
                    speed = 0;
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(EnemyPlayerEnd(0.1f));


        }
    }
    IEnumerator EnemyPlayerEnd(float time)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerExit(Collider other)
    {
        switch (waypointNumber)
        {
            case 5:
                waypointNumber = 3;
                break;
            case 4:
                
                break;
            case 3:

                break;
            case 2:
                waypointNumber = 0;
                break;
            case 1:

                break;
            case 0:

                break;
        }
    }

    IEnumerator MoveAgain()
    {

        yield return new WaitForSeconds(2f);
       
        speed = 3f;
 
    }
}
