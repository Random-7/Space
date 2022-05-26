using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] WaveConfig waveConfig; 
    
    private List<Transform> waypoints;
    private int indexOfPath = 0;
    private bool reverseDirection = false;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[indexOfPath].transform.position;
        indexOfPath++;
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }
    
    public void SetWaveConfig(WaveConfig newWaveConfig)
    {
        waveConfig = newWaveConfig;
    }

    private void MoveEnemy()
    {
        if(indexOfPath <= waypoints.Count - 1 && !reverseDirection)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[indexOfPath].transform.position, waveConfig.GetEnemySpeed() * Time.deltaTime);
            if(Vector2.Distance(transform.position, waypoints[indexOfPath].transform.position) <= 0.1)
            {
                indexOfPath++;
                if(indexOfPath == waypoints.Count)
                    reverseDirection = true;
            }
        } else if( indexOfPath >= 0 && reverseDirection)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[indexOfPath - 1].transform.position, waveConfig.GetEnemySpeed() * Time.deltaTime);
            if(Vector2.Distance(transform.position, waypoints[indexOfPath - 1].transform.position) <= 0.1)
                indexOfPath--;
            if(indexOfPath == 0 )
                reverseDirection = false;
        }
    }
}
