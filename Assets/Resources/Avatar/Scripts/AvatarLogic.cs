using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AvatarLogic : MonoBehaviour {

    private AvatarController _controller;
    private PlayerStatisticsManager _statisticsManager;
    private Dictionary<ProjectileType, float> _cooldownTimes;
    private int _jumpsLeft;

    void Awake () {
        _controller = GetComponent<AvatarController>();
        _statisticsManager = GetComponentInParent<PlayerStatisticsManager>();
        _cooldownTimes = new Dictionary<ProjectileType, float>();

        var weapons = Enum.GetValues(typeof(ProjectileType));
        foreach (var w in weapons) {
            _cooldownTimes.Add((ProjectileType)w, 0.0f);
        }

        _jumpsLeft = (int) _statisticsManager.GetCardStatistic(CardStatistics.Jumps);
    }
	
    public void OnJumpInputSignal() {
        if (_jumpsLeft > 0) {
            _controller.Jump(_statisticsManager.GetCardStatistic(CardStatistics.JumpHeight));
            _jumpsLeft--;
        }
        else {
            StartCoroutine(
            WaitForGroundCoroutine(
                0.2f,
                () => {
                    _controller.Jump(_statisticsManager.GetCardStatistic(CardStatistics.JumpHeight));
                    _jumpsLeft = _statisticsManager.GetCardStatistic(CardStatistics.Jumps) -1;
                }
            ));
        }
    }

    public void OnDirectionalInputChangeSignal(Vector2 _direction) {

        Vector2 aimVector = Vector2.zero;
        aimVector.y = _direction.y;

        if (_direction.y == 0.0f && _direction.x == 0.0f) {
            aimVector.x = _controller.GetAvatarFaceDirection();
        }
        if (_direction.y != 0.0f && _direction.x == 0.0f) {
            aimVector.x = 0.0f;
        }
        if (_direction.x != 0.0f) {
            aimVector.x = _direction.x;
            _controller.Walk(_direction.x, 35.0f);
        }
        else {
            _controller.Stay();
        }
        if (_direction.y == -1.0f) {
            aimVector.x = 0.0f;
        }

        var angle = MathfExt.AnlgeFromVector2(aimVector);
        _controller.AimInDirection(angle);
    }

    private IEnumerator WaitForGroundCoroutine(float delayTime, Action groundDependentAction) {
        float currentTime = Time.fixedTime;

        for (float i = currentTime; i < currentTime + delayTime; i += Time.fixedDeltaTime) {
            if (!_controller.IsGrounded()) {
                yield return false;
            }
            else {
                groundDependentAction();
                break;
            }
        }
    }

    public void OnShotSignal(ProjectileType projectileType) {
        if (_cooldownTimes[projectileType] == 0.0f) {
            _controller.Shot( _statisticsManager.GetProjectileInfo(projectileType), _controller.GetWeaponRotation() );
        }
    }

    public void OnExternalVelocityAdded(Vector2 velocity) {
        var newVelocity = velocity * (1.0f - (float)_statisticsManager.GetCardStatistic(CardStatistics.Stability) / 100.0f);
        _controller.AddVelocity(newVelocity);
    }
}
