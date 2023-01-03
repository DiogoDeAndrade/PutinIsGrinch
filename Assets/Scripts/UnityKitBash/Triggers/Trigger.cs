using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField, TextArea]
    public      string      description;
    [SerializeField]
    public      bool        enableTrigger = true;
    [SerializeField]
    protected UnityEvent    triggers;

    public void Action_DestroyObject()
    {
        Destroy(gameObject);
    }

    public void Action_RemoveParent(Transform t)
    {
        t.SetParent(null);
    }

    public void Action_Respawn(float time)
    {
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        if (levelManager)
        {
            levelManager.Respawn(time);
        }
    }

    public void Action_ChangeScene(string sceneName)
    {
        int index = sceneName.IndexOf(':');
        if (index != -1)
        {
            float time = float.Parse(sceneName.Substring(index + 1));
            StartCoroutine(Action_ChangeSceneDelayedCR(sceneName.Substring(0, index), time));
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    IEnumerator Action_ChangeSceneDelayedCR(string sceneName, float time)
    {
        yield return new WaitForSeconds(time);

        Action_ChangeScene(sceneName);
    }

    public void Action_EnableTrigger() => enableTrigger = true;
    public void Action_DisableTrigger() => enableTrigger = false;

    public void Action_PlaySound(AudioClip clip)
    {
        float volume = Random.Range(0.8f, 1.0f);
        float pitch = Random.Range(0.8f, 1.2f);

        SoundManager.PlaySound(clip, volume, pitch);
    }

    public virtual void ExecuteTrigger()
    {
        if (!enableTrigger) return;

        triggers.Invoke();
    }

}
