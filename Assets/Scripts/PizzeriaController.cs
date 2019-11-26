using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzeriaController : MonoBehaviour
{
    public GameObject[] destinations;
    public GameObject pizzaPrefab;
    private GameObject spawnPoint;

    public void MakeAPizza() {
        if (spawnPoint == null) {
            foreach (Transform child in transform) {
                if (child.CompareTag("PizzaSpawnPoint")) {
                    spawnPoint = child.gameObject;
                }
            }
        }

        PizzaController pizza = Instantiate(pizzaPrefab, spawnPoint.transform.position, Quaternion.identity).GetComponent<PizzaController>();
        GameObject obj = destinations[Random.Range(0, destinations.Length)];
        pizza.destination = obj;
        Debug.Log(pizza);
    }

    // Start is called before the first frame update
    void Start() {
        foreach (Transform child in transform) {
            if (child.CompareTag("PizzaSpawnPoint")) {
                spawnPoint = child.gameObject;
            }
        }

        foreach (GameObject obj in destinations) {
            obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
