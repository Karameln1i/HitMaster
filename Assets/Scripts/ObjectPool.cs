using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capicity;

    private List<Bullet> _pool=new List<Bullet>();

    protected void Initialize(Bullet prefab)
    {
        for (int i = 0; i < _capicity; i++)
        {
            Bullet spawned = Instantiate(prefab, _container.transform);
            spawned.gameObject.SetActive(false);
        
            _pool.Add(spawned);
        }
    }

    protected bool TryGetBullet(out Bullet result)
    {
        result = _pool.First(p => p.gameObject.activeSelf == false);
       return result != null;
    }
}
