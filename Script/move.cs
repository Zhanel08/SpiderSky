using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations;

public class move : MonoBehaviour
{
    [SerializeField] private InputAction movement;
    [SerializeField] private float speed = 5f; 

    float _forwardMovement;
    float _horizontalMovement;

    private void Start()
    {
        
    }
    private void OnEnable()
    {
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }

    private void Update()
    {
        float _horizontalMovement = movement.ReadValue<Vector3>().x;
        float _forwardMovement = movement.ReadValue<Vector3>().z;
        float forwardThrow = _forwardMovement * Time.deltaTime * speed; 
        float horizontalThrow = _horizontalMovement * Time.deltaTime * speed;
        transform.localPosition += new Vector3(horizontalThrow, 0, forwardThrow); 
        
    }
    
}
