using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] Game game;
    [SerializeField] TextMeshProUGUI ScoreValue;
    [SerializeField] TextMeshProUGUI WaveValue;

    // Start is called before the first frame update
    void Start()
    {
        var gameObject = GameObject.Find("Game");
        game = gameObject.GetComponent<Game>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ScoreValue.text = game.GetScore().ToString();
        WaveValue.text = game.GetWaveCount().ToString();
    }
}
