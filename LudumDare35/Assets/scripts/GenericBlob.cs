using UnityEngine;
using System.Collections;

public class GenericBlob : MonoBehaviour {

    public GameObject shoot;
    public float shootSpeed;
    public Vector2 positionDecal;
    public Vector2 forceDirection;

    public void Shoot(Vector3 position, Quaternion rotation, Vector2 direction, bool flipX)
    {
        GameObject sho = Instantiate(shoot, position + new Vector3(positionDecal.x * direction.x, positionDecal.y), rotation) as GameObject;

        sho.GetComponent<SpriteRenderer>().flipX = flipX;
        sho.GetComponent<Rigidbody2D>().AddForce(new Vector2(forceDirection.x * direction.x, forceDirection.y) * shootSpeed);
    }
}
