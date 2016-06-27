using UnityEngine;
using System.Collections;

static public class ProjectileFactory {

    public static GameObject Create(ProjectileType type, Vector2 position, Vector2 direction, int collisionLayer) {

        GameObject projectile = MonoBehaviour.Instantiate(ProjectileCatalogue.Templates[ProjectileType.PistolBullet], position, MathfExt.QuaternionFromVector2(direction)) as GameObject;
        projectile.MoveToLayer(collisionLayer);
        return projectile;
    }

    public static GameObject Create(ProjectileType type, Vector2 position, Quaternion direction, int collisionLayer) {

        GameObject projectile = MonoBehaviour.Instantiate(ProjectileCatalogue.Templates[type], position, direction) as GameObject;
        projectile.MoveToLayer(collisionLayer);
        return projectile;
    }

}
