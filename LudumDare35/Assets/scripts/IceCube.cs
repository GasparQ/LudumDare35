using UnityEngine;
using System.Collections;

public class IceCube : MonoBehaviour {

    public GameObject ennemyToSave;

    public void SetEnnemy(GameObject ennemy)
    {
        ennemyToSave = ennemy;
    }

    public GameObject GetEnnemy()
    {
        ennemyToSave.transform.position = transform.position;
        return (ennemyToSave);
    }
}
