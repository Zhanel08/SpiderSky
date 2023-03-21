using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Animate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private InputAction movement;
    [SerializeField] private InputAction attack;
    [SerializeField] private ParticleSystem[] lasers;
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("is running", false);
        _animator.SetBool("attack", false);
    }
    private void OnEnable()
    {
        movement.Enable();
        attack.Enable();
    }
    private void OnDisable()
    {
        movement.Disable();
        attack.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        ProcessFire();
        //Walk();
    }
    
    private void ProcessFire()
    {
        if (attack.ReadValue<float>() > 0.5f)
        {
            SwitchLasersEmission(true);
            _animator.SetBool("attack", true);
        }
        else
        {
            SwitchLasersEmission(false);
            _animator.SetBool("attack", false);
        }
    }
    void SwitchLasersEmission(bool state)
    {
        foreach (var laser in lasers)
        {
            var laserEmission = laser.emission;
            laserEmission.enabled = state;

        }
    }
    private void Walk()
    {
        if (movement.enabled == true) 
        {
            _animator.SetBool("is running", true);
        }
        else
        {
            _animator.SetBool("is running", false);
        }
            
    }
}
