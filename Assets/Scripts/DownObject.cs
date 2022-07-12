using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownObject : MonoBehaviour
{
    public GameObject range;
    public bool colrange;
    public Transform thisPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Floor" )
        {
            if(colrange ==false)
            {
                range.SetActive(true);
                colrange = true;
                StartCoroutine(RangeVision());
                thisPosition = this.transform;
            }

        }

    }
    IEnumerator RangeVision()
    {
        
        yield return new WaitForSeconds(0.3f);
        range.SetActive(false);
    }
}
