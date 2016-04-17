using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "iceCube")
        {
            IceCube cub = collider.gameObject.GetComponent<IceCube>();

            cub.GetEnnemy().SetActive(true);
            cub.GetEnnemy().GetComponent<Ennemy>().hitPoints -= 5;
            Destroy(collider.gameObject);
        }
    }
}
