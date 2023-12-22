using UnityEngine;
using UnityEngine.Events;

public class PhoneState : MonoBehaviour
{
    public GameObject textBox;
    public bool canPickup;
    [SerializeField]
    private float callTime, waitTime;
    private Animator animator;
    [SerializeField] private AudioClip _ringSound;
    [SerializeField] private AudioSource _audioSource;

    public PlayerController player;
    public UnityEvent GiveStrike;
    void Start()
    {
        waitTime = Random.Range(2f, 10f);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            waitTime = Random.Range(2f, 10f);
            PhoneRing();
        }
    }
    void PhoneRing()
    {
        _audioSource.Play();
        canPickup = true;
        animator.SetBool("hasCall", true);

        float waitForPickup = 4f;
        waitForPickup -= Time.deltaTime;

        if (waitForPickup <= 0 && !player.isCalling)
        {
            GiveStrike.Invoke();
        }
    }
    void OpenTextPanel()
    {

    }
}
