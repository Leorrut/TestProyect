using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floorefect : MonoBehaviour
{
   
    private EnemyMove enemyMove;
    public ParticleSystem FloorEffect;
    public GameObject range;

    void Start()
    {
        enemyMove = FindObjectOfType<EnemyMove>();
      
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Floor")
        {
            FloorEffect.Play();
            //range.transform.gameObject.tag = "Sound";
            StartCoroutine(CollisionEnd());
            range.transform.position = new Vector3(0, 2, 0);
            enemyMove.ObjectDown = this.transform;
        }

    }

    IEnumerator CollisionEnd()
    {
        yield return new WaitForSeconds(0.3f);
        range.transform.position = new Vector3(0, 10, 0);
        
        FloorEffect.Stop();
        Debug.Log(enemyMove.ObjectDown);


    }
}
