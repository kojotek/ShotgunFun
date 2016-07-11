using UnityEngine;
using System.Collections;

static public class MathfExt {

    public static float SignTriple(float _value){
        return _value == 0.0f ? 0.0f : Mathf.Sign(_value);
    }

    public static Quaternion QuaternionFromVector2(Vector2 direction) {
        return Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
    }

    public static Quaternion QuaternionFromAngle2D(float angle){
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public static float AnlgeFromVector2(Vector2 vec)
    {
        return Vector2.Angle(Vector2.up, vec) * Mathf.Sign(-vec.x);
    }

}
