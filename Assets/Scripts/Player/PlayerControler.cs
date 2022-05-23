using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControler : MonoBehaviour
{

    [SerializeField] float Speed = 5.0f;
    [SerializeField] float BoostAmount = 2.0f;

    PlayerControls controls;
    Vector2 move;
    float boost = 1.0f;

    void Awake()
    {
        controls =  new PlayerControls();
        //Movement bindings
        controls.Game.Movement.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Game.Movement.canceled += ctx => move = Vector2.zero;
        //Boost Bindings
        controls.Game.Boost.performed += ctx => boost += BoostAmount;
        controls.Game.Boost.canceled += ctx => boost = 1.0f;
    }
    void OnEnable() 
    {
        controls.Game.Enable();
    }
    void OnDisable() 
    {
        controls.Game.Disable();
    }

    void Update()
    {
        // Using Axis to help with multiple controller types ie. Keyboard or controller
        // WASD - Arrow keys / joy stick should work for this
        Vector2 direction = (new Vector2(move.x,move.y) * Speed * boost) * Time.deltaTime;
        transform.Translate(direction, Space.World);
    }

}
