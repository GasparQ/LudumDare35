using UnityEngine;
using System.Collections;

public class IceSpike : MonoBehaviour {
    public GameObject iceCubed;
    private GameObject saved;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Ennemy hitted = collider.gameObject.GetComponent<Ennemy>();

        if (hitted != null)
        {
            saved = hitted.gameObject;
            Vector3 pos = hitted.transform.position;
            Quaternion rot = hitted.transform.rotation;

            GameObject cube = Instantiate(iceCubed, pos, rot) as GameObject;

            saved.SetActive(false);
            cube.GetComponent<IceCube>().SetEnnemy(saved);
            //Destroy(hitted.gameObject);
        }
    }
}
