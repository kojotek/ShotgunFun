using UnityEngine;
using System.Collections;

public interface IProjectileLogic {
    void OnInitialize(ProjectileInfo info, Vector2 direction);
    void Fire(Vector2 direction);
    void OnHitTerrain(Vector2 hitDirection);  //hitting the floor should give Vector2.down, etc.
    void OnHitEnemy();
    void Destroy();
}
