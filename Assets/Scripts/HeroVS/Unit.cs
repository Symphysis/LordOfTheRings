using System;
using UnityEngine;
using UnityEngine.UI;

namespace HeroVS
{
    public abstract class Unit : MonoBehaviour
    {
        [Header("Stats")]
        [SerializeField] protected Weapon weapon;

        [SerializeField] protected int damage = 5;
        [SerializeField] protected int maxHealth = 100;

        [Header("UI")]
        [SerializeField] Image healthImage;

        [SerializeField] protected Text unitName;
        int _health;
        protected float LastAttack;
        protected abstract void UpdateTarget();
        protected abstract GameObject Target { get; set; }

        protected virtual Text UnitName
        {
            get => unitName;
            set => unitName = value;
        }

        protected bool CanAttack => Time.time - LastAttack > weapon.weaponAttackSpeed;
        protected bool IsDead => Health <= 0;

        protected virtual int MaxHealth { get; set; }

        protected virtual int Damage { get; set; }

        protected int Health
        {
            get => _health;
            set => _health = Mathf.Clamp(value, 0, MaxHealth);
        }

        protected void DealDamage()
        {
            Target.GetComponent<Unit>().Health -= Damage;
        }

        protected void UpdateHealthImage()
        {
            healthImage.fillAmount = (float) Health / MaxHealth;
        }
    }
}