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

    public GameObject user;
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
                canPickup = true;
                PhoneRing();
            }
        }
    }
    void PhoneRing()
    {
       
        //_audioSource.Play();
    
        animator.SetBool("hasCall", true);
        WaitPickUp();

        if (player.isCalling)
        {
            canPickup = false;
            animator.SetBool("hasCall", false);
            waitTime = Random.Range(2f, 10f);
        }

    }
    void WaitPickUp()
    {
        if (canPickup)
        {
 
            waitForPickup = Random.Range(3f, 5f);
       
        }
        waitForPickup -= Time.deltaTime;
        if (waitForPickup <= 0 && !player.isCalling)
        {
            StartCoroutine(BossBubble());
            GiveStrike.Invoke();
            animator.SetBool("hasCall", false);
            waitTime = Random.Range(2f, 10f);
            
            canCall = true;
        }
    }


    IEnumerator BossBubble()
    {
        _bossBubble.SetActive(true);
        yield return new WaitForSeconds(1f);
        _bossBubble.SetActive(false);
    }
}
