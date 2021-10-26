using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveState : State
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _path;
    [SerializeField] private Animator _animator;

    private Transform[] _points;
    private int _currentPoints;

    public event UnityAction ControlPointReached;

    private void OnEnable()
    {
        _animator.Play(AnimatorPlayerController.States.Runing);
    }
    
    private void Start()
    {
        _points =new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        Transform target = _points[_currentPoints];
        
       Rotate(target);
       transform.position=Vector3.MoveTowards(transform.position,target.position,_speed*Time.deltaTime);
       CheckCurrentPoint(target);
    }

    private void Rotate(Transform target)
    {
        Vector3 direction = target.transform.position - transform.position;
        Quaternion rotation=Quaternion.LookRotation(direction);
        transform.rotation=Quaternion.Lerp(transform.rotation,rotation,_speed*Time.deltaTime);
    }

    private void CheckCurrentPoint(Transform target)
    {
        if (transform.position==target.position)
        {
            if (target.gameObject.TryGetComponent<ControlPoint>(out ControlPoint point))
            {
                _currentPoints++;
                ControlPointReached?.Invoke();
            }
            else
            {
                _currentPoints++;
            }
        }
    }
}
