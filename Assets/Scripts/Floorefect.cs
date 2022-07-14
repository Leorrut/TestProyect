using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floorefect : MonoBehaviour
{
   
    private EnemyMove enemyMove;
    public ParticleSystem FloorEffect;

    void Start()
    {
        enemyMove = FindObjectOfType<EnemyMove>();
      
    }

    
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Floor")
        {
            enemyMove.ObjectDown = this.transform;
            FloorEffect.Play();
            transform.gameObject.tag = "Sound";
            enemyMove.alerta = true;
            transform.gameObject.tag = "Untagged";
        }
    }
}
