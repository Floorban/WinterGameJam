using UnityEngine;
using TMPro;

public class ClientService : MonoBehaviour
{
    public string name;
    public int id;
    public TextMeshProUGUI fileName;

    private void Start()
    {
        id = Random.Range(1, 11);

        if (id == 1) name = "Mara";
        if (id == 2) name = "Owen";
        if (id == 3) name = "Niklas";
        if (id == 4) name = "John";
        if (id == 5) name = "Manon";
        if (id == 6) name = "Stathis";
        if (id == 7) name = "Max";
        if (id == 8) name = "Yashvi";
        if (id == 9) name = "Lucas";
        if (id == 10) name = "Kris";

    }
    private void Update()
    {
        fileName.text = name;
    }
}

