using UnityEngine;
using System.Collections;

public class AvatarAimingUnityContext : MonoBehaviour {

    private GameObject _weapon;
    private GameObject _weaponJoint;
    private float _weaponRotation = 0.0f;
    private float _avatarFaceDirection = 1.0f;

    public float WeaponRotation {
        get { return _weaponRotation; }
    }

    public float AvatarFaceDirection {
        get {
            //throw new System.Exception();
            return _avatarFaceDirection; }
    }

    void Awake() {
        _weaponJoint = GameObject.Find("Player/Avatar/Physical Model/Weapon Joint");
        _weapon = GameObject.Find("Player/Avatar/Physical Model/Weapon Joint/Weapon");
    }

    public void AimInDirection(float _directionAngle)
    {
        //var angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        _weaponJoint.transform.rotation = Quaternion.Euler(0, 0, _directionAngle);
        _weaponRotation = _directionAngle;
        if (_directionAngle == 180)
            _avatarFaceDirection = 0.0f;
        else
            _avatarFaceDirection = MathfExt.SignTriple(-_directionAngle);
    }
}