using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private bool isAwake, isCalling;
  
    public GameObject sleepMask;
    public Image fatigueBar;

    [SerializeField]
    private float currentState;

    public PhoneState phoneState;
    void Start()
    {
        fatigueBar.fillAmount = 50f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isCalling)
        {
            isAwake = !isAwake;
        }

        if (Input.GetMouseButtonDown(0) && isAwake)
        {
            if (phoneState.canPickup)
            {
                isCalling = !isCalling;
            }
        }

        FillFatigueBar();

        if (isAwake)
        {
            IncreaseFatigueBar();
            sleepMask.SetActive(true);
        }
        else
        {
            DecreaseFatigueBar();
            sleepMask.SetActive(false);
        }
    }
    void FillFatigueBar()
    {
        fatigueBar.fillAmount = currentState / 100;
    }
    void IncreaseFatigueBar()
    {
        currentState += 1f * Time.deltaTime;
    }
    void DecreaseFatigueBar()
    {
        currentState -= 2f * Time.deltaTime;
    }
}
