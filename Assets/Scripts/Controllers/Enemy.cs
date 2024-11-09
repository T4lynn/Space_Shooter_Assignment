using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(EnemyWarp());
    }

    IEnumerator EnemyWarp()
    {
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
    }
}
