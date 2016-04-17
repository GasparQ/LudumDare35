using UnityEngine;
using System.Collections;

public class IceCube : MonoBehaviour {

    private GameObject ennemyToSave;

    public void SetEnnemy(GameObject ennemy)
    {
        ennemyToSave = ennemy;
    }

    public GameObject GetEnnemy()
    {
        return (ennemyToSave);
    }
}
