using UnityEngine;
using TMPro;

public class StrikeCount : MonoBehaviour
{
    private float _strike = 0;
    [SerializeField] private TextMeshProUGUI _strikeText;

    public void AddStrike()
    {
        _strike += 1;
        _strikeText.text = "Strikes: " + _strike;
        Debug.Log(_strike);
        if (_strike >= 3) GameOver();
    }

    void GameOver()
    {
        Debug.Log("Game Over");
        Application.Quit();
    }
}
