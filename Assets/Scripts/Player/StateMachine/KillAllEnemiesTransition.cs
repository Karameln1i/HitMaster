using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KillAllEnemiesTransition : Transition
{
    [SerializeField] private DistanceTransition _distanceTransition;
    [SerializeField] private List<Wave> _waves;

    private int _waveNumber = 0;
    private List<Enemy> _currentEnemies;
    
    public event UnityAction Launched;
   
   private void OnEnable()
   {
       _distanceTransition.Launched += OnDistanceTransitionLaunched;
       Launched?.Invoke();
       
       _currentEnemies = _waves[_waveNumber]._enemies;
       
       for (int i = 0; i < _currentEnemies.Capacity; i++)
       {
           _currentEnemies[i].Died += OnEnemiesDied;
       }
       
   }

   private void OnEnemiesDied(Enemy enemy)
    {
        enemy.Died -= OnEnemiesDied;
        
        _currentEnemies.Remove(enemy);

        if (_currentEnemies.Count<=0)
        {
            NeedTransit = true;
            _waveNumber++;
        }
    }
    
    private void OnDistanceTransitionLaunched()
    {
        NeedTransit = false;
    }
}
