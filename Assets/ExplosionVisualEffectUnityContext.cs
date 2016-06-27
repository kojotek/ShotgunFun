using UnityEngine;
using System.Collections;

public class ExplosionVisualEffectUnityContext : MonoBehaviour {

    private ParticleSystem _particleSystem;
    private float _size = 10.0f;

	void Awake () {
        _particleSystem = GetComponent<ParticleSystem>();
	}
	
    public void SetExplosionRadius(float r) {
        _size = r;
        AnimationCurve animationCurve = new AnimationCurve();
        animationCurve.AddKey(0.0f, r);
        animationCurve.AddKey(r/150.0f , 0.5f);

        var velocityLimit = _particleSystem.limitVelocityOverLifetime; //.limit = animationCurve;
        velocityLimit.limit = new ParticleSystem.MinMaxCurve(1.0f, animationCurve);


       //AnimationCurve animationCurve2 = new AnimationCurve();
       //AnimationCurve2.AddKey(0.0f, 0.0f);
       //animationCurve2.AddKey(0.1f, 1.0f);

        //var particleSize = _particleSystem.sizeOverLifetime;

    }

    public void Burst(int number) {
        _particleSystem.Emit(number);
    }

    public int ParticleCount() {
        return _particleSystem.particleCount;
    }

    void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, _size);
    }

}
