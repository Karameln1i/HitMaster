using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletColisionHandler : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy)| collision.TryGetComponent<Barrier>(out Barrier barrier))
        {
            _rigidbody.velocity=Vector3.zero;
            gameObject.SetActive(false);
        }
    }
}
