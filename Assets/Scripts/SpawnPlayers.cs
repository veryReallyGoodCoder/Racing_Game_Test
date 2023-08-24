using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnPlayers : MonoBehaviour
{

    public GameObject playerOnePrefab;
    public GameObject playerTwoPrefab;
    
    public void SpawnPlayerOne()
    {
        PlayerInput.Instantiate(prefab: playerOnePrefab, playerIndex: 0, controlScheme: "Player1", pairWithDevice: Keyboard.current, splitScreenIndex: 0);
    }

    public void SpawnPlayerTwo()
    {
        PlayerInput.Instantiate(prefab: playerTwoPrefab, playerIndex: 1, controlScheme: "Player2", pairWithDevice: Keyboard.current, splitScreenIndex: 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayerOne();
        SpawnPlayerTwo();

    }

}
