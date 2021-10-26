using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    private void OnTriggerEnter(Collider coldier)
    {
        if (coldier.TryGetComponent<Player>(out Player player))
        {
            SceneManager.LoadScene(0);
            Debug.Log("player");
        }
    }
}
