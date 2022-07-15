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
    public GameObject star;
    public GameObject CanvasTextLevel;
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
        actualLevel = 0;
     
        if (col.tag == "Meta")
        {

            //Activar para subir el resto de niveles

          //  levelmanger = FindObjectOfType<LevelManager>();
          //  actualLevel = levelmanger.levelChange;
         //   levelmanger.levelChange++;

            switch (actualLevel)
            {
                case 4:
                   
                    break;
                case 3:
                   
                    break;
                case 2:

                    break;
                case 1:

                    canvasFade.SetActive(true);
                    break;

                case 0:
                    Debug.Log(actualLevel);
                   
                    StartCoroutine(FloorPlayerEnd(0.1f));
                    joy.gameObject.SetActive(false);
                    canvasFade.SetActive(true);
                    transition.SetTrigger("Transition");
                    LeanTween.scale(canvasMenu,new Vector3(1.5f, 1.5f, 1.5f),2f).setDelay(.5f).setEase(LeanTweenType.easeInOutElastic);
                    canvasFade.SetActive(true);
                    break;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

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
        yield return new WaitForSeconds(0.1f); 
        Object.Destroy(enemygame);
        canvas.SetActive(true);


        LeanTween.scale(canvasMenu, new Vector3(1f, 1f, 1f), 1f).setDelay(.2f).setEase(LeanTweenType.easeInOutElastic);
        LeanTween.scale(canvasMenuButton, new Vector3(1f, 1f, 1f), 1.5f).setDelay(.5f).setEase(LeanTweenType.easeInOutElastic);
        LeanTween.scale(CanvasTextLevel, new Vector3(2f, 2f, 2f), 1.0f).setDelay(.8f).setEase(LeanTweenType.easeInOutElastic);
        LeanTween.scale(star, new Vector3(0.2f, 0.2f, 0f), 1f).setDelay(.4f).setEase(LeanTweenType.easeInOutElastic);

    }


}

