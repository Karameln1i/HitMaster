using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class ShootState : State
{
    [SerializeField] private Pistol _pistol;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _muzzle;

    private Ray ray;
    private RaycastHit hit;
    private Camera _camera;
    private Vector3 direction;
    

    private void OnEnable()
    {
        _animator.Play(AnimatorPlayerController.States.Aiming);
    }
    
    private void Start()
    {
       _camera = Camera.main;
    }
    
    private void Update()
    {
        ray = _camera.ScreenPointToRay(Input.mousePosition);
           
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                direction = hit.point- _muzzle.transform.position;
                   
                _pistol.Shoot(direction);
            }
        }
            
    }
} 
