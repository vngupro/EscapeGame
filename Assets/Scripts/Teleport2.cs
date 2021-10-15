using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
[RequireComponent(typeof(BoxCollider))]
public class Teleport2 : MonoBehaviour
{
    public GameObject interact;
    public GameObject spawnPoint;
    public FadeScript fade;
    private PlayerController controller;
    private bool canTeleport = false;
    private void Awake()
    {
        interact.SetActive(false);
    }

    [Button]
    public void Init()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }
    private void Start()
    {
        controller = PlayerController.Instance;

        controller.OnInteract += Teleportation2;
    }

    private void OnDisable()
    {
        controller.OnInteract -= Teleportation2;
    }
    public void Teleportation2()
    {
        if (canTeleport)
        {
            StartCoroutine(OnTeleport(0, 1));
        }
    }

    private IEnumerator OnTeleport(int min, int max)
    {
        SoundManager.Instance.PlaySound("Door");
        float timer = 0;
        while (timer <= fade.fadeTime)
        {
            float ratio = timer / fade.fadeTime;
            timer += Time.deltaTime;
            fade.canvas.alpha = Mathf.Lerp(min, max, fade.curve.Evaluate(ratio));
            yield return null;
        }
        fade.canvas.alpha = max;

        controller.gameObject.transform.position = spawnPoint.transform.position;
        yield return new WaitForSeconds(0.1f);
        timer = 0;
        while (timer <= fade.fadeTime)
        {
            float ratio = timer / fade.fadeTime;
            timer += Time.deltaTime;
            fade.canvas.alpha = Mathf.Lerp(max, min, fade.curve.Evaluate(ratio));
            yield return null;
        }
        fade.canvas.alpha = min;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interact.SetActive(true);
            canTeleport = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interact.SetActive(false);
            canTeleport = false;
        }
    }


}
