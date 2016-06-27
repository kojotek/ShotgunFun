using UnityEngine;
using System.Collections;
using System;

public class GrenadeBulletController : MonoBehaviour, IProjectileController {

    private ProjectileMovementUnityContext _movement;
    private IProjectileLogic _logic;

    void Awake() {
        _movement = GetComponent<ProjectileMovementUnityContext>();
        _logic = this.GetComponentByInterface<IProjectileLogic>();
    }

    public void Fire(Vector2 direction) {
        _movement.SetVelocity(direction);
    }

    public void MultiplyVelocity(Vector2 multiplier) {
        _movement.MultiplyVelocity(multiplier);
    }

    public void CollisionSignal(Collision2D collision) {
        if (collision.collider.gameObject.GetTagManager().Contains(InGameTag.Terrain)) {
            _logic.OnHitTerrain( collision.contacts[0].normal );
        }
        if (collision.collider.gameObject.GetTagManager().Contains(InGameTag.EnemyUnit)) {
            _logic.OnHitEnemy();
        }
    }

    public Vector2 GetPosition() {
        return _movement.Position;
    }

    public void Destroy() {
        Destroy(gameObject);
    }

    public Vector2 GetVelocity() {
        return _movement.Velocity;
    }
}
