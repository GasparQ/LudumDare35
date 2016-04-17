using UnityEngine;
using System.Collections;

public class RockFist : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "iceCube")
        {
            Destroy(collider.gameObject);
        }
    }
}
