using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icons : MonoBehaviour
{
    
    void Start()
    {
        LeanTween.scale(gameObject, new Vector3(1f, 1f, 0.5f), 0.5f);

        LeanTween.scale(gameObject, new Vector3(0f, 0f, 0f),1f).setDelay(0.5f).setEase(LeanTweenType.easeInOutElastic);
        StartCoroutine(inactive());
    }


    void Update()
    {
        LeanTween.rotateY(this.gameObject, 0, 0);
     
    }
    IEnumerator inactive()
    {
        
        yield return new WaitForSeconds(2);
       
       this.gameObject.SetActive(false);
    }
}
