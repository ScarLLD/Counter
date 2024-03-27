using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _CountText;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.CountChanged += OnCountChanged;
    }

    private void OnDisable()
    {
        _counter.CountChanged -= OnCountChanged;
    }

    private void OnCountChanged(int count)
    {
        _CountText.text = count.ToString();
        count = default;
    }
}
