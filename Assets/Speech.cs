using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using System.Linq;
using System.Text.RegularExpressions;

/*
로직 : 유저가 특정 문장을 말하면, 그 문장과 매칭되는 문장이 google translate url로 전달된다.
그 뒤, 그 문장은 음성파일로 전환되고(TTS) 그 음성파일을 다시 AudioSource 객체가 받아
유니티에서 재생시킨다. 
*/

public class Speech : MonoBehaviour
{

    public AudioSource _audio2;//url을 통하여 재생되는 음성을 저장할 객체

    public Text NPC_sentence, User_sentence;
    KeywordRecognizer keywordRecognizer;

    //Dictionary<string, System.Action> keyword = new Dictionary<string, System.Action>();//우리가 말하게 될 단어들의 사전

    protected string word = "";
    public string[] keywords = new string[] { "Nice to meet you",
    "What is your name?", "What is my name?", "Where are you from?"};

    // Use this for initialization
    void Start()
    {
        _audio2 = gameObject.GetComponent<AudioSource>();
        NPC_sentence.text = " ";
        User_sentence.text = " ";

        //keyword.Add("Nice to meet you", () =>//"go"를 인식하면 아래의 함수를 호출
        //{
        //    GoCalled();
        //});
        //if(keyword.Equals("Nice to meet you"))
        //{
        //    GoCalled();
        //}

        keywordRecognizer = new KeywordRecognizer(keywords);
        keywordRecognizer.OnPhraseRecognized += keywordRecognizerOnPhraseRecognized;
        keywordRecognizer.Start();
    }

    void GoCalled()
    {
        NPC_sentence.text = "Nice to meet you, too.";
        StartCoroutine(DownloadTheAudio());//DownloadTheAudio 실행
    }

    //args.text는 우리가 말한 것을 변환한것(STT)
    void keywordRecognizerOnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        word = args.text;
        User_sentence.text = word;

        if (word.Equals("Nice to meet you"))
        {
            NPC_sentence.text = "Nice to meet you, too.";
            StartCoroutine(DownloadTheAudio());//DownloadTheAudio 실행
        }
        else if (word.Equals("What is your name?"))
        {
            NPC_sentence.text = "My name is Contana";
            StartCoroutine(DownloadTheAudio());//DownloadTheAudio 실행
        }
        else if (word.Equals("What is my name?"))
        {
            NPC_sentence.text = "Your name is Jinwon Kim. You made me. Thanks";
            StartCoroutine(DownloadTheAudio());//DownloadTheAudio 실행
        }
        else if (word.Equals("Where are you from?"))
        {
            NPC_sentence.text = "I'm from Korea";
            StartCoroutine(DownloadTheAudio());//DownloadTheAudio 실행
        }
        else if (word.Equals("Hi"))
        {
            NPC_sentence.text = "Hi. How are you?";
            StartCoroutine(DownloadTheAudio());//DownloadTheAudio 실행
        }
        else
        {
            NPC_sentence.text = "I'm sorry";
            StartCoroutine(DownloadTheAudio());//DownloadTheAudio 실행
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DownloadTheAudio()
    {
        Regex rgx = new Regex("\\s+");//space때문에 에러발생을 해결
        string result = rgx.Replace(NPC_sentence.text, "+");

        string url =
            "http://translate.google.com/translate_tts?ie=UTF-8&total=1&idx=0&textlen=32&client=tw-ob&q="
            + result
            + "&tl=En-gb";
        WWW www = new WWW(url);
        yield return www;
        _audio2.clip = www.GetAudioClip(false, true, AudioType.MPEG);
        _audio2.Play();
    }

}
