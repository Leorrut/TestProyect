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
            //enemyMove.downObject = this.transform.position;
            //range.transform.gameObject.tag = "Sound";
            StartCoroutine(CollisionEnd());
            range.transform.position = new Vector3(0, 2, 0);
        }

    }

    IEnumerator CollisionEnd()
    {
        yield return new WaitForSeconds(1f);
        enemyMove.ObjectDown = gameObject.transform;
        range.transform.position = new Vector3(0, 10, 0);
        FloorEffect.Stop();
   


    }
}
