using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private int score = 0;
    [SerializeField] private int waveCount = 0;

    public int GetScore() { return score; }
    public void IncreaseScore(int amount) { score += amount; }

    public int GetWaveCount() { return waveCount; }
    public void IncreaseWaveCount(int amount) { waveCount += amount; }


}
