using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float Speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Using Axis to help with multiple controller types ie. Keyboard or controller
        // WASD - Arrow keys / joy stick should work for this
        // TODO: might need to clamp the overall speed, moving dianglely might be faster.
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        transform.position += new Vector3(horizontal, vertical, 0) * Time.deltaTime * Speed;
    }
}
