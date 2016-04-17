using UnityEngine;
using System.Collections;

public class EnnemySpawner : MonoBehaviour {
    public int Capacity = -1;
    public GameObject model;
    private GameObject ennemy = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (ennemy == null && Capacity == -1 || Capacity > 0)
        {
            if (Capacity > 0)
                Capacity -= 1;
            ennemy = Instantiate(model, transform.position, transform.rotation) as GameObject;
        }
        Debug.Log(ennemy.name);
	}
}
