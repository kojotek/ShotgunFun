using UnityEngine;
using System.Collections;
using System;

public class PistolBulletController : MonoBehaviour, IProjectileController {

    private ProjectileMovementUnityContext _movement;
    private IProjectileLogic _logic;

    void Awake() {
        _movement = GetComponent<ProjectileMovementUnityContext>();
        _logic = this.GetComponentByInterface<IProjectileLogic>();
    }

    public void Fire(Vector2 direction) {
        _movement.SetVelocity(direction);
    }

    public void Destroy() {
        Destroy(gameObject);
    }

    public void CollisionSignal(Collision2D collision) {
        if (collision.collider.gameObject.GetTagManager().Contains(InGameTag.Terrain)) {
            _logic.OnHitTerrain(Vector2.zero);
        }

        if (collision.collider.gameObject.GetTagManager().Contains(InGameTag.EnemyUnit)) {
            _logic.OnHitEnemy();
        }
    }

    public Vector2 GetVelocity() {
        return _movement.Velocity;
    }
}
