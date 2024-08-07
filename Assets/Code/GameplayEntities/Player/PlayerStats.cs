using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerStats", menuName = "ScriptableObjects/PlayerStats")]
public class PlayerStats : CharacterStats
{
    public FloatVariable moveSpeed;
    public Weapon weapon;

    public void ResetTo(PlayerStats other)
    {
        Health.ResetTo(other.Health);
        moveSpeed.Value = other.moveSpeed.Value;
        weapon.ResetTo(other.weapon);
    }
}
