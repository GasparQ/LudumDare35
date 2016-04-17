using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

    public string nextLevelName;

    void Update()
    {
        RaycastHit2D hitted = Physics2D.Raycast(transform.position, Vector2.up, transform.localScale.y, LayerMask.GetMask("Player"));

        Debug.DrawRay(transform.position, Vector2.up * transform.localScale.y);

        if (hitted.rigidbody != null)
        {
            SceneManager.LoadScene(nextLevelName);
        }
    }
}
