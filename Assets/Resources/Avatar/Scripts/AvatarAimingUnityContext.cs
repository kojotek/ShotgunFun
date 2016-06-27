using UnityEngine;
using System.Collections;

public class AvatarAimingUnityContext : MonoBehaviour {

    private GameObject _weapon;
    private GameObject _weaponJoint;
    private Vector2 _weaponRotation = Vector2.zero;
    private float _avatarAimingDirection = 1.0f;
    public Vector2 WeaponRotation {
        get { return _weaponRotation; }
    }

    public float AvatarAimingDirection {
        get { return _avatarAimingDirection; }
    }

    void Awake() {
        _weaponJoint = GameObject.Find("Player/Avatar/Physical Model/Weapon Joint");
        _weapon = GameObject.Find("Player/Avatar/Physical Model/Weapon Joint/Weapon");
    }

    public void AimInDirection(Vector2 _direction)
    {
        var angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        _weaponJoint.transform.rotation = Quaternion.Euler(0, 0, angle);
        _weaponRotation = _weaponJoint.transform.rotation.eulerAngles;
        _avatarAimingDirection = 
            _direction.x == 0.0f ?  _avatarAimingDirection : _direction.x;
    }
}
