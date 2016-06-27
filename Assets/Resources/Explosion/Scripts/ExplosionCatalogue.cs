using UnityEngine;
using System.Collections.Generic;
using System;

public class ExplosionCatalogue {

    private static GameObject _template;
    public static GameObject Template {
        get {
            if (_template != null) {
                return _template;
            }
            else { 
                FillWithData();
                return _template;
            }
        }
    }

    static private void FillWithData() {
        _template = Resources.Load("Explosion/Prefabs/Explosion") as GameObject;
    }
}