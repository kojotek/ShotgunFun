using UnityEngine;
using System.Collections;

static public class MathfExt {

    public static float SignTriple(float _value){
        return _value == 0.0f ? 0.0f : Mathf.Sign(_value);
    }

    public static Quaternion QuaternionFromVector2(Vector2 direction) {
        return Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
    }

}
