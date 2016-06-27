using UnityEngine;
using System.Collections;

public interface IExplosionReceiver {

    Vector2 AffectedObjectPosition();
    void TakeExplosionEffect(ExplosionEffectInfo info);
}
