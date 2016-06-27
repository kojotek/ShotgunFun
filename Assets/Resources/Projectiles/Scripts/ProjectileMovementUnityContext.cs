using UnityEngine;
using System.Collections;

public class ProjectileMovementUnityContext : MonoBehaviour {

    private Rigidbody2D _rigidbody;
    public Vector2 Velocity {
        get { return _rigidbody.velocity; }
    }

    public Vector2 Position {
        get { return _rigidbody.transform.position; }
    }

	void Awake () {
        _rigidbody = GetComponentInChildren<Rigidbody2D>();
	}

    public void SetVelocity(Vector2 direction) {
        _rigidbody.velocity = direction;
    }

    public void MultiplyVelocity(Vector2 multiplier) {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x * multiplier.x, _rigidbody.velocity.y * multiplier.y);
    }

}