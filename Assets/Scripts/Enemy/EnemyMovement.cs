using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] List<Transform> WavePath;
    private int indexOfPath = 0;
    private bool reverseDirection = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = WavePath[indexOfPath].transform.position;
        indexOfPath++;
    }

    // Update is called once per frame
    void Update()
    {
        if(indexOfPath <= WavePath.Count - 1 && !reverseDirection)
        {
            transform.position = Vector2.MoveTowards(transform.position, WavePath[indexOfPath].transform.position, enemy.GetSpeed() * Time.deltaTime);
            if(Vector2.Distance(transform.position, WavePath[indexOfPath].transform.position) <= 0.1)
            {
                indexOfPath++;
                if(indexOfPath == WavePath.Count)
                    reverseDirection = true;
            }
        } else if( indexOfPath >= 0 && reverseDirection)
        {
            transform.position = Vector2.MoveTowards(transform.position, WavePath[indexOfPath - 1].transform.position, enemy.GetSpeed() * Time.deltaTime);
            if(Vector2.Distance(transform.position, WavePath[indexOfPath - 1].transform.position) <= 0.1)
                indexOfPath--;
            if(indexOfPath == 0 )
                reverseDirection = false;
        }
    }
}
