using UnityEngine;
using System.Collections;

public class ExplosionEffectInfo{
    public ExplosionEffectInfo(Vector2 _force, float _damage, InGameTag _tag) {
        Force = _force;
        Damage = _damage;
        Tag = _tag;
    }

    public Vector2 Force = Vector2.zero;
    public float Damage = 0.0f;
    public InGameTag Tag = InGameTag.None;
}