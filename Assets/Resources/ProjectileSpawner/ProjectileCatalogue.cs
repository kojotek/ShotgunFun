using UnityEngine;
using System.Collections.Generic;
using System;

public class ProjectileCatalogue {

    private static Dictionary<ProjectileType, GameObject> _templatesDic;
    public static Dictionary<ProjectileType, GameObject> Templates {
        get {
            if (_templatesDic != null) {
                return _templatesDic;
            }
            else { 
                _templatesDic = new Dictionary<ProjectileType, GameObject>();
                FillWithData();
                return _templatesDic;
            }
        }
    }

    static private void FillWithData() {
        _templatesDic.Add(ProjectileType.PistolBullet, Resources.Load("Projectiles/Prefabs/PistolBullet") as GameObject);
        _templatesDic.Add(ProjectileType.Grenade, Resources.Load("Projectiles/Prefabs/GrenadeBullet") as GameObject);
    }
}