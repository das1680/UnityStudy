using UnityEngine;

public interface IDamageable
{
    void OnDamege(float damage, Vector3 hitPoint, Vector3 hitNormal);
}
