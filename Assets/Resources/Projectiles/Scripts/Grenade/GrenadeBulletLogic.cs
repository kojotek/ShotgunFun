using UnityEngine;
using System.Collections;
using System;

public class GrenadeBulletLogic : MonoBehaviour, IProjectileLogic {

    private GrenadeBulletController _controller;
    private Vector2 _bounceVelocityMultiplier;
    private float _hopUp;
    private ExplosionInfo _explosionInfo;
    //private int _bouncesLeft = 5;
    [SerializeField]
    private float _fuzeTime = 1.5f;
    private Coroutine ExpireCheckCoroutineHandler;

    void Awake() {
        _controller = GetComponent<GrenadeBulletController>();
    }

    public void OnInitialize(ProjectileInfo _info, Vector2 direction) {
        var info = _info as GrenadeBulletInfo;
        _bounceVelocityMultiplier = info.OnHitVeclocityMultiplier;
        _hopUp = info.HopUpFactor;
        _explosionInfo = info.ExplosionInfo;
        Fire(direction.normalized * info.InitialSpeed);
        ExpireCheckCoroutineHandler = StartCoroutine(ExpireCheckCorutine());
    }

    public void Fire(Vector2 direction){
        if (Mathf.Abs(direction.y) < 0.1f) {
            direction.y = Mathf.Abs(direction.x) * _hopUp;
        }
        _controller.Fire(direction);
    }

    public void OnHitTerrain(Vector2 hitDirection) {
        if (hitDirection == Vector2.up) {
            _controller.MultiplyVelocity(_bounceVelocityMultiplier);
        }
    }

    public void OnHitEnemy() {
        Explode();
    }

    public void Explode() {
        //var lol = _controller.GetPosition();
        ExplosionFactory.Create(_controller.GetPosition(), _explosionInfo);
        //StopCoroutine(ExpireCheckCoroutineHandler);
        Destroy(this.gameObject);
    }

    public void Destroy() {
        _controller.Destroy();
    }

    IEnumerator ExpireCheckCorutine() {
        yield return new WaitForSeconds(_fuzeTime);
        Explode();
    }

    void OnDrawGizmos() {
        Gizmos.DrawWireSphere(_controller.GetPosition(), _explosionInfo.Radius);
    }
}
