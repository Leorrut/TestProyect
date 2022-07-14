using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionPlayer : MonoBehaviour
{
    public Joystick joy;
    public GameObject canvas;
    public GameObject canvasMenu;
    public GameObject canvasMenuButton;
    public GameObject canvasFade;
    public GameObject player;
    public PlayerController PC;
    public GameObject camActive;
    public LevelManager levelmanger;
    private int actualLevel;
    private Animator transition;
    public PathOfVision enemy;
    public GameObject enemygame;

    void Start()
    {
        transition = GetComponentInChildren<Animator>();
        enemy = FindObjectOfType<PathOfVision>();
    }


    void OnTriggerEnter(Collider col)
    {
     
        if (col.tag == "Meta")
        {
            levelmanger = FindObjectOfType<LevelManager>();
            actualLevel = levelmanger.levelChange;
            levelmanger.levelChange++;

            switch (actualLevel)
            {
                case 4:
                   
                    break;
                case 3:
                   
                    break;
                case 2:
                  //  Debug.Log(actualLevel);
                   // canvas.SetActive(true);
                  //  Time.timeScale = 0;
                    break;
                case 1:
                    Debug.Log(actualLevel);
                   // StartCoroutine(FloorPlayerEnd(0.1f));
                    canvasFade.SetActive(true);
                    break;

                case 0:
                    Debug.Log(actualLevel);
                    
                    StartCoroutine(FloorPlayerEnd(0.1f));
                    joy.gameObject.SetActive(false);
                    canvasFade.SetActive(true);
                    transition.SetTrigger("Transition");
                    LeanTween.scale(canvasMenu,new Vector3(1.5f, 1.5f, 1.5f),2f).setDelay(.5f).setEase(LeanTweenType.easeInOutElastic);
                    break;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Wall")
        {

            Instantiate(player,transform.position, transform.rotation);
           
            Destroy(GetComponent<ConfigurableJoint>());
            StartCoroutine(FloorPlayerEnd(0.1f));
            
        }
        if (collision.gameObject.tag == "Enemy")
        {
            camActive.SetActive(false);
            Instantiate(player, transform.position, transform.rotation);
            canvasFade.SetActive(true);
            canvas.SetActive(true);
            Destroy(GetComponent<ConfigurableJoint>());
           
        }
    }

    IEnumerator FloorPlayerEnd(float time)
    {
        yield return new WaitForSeconds(1f);
        canvas.SetActive(true);
       // Debug.Log("perdiste");
  
       // Time.timeScale = 0;
        LeanTween.scale(canvasMenu, new Vector3(1f, 1f, 1f), 1f).setDelay(.2f).setEase(LeanTweenType.easeInOutElastic);
        LeanTween.scale(canvasMenuButton, new Vector3(1f, 1f, 1f), 1.5f).setDelay(.5f).setEase(LeanTweenType.easeInOutElastic);
 
        
        Object.Destroy(enemygame);
    }


    IEnumerator Meta()
    {

        yield return new WaitForSeconds(2f);
        
        transition.SetTrigger("Transition");
        SceneManager.LoadScene(0);

    }

}

