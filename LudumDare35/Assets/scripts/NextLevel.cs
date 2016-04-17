using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

    public string nextLevelName;

    void OnTriggerEnter2d(Collider2D collider)
    {
        SceneManager.LoadScene(nextLevelName);
    }
}
