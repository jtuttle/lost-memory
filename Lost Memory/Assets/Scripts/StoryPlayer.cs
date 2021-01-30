using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StoryPlayer : MonoBehaviour
{
    public UnityEngine.UI.Text Subtitle;

    public UnityEvent StoryCompleteEvent = new UnityEvent();

    private StoryObject _target;
    private int _index;

    void Start()
    {
        _index = 0;
    }

    void Update()
    {
        if(!_target) { return; }

        if(_index >= _target.Subtitles.Count) { return; }
        
        if(_target.GetComponent<AudioSource>().time > _target.SubtitleStartSeconds[_index])
        {
            Subtitle.GetComponent<Text>().text = _target.Subtitles[_index];
            _index++;
        }
    }

    public void PlayStory(StoryObject target)
    {
        _target = target;
        _index = 0;

        AudioSource sound = target.GetComponent<AudioSource>();
        sound.Play();
        StartCoroutine(WaitForSound(sound));
    }

    private IEnumerator WaitForSound(AudioSource sound)
    {
        yield return new WaitUntil(() => sound.isPlaying == false);
        
        OnSoundComplete();
    }

    private void OnSoundComplete()
    {
        Subtitle.GetComponent<Text>().text = "";
        
        _target = null;
        _index = 0;

        StoryCompleteEvent.Invoke();
    }
}
