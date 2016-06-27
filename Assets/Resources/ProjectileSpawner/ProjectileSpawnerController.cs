using UnityEngine;
using System.Collections;

public class ProjectileSpawnerController : MonoBehaviour {

    public GameObject Spawn(ProjectileInfo info) {
        GameObject projectile = ProjectileFactory.Create(info.ProjectileType, transform.position, transform.rotation, info.CollisionLayer);
        projectile.GetComponent<IProjectileLogic>().OnInitialize(info, transform.rotation * Vector2.right);
        return projectile;
    }

}
