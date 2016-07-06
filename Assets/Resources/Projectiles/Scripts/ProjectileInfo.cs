using UnityEngine;
using System.Collections;



public class ProjectileInfo {
    public ProjectileType ProjectileType;
    public float InitialSpeed = 0.0f;
    public int CollisionLayer = -1;
    public int Damage = 0;
    public virtual ProjectileInfo Clone() {
        ProjectileInfo info = new ProjectileInfo();
        info.CollisionLayer = CollisionLayer;
        info.InitialSpeed = InitialSpeed;
        info.ProjectileType = ProjectileType;
        info.Damage = Damage;
        return info;
    }
}

public class PistolBulletInfo : ProjectileInfo {

}

public class ShotgunBulletInfo : ProjectileInfo
{

}

public class GrenadeBulletInfo : ProjectileInfo {
    public Vector2 OnHitVeclocityMultiplier = Vector2.one * 0.5f;
    public float HopUpFactor = 0.12f;
    public ExplosionInfo ExplosionInfo;
    public override ProjectileInfo Clone() {
        GrenadeBulletInfo info = base.Clone() as GrenadeBulletInfo;
        info.OnHitVeclocityMultiplier = OnHitVeclocityMultiplier;
        info.HopUpFactor = HopUpFactor;
        info.ExplosionInfo = ExplosionInfo;
        return info;
    }
}




public class ProjectileInfoBuilder<T, C> 
    where T : ProjectileInfo, new()
    where C : ProjectileInfoBuilder<T, C> {
    protected T _info;

    public C MakeNew() {
        _info = new T();
        return this as C;
    }

    public C SetType(ProjectileType t) {
        _info.ProjectileType = t;
        return this as C;
    }

    public C SetInitialSpeed(float s) {
        _info.InitialSpeed = s;
        return this as C;
    }

    public C SetCollisionLayer(int l) {
        _info.CollisionLayer = l;
        return this as C;
    }

    public C SetDamage(int d) {
        _info.Damage = d;
        return this as C;
    }

    public C SetCollisionLayer(string l) {
        _info.CollisionLayer = LayerMask.NameToLayer(l);
        return this as C;
    }

    public T Create() {
        if (_info == null) {
            throw new System.NullReferenceException();
        }
        return _info;
    }
}

public class PistolBulletInfoBilder : ProjectileInfoBuilder<PistolBulletInfo, PistolBulletInfoBilder> {

}

public class ShotgunBulletInfoBilder : ProjectileInfoBuilder<ShotgunBulletInfo, ShotgunBulletInfoBilder>{

}

public class GrenadeBulletInfoBuilder : ProjectileInfoBuilder<GrenadeBulletInfo, GrenadeBulletInfoBuilder> {
    public GrenadeBulletInfoBuilder SetOnHitVeclocityMultiplier(Vector2 m) {
        _info.OnHitVeclocityMultiplier = m;
        return this;
    }
    public GrenadeBulletInfoBuilder SetHopUpFactor(float h) {
        _info.HopUpFactor = h;
        return this;
    }
    public GrenadeBulletInfoBuilder SetExplosionInfo(ExplosionInfo explosionInfo) {
        _info.ExplosionInfo = explosionInfo;
        return this;
    }
}