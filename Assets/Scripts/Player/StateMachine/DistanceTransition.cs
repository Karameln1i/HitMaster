using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class DistanceTransition : Transition
{
    [SerializeField] private MoveState _moveState;
    [SerializeField] private KillAllEnemiesTransition _killAllEnemiesTransition;
    
    public event UnityAction Launched;

    private void OnEnable()
    {
        Launched?.Invoke();
        _moveState.ControlPointReached += OnControlPointReached;
        _killAllEnemiesTransition.Launched += OnKillEnimisTransitionLaunched;
    }

    private void OnDisable()
    {
        _moveState.ControlPointReached -= OnControlPointReached;
    }

    private void OnControlPointReached()
    {
        NeedTransit = true;
    }
    
    private void OnKillEnimisTransitionLaunched()
    {
        NeedTransit = false;
    }
}