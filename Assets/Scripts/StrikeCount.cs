using UnityEngine;
using TMPro;

public class StrikeCount : MonoBehaviour
{
    private float _strike = 0;
    [SerializeField] private PlayerController _player;

    public bool canStrike = true;

    public GameObject Boss;
    public GameObject angryBoss;

    [SerializeField] private GameObject _strike1;
    [SerializeField] private GameObject _strike2;
    [SerializeField] private GameObject _strike3;

    private void Start()
    {
        canStrike = true;
        angryBoss.SetActive(false);
        _strike1.SetActive(false);
        _strike2.SetActive(false);
        _strike3.SetActive(false);

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
            Debug.Log(_strike);
            if (_strike >= 3) GameOver();
        }

        if (_strike == 1) 
        { 
            _strike1.SetActive(true);
        }
        else if (_strike == 2) 
        {
            _strike1.SetActive(false);
            _strike2.SetActive(true);
        }
        else if (_strike == 3)
        {
            _strike2.SetActive(false);
            _strike3.SetActive(true);
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over");
        Application.Quit();
    }
}
