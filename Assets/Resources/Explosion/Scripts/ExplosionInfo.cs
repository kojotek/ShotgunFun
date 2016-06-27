using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class ExplosionInfo {
    public ExplosionInfo(float _radius, ExplosionPropagationMethod _method, float _force, float _damage, InGameTag _tag) {
        Force = _force;
        Damage = _damage;
        Radius = _radius;
        PropagationMethod = _method;
        Tag = _tag;
    }

    public float Radius = 0.0f;
    public ExplosionPropagationMethod PropagationMethod = ExplosionPropagationMethod.Constant;
    public float Force = 0.0f;
    public float Damage = 0.0f;
    public InGameTag Tag = InGameTag.None;
}
