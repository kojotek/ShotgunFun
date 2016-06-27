using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public enum ExplosionPropagationMethod {
    Linear,
    Square,
    Qubic,
    Cosinus,
    InverseSquare,
    InverseQubic,
    InverseSinus,
    Constant
}

public class ExplosionController : MonoBehaviour {

    private float _radius;
    private float _damage;
    private float _force;
    private ExplosionPropagationMethod _method = ExplosionPropagationMethod.Linear;
    private InGameTag _tag = InGameTag.None;
    private ExplosionVisualEffectUnityContext _visualEffect;

    void Awake() {
        _visualEffect  = GetComponentInChildren<ExplosionVisualEffectUnityContext>();
    }

    void Start() {
        Explode();
    }

    public void OnInitialize(ExplosionInfo info) {
        _radius = info.Radius;
        _damage = info.Damage;
        _force = info.Force;
        _method = info.PropagationMethod;
        _tag = info.Tag;
    }

    void Explode() {
        var colliders = Physics2D.OverlapCircleAll(transform.position, _radius);
        var objects = colliders
            .Where(c => {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, c.transform.position - transform.position, _radius);
                if (hit.collider == c){
                    return true;
                }
                else {
                    return false;
                }
            })
            .Select(x => x.gameObject.GetMasterObject().GetComponentInChildren<IExplosionReceiver>())
            .Where(x => x != null)
            .Distinct()
            .ToList();

        foreach(var o in objects) {
            Affect(o);
        }

        StartCoroutine(BurstParticlesAndDestroy());
    }


    void Affect(IExplosionReceiver receiver) {
        var receiverPosition = receiver.AffectedObjectPosition();
        Vector2 direction = receiverPosition - (Vector2) transform.position;
        float distance = direction.magnitude;
        float distanceMultiplier = DistanceMultiplier(distance);
        Vector2 force = direction.normalized * distanceMultiplier * _force;
        float damage = distanceMultiplier * _damage;

        ExplosionEffectInfo info = new ExplosionEffectInfo(force, damage, _tag);
        receiver.TakeExplosionEffect(info);
    }

    private float DistanceMultiplier(float distance) {
        float fraction = distance / _radius;
        switch (_method) {
            case ExplosionPropagationMethod.Constant:
                return 1.0f;
            case ExplosionPropagationMethod.Cosinus:
                return Mathf.Cos(fraction / (2.0f * Mathf.PI));
            case ExplosionPropagationMethod.InverseQubic:
                return Mathf.Pow((-fraction + 1.0f), 3);
            case ExplosionPropagationMethod.InverseSinus:
                return -Mathf.Sin(fraction / (2 * Mathf.PI)) + 1;
            case ExplosionPropagationMethod.InverseSquare:
                return Mathf.Pow((-fraction + 1.0f), 2);
            case ExplosionPropagationMethod.Linear:
                return 1 - fraction;
            case ExplosionPropagationMethod.Qubic:
                return -Mathf.Pow(fraction, 3) + 1.0f;
            case ExplosionPropagationMethod.Square:
                return -Mathf.Pow(fraction, 2) + 1.0f;
            default:
                return -1.0f;   //something went terribly wrong, mate
        }
    }

    IEnumerator BurstParticlesAndDestroy() {
        _visualEffect.SetExplosionRadius(_radius);
        _visualEffect.Burst(10 * (int)_radius);
        while (_visualEffect.ParticleCount() > 0) {
            yield return null;
        }
        Destroy(this.gameObject);
    }
}
