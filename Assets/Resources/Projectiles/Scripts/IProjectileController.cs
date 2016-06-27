using UnityEngine;
using System.Collections;
using System;

public interface IProjectileController {

    void Fire(Vector2 direction);
    void Destroy();
    void CollisionSignal(Collision2D collision);
    Vector2 GetVelocity();
}
