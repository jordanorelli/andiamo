using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudController : MonoBehaviour
{

    public TextMeshProUGUI scoreText;

    public GameObject destinationBox;
    public TextMeshProUGUI destinationText;

    public GameObject directionsBox;
    public TextMeshProUGUI directionsText;

    public GameObject locationBox;
    public TextMeshProUGUI locationText;

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update() {
        scoreText.text = player.score.ToString();
        if (player.destination) {
            destinationText.text = player.destination.Address;
            destinationBox.SetActive(true);
            directionsText.text = player.destination.Directions;
            directionsBox.SetActive(true);
        } else {
            destinationBox.SetActive(false);
            directionsBox.SetActive(false);
        }

        if (player.location != "") {
            locationText.text = player.location;
        } else {
            locationText.text = "(lost)";
        }
    }
}
