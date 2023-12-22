using UnityEngine;
using TMPro;

public class StrikeCount : MonoBehaviour
{
    private float _strike = 0;
    [SerializeField] private TextMeshProUGUI _strikeText;

    public bool _canStrike = true;

    private void Start()
    {
        _canStrike = true;
    }
    public void AddStrike()
    {
        if (_canStrike) 
        {
            _canStrike = false;
            _strike += 1;
            _strikeText.text = "Strikes: " + _strike;
            Debug.Log(_strike);
            if (_strike >= 3) GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over");
        Application.Quit();
    }
}
