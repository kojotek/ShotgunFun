using UnityEngine;
using System.Collections;
using System;

public class ShotgunBulletLogic : MonoBehaviour, IProjectileLogic {

    private ShotgunBulletController _controller;

    void Awake() {
        _controller = GetComponent<ShotgunBulletController>();
    }

    public void OnInitialize(ProjectileInfo _info, Vector2 direction) {
        var info = _info as ShotgunBulletInfo;
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
