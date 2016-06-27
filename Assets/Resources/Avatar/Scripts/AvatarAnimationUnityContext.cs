using UnityEngine;
using System.Collections;

public class AvatarAnimationUnityContext : MonoBehaviour {

    private Animator _animator;

	void Awake () {
        _animator = GetComponentInChildren<Animator>();
    }

    void Start() {
        _animator.Play("idle");
    }

    public void PlayStandingAnimation()
    {
        _animator.SetInteger("State", 0);
    }

    public void PlayWalkingAnimation()
    {
        _animator.SetInteger("State", 1);
    }

    public void SetAnimationSpeed(float _speed)
    {
        //Debug.Log(_speed);
        //_animator.SetFloat("Speed", _speed);
        //_animator.speed = _speed;
    }

}
