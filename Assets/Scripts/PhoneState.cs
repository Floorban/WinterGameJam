using UnityEngine;
using System.Collections;

public class PhoneState : MonoBehaviour
{
    public GameObject textBox;
    public bool canPickup;
    [SerializeField]
    private float callTime, waitTime;

    [SerializeField] private AudioClip _ringSound;
    [SerializeField] private AudioSource _audioSource;
    void Start()
    {
        waitTime = Random.Range(2f, 10f);
    }

    void Update()
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            PhoneRing();
        }
    }
    void PhoneRing()
    {
        _audioSource.Play();
        canPickup = true;

        float waitForPickup = 4f;
        waitForPickup -= Time.deltaTime;

        if (waitForPickup <= 0)
        {
            // get a strike
        }
    }
    void OpenTextPanel()
    {

    }
}
