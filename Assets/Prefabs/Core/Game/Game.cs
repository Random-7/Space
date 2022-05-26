using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private int score = 0;
    private int waveCount = 0;

    public int GetScore() { return score; }
    public void IncreaseScore(int amount) { score += amount; }

    public int GetWaveCount() { return waveCount; }
    public void IncreaseWaveCount(int amount) { waveCount += amount; }

    
}
