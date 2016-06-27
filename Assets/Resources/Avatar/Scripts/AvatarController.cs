using UnityEngine;
using System.Collections;
using System;

public class AvatarController : MonoBehaviour {
    #region variables
    private AvatarLogic _logic;
    private AvatarAimingUnityContext _aimingController;
    private AvatarAnimationUnityContext _animationController;
    private SmoothMovementUnityContext _movementController;
    private GroundDetectionUnityContext _groundDetector;
    private ProjectileSpawnerController _projectileSpawner;
    #endregion
    #region initialization
    void Awake () {
        _logic = GetComponent<AvatarLogic>();
        _aimingController = GetComponent<AvatarAimingUnityContext>();
        _animationController = GetComponent<AvatarAnimationUnityContext>();
        _movementController = GetComponent<SmoothMovementUnityContext>();
        _groundDetector = GetComponentInChildren<GroundDetectionUnityContext>();
        _projectileSpawner = transform
            .Find("Physical Model/Weapon Joint/Weapon/Projectile Spawner")
            .gameObject
            .GetComponent<ProjectileSpawnerController>();
    }

    void Start() {
        ////
        SetMaxSpeed(35.0f);
        ////
    }
    #endregion
    #region movement
    public bool IsGrounded(){
        return _groundDetector.IsGrounded;
    }

    public void JumpSignal() {
        _logic.OnJumpInputSignal();
    }

    public void Jump(float _force){
        _movementController.Jump(_force);
    }

    public void DirectionalInputChangeSignal(Vector2 _direction) {
        _logic.OnDirectionalInputChangeSignal(_direction);
    }

    public void Stay(){
        _animationController.PlayStandingAnimation();
        _animationController.SetAnimationSpeed(1.0f);
        _movementController.SetHorizontalVelocity(0.0f);
    }

    public void SetMaxSpeed(float _speed) {
        _movementController.MaxHorizontalSpeed = Mathf.Abs(_speed);
    }

    public Vector2 GetVelocity() {
        return _movementController.Velocity;
    }

    public void Walk(float _direction, float _speed) {
        _animationController.PlayWalkingAnimation();
        _animationController.SetAnimationSpeed(_speed * _direction/50.0f);
        _movementController.SetHorizontalVelocity(_direction * _speed);
    }

    public void ExternalVelocityAddedSignal(Vector2 velocity) {
        _logic.OnExternalVelocityAdded(velocity);
    }

    public void AddVelocity(Vector2 velocity) {
        _movementController.AddVelocity(velocity);
    }
    #endregion
    #region shooting
    public void ShotSignal(ProjectileType projectileType) {
        _logic.OnShotSignal(projectileType);
    }

    public void Shot(ProjectileInfo info) {
        _projectileSpawner.Spawn(info);
    }

    public void AimInDirection(Vector2 _direction) {
        _aimingController.AimInDirection(_direction);
    }

    public float GetAvatarAimingDirection() {
        return _aimingController.AvatarAimingDirection;
    }
    #endregion
}
