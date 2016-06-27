using UnityEngine;
using System.Collections.Generic;

static class GameObjectExtend {

    static public GameObject GetMasterObject(this GameObject gObject) {
        var masterObjComponent = gObject.GetComponentInParent<MasterObject>();
        if (masterObjComponent != null)
            return masterObjComponent.gameObject;
        else
            return null;
    }

    static public TagManager GetTagManager(this GameObject gObject) {
        return gObject.GetMasterObject().GetComponent<TagManager>();
    }

    static public void MoveToLayer(this GameObject rootObj, int layer) {
        rootObj.layer = layer;
        foreach (Transform child in rootObj.transform)
            MoveToLayer(child.gameObject, layer);
    }
}
