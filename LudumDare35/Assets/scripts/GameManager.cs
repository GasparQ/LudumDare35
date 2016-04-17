using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject blob;
    private Blob blobObj;

	// Use this for initialization
	void Start () {
        blobObj = blob.GetComponent<Blob>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (blobObj.hitPoints <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}
}
