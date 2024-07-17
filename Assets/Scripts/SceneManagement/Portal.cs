using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour, IPlayerTriggerable
{
    [SerializeField] int sceneToLoad = -1;
    [SerializeField] DestinationIdentifer destinationPortal;
    [SerializeField] Transform spawnPoint;

    PlayerController player;
    public void OnPlayerTriggered(PlayerController player)
    {
        this.player = player;
        StartCoroutine(SwitchScene());
    }
    Fader fader;

    private void Start()
    {
        fader = FindAnyObjectByType<Fader>();
    }

    IEnumerator SwitchScene()
    {
        DontDestroyOnLoad(gameObject);

        GameController.Instance.PauseGame(true);
        yield return fader.FadeIn(0.5f);

        yield return SceneManager.LoadSceneAsync(sceneToLoad);

        Portal[] portals = FindObjectsOfType<Portal>();
        Portal destPortal = null;

        foreach (var portal in portals)
        {
            if (portal != this && portal.destinationPortal == this.destinationPortal)
            {
                destPortal = portal;
                break;
            }
        }

        yield return fader.FadeOut(0.5f);
        GameController.Instance.PauseGame(false);

        if (destPortal != null)
        {
            player.Character.SetPositionAndSnapToTile(destPortal.SpawnPoint.position);
            Destroy(gameObject);
        }
        else
        {
            Debug.LogError("No destination portal found!");
        }
    }

    public Transform SpawnPoint => spawnPoint;

}

public enum DestinationIdentifer { A, B, C, D, E}
