using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class PhoneState : MonoBehaviour
{
    public GameObject textBox;
    public bool canPickup;
    public bool canCall;
    [SerializeField]
    private float waitTime, waitForPickup;
    private Animator animator;
    [SerializeField] private AudioClip _ringSound;
    [SerializeField] private AudioSource _audioSource;

    public PlayerController player;
    public UnityEvent GiveStrike;

    [SerializeField] private GameObject _bossBubble;
    void Start()
    {
        waitTime = Random.Range(2f, 10f);
        animator = GetComponent<Animator>();
        canCall = true;
        _bossBubble.SetActive(false);
    }

    void Update()
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            if (canCall)
            {
                PhoneRing();
            }
        }
    }
    void PhoneRing()
    {
        WaitPickUp();
        //_audioSource.Play();
        canPickup = true;
        animator.SetBool("hasCall", true);

        if (player.isCalling)
        {
            OpenTextPanel();
            canPickup = false;
            canCall = false;
        }

    }
    void WaitPickUp()
    {
        if (canPickup)
        {
            waitForPickup = Random.Range(3f, 5f);
            waitForPickup -= Time.deltaTime;
        }
        if (waitForPickup <= 0 && !player.isCalling)
        {
            StartCoroutine(BossBubble());
            GiveStrike.Invoke();
            animator.SetBool("hasCall", false);
            waitTime = Random.Range(2f, 10f);
            canPickup = false;
            canCall = true;
        }
    }
    void OpenTextPanel()
    {
        animator.SetBool("hasCall", false);
        Debug.Log("choose file");
    }

    IEnumerator BossBubble()
    {
        _bossBubble.SetActive(true);
        yield return new WaitForSeconds(1f);
        _bossBubble.SetActive(false);
    }
}
