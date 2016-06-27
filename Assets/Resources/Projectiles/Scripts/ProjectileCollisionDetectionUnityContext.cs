using UnityEngine;
using System.Collections;

public class ProjectileCollisionDetectionUnityContext : MonoBehaviour {

    private IProjectileController _controller;
    private Collider2D _collider;

    void Awake() {
        _controller = this.GetComponentInParentByInterface<IProjectileController>();
        _collider = GetComponent<Collider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        _controller.CollisionSignal(collision);
    }

}
