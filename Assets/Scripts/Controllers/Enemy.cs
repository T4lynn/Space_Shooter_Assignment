using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    bool Direction = false;
    float EnemySpeed = 3;
    bool Coroutinerunning = false;
    private void Update()
    {
        Strafe();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Coroutinerunning)
        {
            StartCoroutine(EnemyWarp());
        }
    }

    IEnumerator EnemyWarp()
    {
        Coroutinerunning = true;
        Debug.Log("Coroutine started");
        float NewPositionX;
        float NewPositionY;
        NewPositionX = Random.Range(-10, 10);
        NewPositionY = Random.Range(-10, 10);
        Vector3 NewVectorPosition = new Vector3(NewPositionX, NewPositionY, 0);
        yield return new WaitForSeconds(1);
        Debug.Log("New Position" + NewVectorPosition);
        transform.position = NewVectorPosition;
        yield return new WaitForSeconds(2);
        NewPositionX = Random.Range(-10, 10);
        NewPositionY = Random.Range(-10, 10);
        NewVectorPosition = new Vector3(NewPositionX, NewPositionY, 0);
        transform.position = NewVectorPosition;
        Coroutinerunning = false; 
        yield break;
    }

    void Strafe()
    { 
        if (!Direction)
        {
            transform.position = transform.position + Vector3.left  * Time.deltaTime * EnemySpeed; 
            if (transform.position.magnitude >= 10)
            {
                Direction = true;
            }
        }
        else
        {
            transform.position = transform.position + Vector3.right * Time.deltaTime * EnemySpeed;
            if (transform.position.magnitude >= 10)
            {
                Direction = false;
            }
        }
    }
}
