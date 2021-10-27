using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : ObjectPool
{
   [SerializeField] private Bullet _bullet;
   [SerializeField] private GameObject _muzzle;

   private void Start()
   {
       Initialize(_bullet);
   }
   
   public void Shoot(Vector3 direction)
   {

       if (TryGetBullet(out Bullet bullet))
       {
            SetBullet(bullet);
            bullet.FlyToGoal(direction);
       }
   }

   private void SetBullet(Bullet bullet)
   {
       bullet.gameObject.SetActive(true);
       bullet.transform.position = _muzzle.transform.position;
   }
}
