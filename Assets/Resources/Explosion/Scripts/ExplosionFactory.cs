using UnityEngine;
using System.Collections;

static public class ExplosionFactory {

    public static GameObject Create(Vector2 position, ExplosionInfo info) {

        GameObject explosion = MonoBehaviour.Instantiate(ExplosionCatalogue.Template, position, Quaternion.identity) as GameObject;
        var explosionController = explosion.GetMasterObject().GetComponent<ExplosionController>();
        explosionController.OnInitialize(info);
        return explosion;
    }

}
