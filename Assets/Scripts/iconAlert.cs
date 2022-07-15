using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iconAlert : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.moveY(gameObject, 5f, 0.6f).setEaseLinear().setLoopPingPong();
    }

    void OnTriggerEnter(Collider col)
    {


        if (col.tag == "Player")
        {

            LeanTween.scale(gameObject, new Vector3(0f, 0f, 0.0f), 0.5f);
        }
    }
}
