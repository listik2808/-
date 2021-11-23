using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _sootPoint;

    private Weapon _currentWeapon;
    private int _curentWeaponeNumber = 0;
    private int _currentHealth;
    private Animator _animator;

    public int Money { get; private set; }

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int> MoneyChanged;

    private void Start()
    {
        ChangeWeapon(_weapons[_curentWeaponeNumber]);
        _currentHealth = _health;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot(_sootPoint);
        }
    }

    private  void OnEnemyDied(int reward)
    {
        Money += reward;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth,_health);

        if (_currentHealth <= 0)
            Destroy(gameObject);
    }

    public void AddMoney(int money)
    {
        Money += money;
        MoneyChanged?.Invoke(Money);
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        MoneyChanged?.Invoke(Money);
        _weapons.Add(weapon);
    }

    public void Nextweapon()
    {
        if (_curentWeaponeNumber == _weapons.Count - 1)
            _curentWeaponeNumber = 0;
        else
            _curentWeaponeNumber++;

        ChangeWeapon(_weapons[_curentWeaponeNumber]);
    }

    public void PreviousWeapon()
    {
        if (_curentWeaponeNumber == 0)
            _curentWeaponeNumber = _weapons.Count - 1;
        else
            _curentWeaponeNumber--;

        ChangeWeapon(_weapons[_curentWeaponeNumber]);
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }
}
