using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyBalance : MonoBehaviour
{
    [SerializeField] private TMP_Text _money;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _money.text = _player.Money.ToString();
        _player.MoneyChanged += OnManeyChanged;
    }

    private void OnDisable()
    {
        _player.MoneyChanged -= OnManeyChanged;
    }

    private void OnManeyChanged(int mony)
    {
        _money.text = mony.ToString();
    }
}
