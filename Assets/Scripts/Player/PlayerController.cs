using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerAttack playerAttack;
    [SerializeField] PlayerMovement playerMovement;

    PlayerControls controls;
    Vector2 move;
    float boost = 1.0f;

    void Awake()
    {
        //Create Controls
        controls =  new PlayerControls();
        //Movement bindings
        controls.Game.Movement.performed += ctx => playerMovement.MovementDirection( ctx.ReadValue<Vector2>().x, ctx.ReadValue<Vector2>().y);
        controls.Game.Movement.canceled += ctx => playerMovement.MovementDirection( 0.0f, 0.0f);
        //Boost Bindings
        controls.Game.Boost.performed += ctx => playerMovement.ApplyBoost();
        controls.Game.Boost.canceled += ctx => playerMovement.RemoveBoost();
        //Attack Binding
        controls.Game.Attack1.performed += ctx => playerAttack.Fire1(true);
        controls.Game.Attack1.canceled += ctx => playerAttack.Fire1(false);
        controls.Game.Attack2.performed += ctx => playerAttack.Fire2(true);
        controls.Game.Attack2.canceled += ctx => playerAttack.Fire2(false);

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

    }

}
