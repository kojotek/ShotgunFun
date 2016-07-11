using UnityEngine;
using System.Collections;

public class ProjectileSpawnerController : MonoBehaviour {

    public GameObject Spawn(ProjectileInfo info, float angle) {
        Quaternion projectileRotation = MathfExt.QuaternionFromAngle2D(angle);
        GameObject projectile = ProjectileFactory.Create(info.ProjectileType, transform.position, projectileRotation, info.CollisionLayer);
        projectile.GetComponent<IProjectileLogic>().OnInitialize(info, projectileRotation * Vector2.up);
        return projectile;
    }

}
