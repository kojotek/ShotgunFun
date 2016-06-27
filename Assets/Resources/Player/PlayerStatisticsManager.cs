using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum CardStatistics {
    Stability,
    Jumps,
    JumpHeight,
    Damage,
    ExplosionRange,
    ExplosionForce,
    ProjectileSpeed,
    BallisticProjectileSpeed
}

public class PlayerStatisticsManager : MonoBehaviour {

    private Dictionary<ProjectileType, ProjectileInfo> _projectileStatistics;
    private Dictionary<CardStatistics, int> _avatarCardStatistics;

	void Awake () {
        //InitCardStatistics();
    }

    public void SetProjectileInfo(ProjectileType type, ProjectileInfo info) {
        if (_projectileStatistics.ContainsKey(type)){
            _projectileStatistics[type] = info;
        }
        else {
            _projectileStatistics.Add(type, info);
        }
    }

    public ProjectileInfo GetProjectileInfo(ProjectileType type) {
        if (_projectileStatistics == null) {
            InitCardStatistics();
        }
        return _projectileStatistics[type];
    }

    public void SetCardStatistic(CardStatistics statistic, int value) {
        if (_avatarCardStatistics.ContainsKey(statistic)) {
            _avatarCardStatistics[statistic] = value;
            ReinitProjectileStatistics();
        }
        else {
            _avatarCardStatistics.Add(statistic, value);
        }
    }

    public int GetCardStatistic(CardStatistics statistic) {
        if (_avatarCardStatistics == null) {
            InitCardStatistics();
        }
        return _avatarCardStatistics[statistic];
    }

    void ReinitProjectileStatistics() {
        _projectileStatistics = new Dictionary<ProjectileType, ProjectileInfo>();
        #region pistol
        {
            PistolBulletInfoBilder pistolBuilder = new PistolBulletInfoBilder();
            PistolBulletInfo pistolInfo = pistolBuilder
                .MakeNew()
                .SetType(ProjectileType.PistolBullet)
                .SetInitialSpeed(_avatarCardStatistics[CardStatistics.ProjectileSpeed])
                .SetCollisionLayer("Friendly Projectile")
                .SetDamage(_avatarCardStatistics[CardStatistics.Damage])
                .Create();
            SetProjectileInfo(ProjectileType.PistolBullet, pistolInfo);
        }
        #endregion
        #region grenade
        {
            GrenadeBulletInfoBuilder grenadeBuilder = new GrenadeBulletInfoBuilder();
            GrenadeBulletInfo grenadeInfo = grenadeBuilder
                .MakeNew()
                .SetType(ProjectileType.Grenade)
                .SetInitialSpeed((float)_avatarCardStatistics[CardStatistics.BallisticProjectileSpeed] * 1.2f)
                .SetCollisionLayer("Friendly Projectile")
                .SetOnHitVeclocityMultiplier(new Vector2(0.6f, 1.0f))
                .SetHopUpFactor(0.12f)
                //.SetDamage(10) Tego nie uzywamy, to zalatwia ExplosionInfo
                .SetExplosionInfo(new ExplosionInfo(
                    (float)_avatarCardStatistics[CardStatistics.ExplosionRange] * 1.0f,
                    //ExplosionPropagationMethod.Square,
                    ExplosionPropagationMethod.Constant,
                    (float)_avatarCardStatistics[CardStatistics.ExplosionForce] * 1.0f,
                    (float)_avatarCardStatistics[CardStatistics.Damage] * 1.5f,
                    InGameTag.FriendlyExplosion
                    ))
                .Create();
            SetProjectileInfo(ProjectileType.Grenade, grenadeInfo);
        }
        #endregion
    }

    void InitCardStatistics() {
        _avatarCardStatistics = new Dictionary<CardStatistics, int>();
        SetCardStatistic(CardStatistics.Stability, 10);
        SetCardStatistic(CardStatistics.Jumps, 2);
        SetCardStatistic(CardStatistics.JumpHeight, 50);
        SetCardStatistic(CardStatistics.Damage, 10);
        SetCardStatistic(CardStatistics.ExplosionRange, 15);
        SetCardStatistic(CardStatistics.ExplosionForce, 50);
        SetCardStatistic(CardStatistics.ProjectileSpeed, 90);
        SetCardStatistic(CardStatistics.BallisticProjectileSpeed, 50);

        /*After all statistics*/
        ReinitProjectileStatistics();
    }
}