using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private Button _actionButton;

    private Coroutine _countCoroutine;
    private WaitForSeconds _wait;
    private bool _isCount = false;
    private int _counter;

    public event Action<int> CountChanged;

    private void Awake()
    {
        _wait = new WaitForSeconds(_time);
    }

    private void OnEnable()
    {
        _actionButton.onClick.AddListener(ChangeCountBool);
    }
    private void OnDisable()
    {
        _actionButton.onClick.RemoveListener(ChangeCountBool);
    }

    private void ChangeCountBool()
    {
        _isCount = !_isCount;

        if (_isCount && _countCoroutine == null)
            _countCoroutine = StartCoroutine(Count());
    }

    private IEnumerator Count()
    {
        while (_isCount)
        {
            _counter++;

            CountChanged?.Invoke(_counter);

            _counter = default;

            yield return _wait;
        }

        _countCoroutine = null;
    }
}
