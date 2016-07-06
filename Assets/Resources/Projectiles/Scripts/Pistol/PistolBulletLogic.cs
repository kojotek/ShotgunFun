using UnityEngine;
using System.Collections;
using System;

public class PistolBulletLogic : MonoBehaviour, IProjectileLogic {

    private PistolBulletController _controller;

    void Awake() {
        _controller = GetComponent<PistolBulletController>();
    }

    public void OnInitialize(ProjectileInfo _info, Vector2 direction) {
        var info = _info as PistolBulletInfo;
        Fire(direction.normalized * info.InitialSpeed);
    }

    public void Fire(Vector2 direction) {
        _controller.Fire(direction);
    }

    public void OnHitTerrain(Vector2 hitDirection) {
        Destroy();
    }

    public void OnHitEnemy() {
        Destroy();
    }

    public void Destroy() {
        _controller.Destroy();
    }
}
