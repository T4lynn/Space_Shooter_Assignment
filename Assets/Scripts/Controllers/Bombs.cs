using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombs : MonoBehaviour
{
    public Transform EnemyTransform;
    public Transform PlayerTransform;
    public Transform BombTransform;
    float Thurst = 1f;
    Rigidbody2D BombRigid;
    void Start()
    {
        BombRigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        
    }
    void FixedUpdate()
    {
        StartCoroutine(FindEnemy());
    }
    IEnumerator FindEnemy()
    {
        Vector3 EnemyDirection = EnemyTransform.position - BombTransform.position;
        yield return new WaitForSeconds(0.5f);
        //Debug.Log("enemy position" + EnemyTransform.position);
        BombRigid.AddForce(EnemyDirection * Thurst);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
