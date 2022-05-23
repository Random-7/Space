using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float fire1Rate = 1.0f;
    [SerializeField] float fire2Rate = 1.0f;


    public float GetFire1Rate() { return fire1Rate; }
    public float GetFire2Rate() { return fire2Rate; }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

}
