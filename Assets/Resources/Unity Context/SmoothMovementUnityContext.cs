using UnityEngine;
using System.Collections;

public class SmoothMovementUnityContext : MonoBehaviour {

    private float _maxHorizontalSpeed = 10.0f;
    private float _targetHorizontalSpeed = 0.0f;
    private float _acceleration = 70.0f;
    private Rigidbody2D _rigidbody;

    public Vector2 Velocity {
        get { return _rigidbody.velocity; }
    }
    public float TargetHorizontalSpeed
    {
        get { return _targetHorizontalSpeed; }
    }
    public float Acceleration
    {
        get { return _acceleration; }
        set { _acceleration = value; }
    }
    public float MaxHorizontalSpeed
    {
        get { return _maxHorizontalSpeed; }
        set { _maxHorizontalSpeed = value; }
    }


    void Awake (){
        _rigidbody = GetComponentInChildren<Rigidbody2D>();
    }

    public void Jump(float _force){
        //_rigidbody.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _force); //to uniezaleznia wysokosc skoku od predkosci w poziomie
    }

    public void AddVelocity(Vector2 velocity) {
        _rigidbody.velocity += velocity;
    }

    public void SetHorizontalVelocity(float velocity) {
        _targetHorizontalSpeed = Mathf.Clamp(velocity, -_maxHorizontalSpeed, _maxHorizontalSpeed);
    }

    public void SetVerticalVelocity(float velocity) {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, velocity);
    }

    void FixedUpdate(){

        //if (Mathf.Abs(_targetHorizontalSpeed - _rigidbody.velocity.x) > 0.05f ) 
        {
            float t = _rigidbody.velocity.x / _targetHorizontalSpeed + (Time.fixedDeltaTime / _acceleration);
            Vector2 newVelocity = _rigidbody.velocity + Vector2.right * MathfExt.SignTriple(_targetHorizontalSpeed - _rigidbody.velocity.x) * Time.fixedDeltaTime * _acceleration;
            if (Mathf.Abs(_targetHorizontalSpeed - _rigidbody.velocity.x) < Time.fixedDeltaTime * _acceleration) {
                newVelocity.x = _targetHorizontalSpeed;
            }
            _rigidbody.velocity = newVelocity;
            //Debug.Log(newVelocity);
        }
        
    }


}
