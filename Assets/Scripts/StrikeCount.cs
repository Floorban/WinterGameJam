using UnityEngine;
using TMPro;

public class StrikeCount : MonoBehaviour
{
    private float _strike = 0;
    [SerializeField] private TextMeshProUGUI _strikeText;
    [SerializeField] private PlayerController _player;

    public bool canStrike = true;

    public GameObject Boss;
    public GameObject angryBoss;

    private void Start()
    {
        canStrike = true;
        angryBoss.SetActive(false);
    }
    public void AddStrike()
    {
        angryBoss.SetActive(true);
        Boss.SetActive(false);
        if (canStrike) 
        {
            canStrike = false;
            _player.isAwake = true;
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
