using System;
using UnityEngine;
using UnityEngine.UI;

public class AlarmSystemScripts : MonoBehaviour
{
    public AudioClip alarmSound;
    public Text messageText;
    public InputField HourInputFind;
    public InputField MinuteInputFind;
    public Button stopAleamButton;//アラーム停止ボタン
    private bool alarmTriggered;
    private int alarmHour;
    private int alarmMinute;
    private GameObject alarmAudioSource;

    private void Start()
    {
        alarmTriggered = false;
        alarmHour = 0;
        alarmMinute = 0;
        stopAleamButton.gameObject.SetActive(false); //アラーム停止ボタンを初回は非表示へ
    }

    // Update is called once per frame
    void Update()
    {
            //現在の時刻を取得
            DateTime currentTime = DateTime.Now;
            //Debug.Log(currentTime.Hour + " == " + alarmHour);
            //Debug.Log(currentTime.Minute + " == " + alarmMinute);
            //指定した時間になったらアラームを鳴らす
            if(!alarmTriggered && currentTime.Hour == alarmHour && currentTime.Minute == alarmMinute)
            {
                PlayAlarm();
            }
    }
    private void PlayAlarm()
    {
        alarmTriggered = true;
        //AudioSource.PlayClipAtPoint(alarmSound,transform.position);
        alarmAudioSource = new GameObject("AlarmSounce");
        AudioSource source = alarmAudioSource.AddComponent<AudioSource>();
        source.clip = alarmSound;
        source.loop = true;
        source.Play();
        
        messageText.text = "アラーム稼働中";
        //アラームがなった後、メッセージを数秒後にクリアする
        Invoke("ClearMessage",1);
        stopAleamButton.gameObject.SetActive(true); //アラーム動作中は表示へ
        //Debug.Log("Helo!World!!");
    }
        private void ClearMessage()
        {
            //alarmTriggered = false;
            messageText.text = "";
            //stopAleamButton.gameObject.SetActive(false); //メッセージ消去後非表示へ
        }
    public void SetAlarm()
    {
        int.TryParse(HourInputFind.text, out alarmHour);
        int.TryParse(MinuteInputFind.text, out alarmMinute);
        messageText.text = "アラームの設定が完了しました";
        // メッセージをクリアする
        Invoke("ClearMessage", 1);
    }
    public void CancelAlarm()
    {
        alarmTriggered = false;
        messageText.text = "アラームを取り消しました";
        stopAleamButton.gameObject.SetActive(false);
        
        // AudioSourceオブジェクトの破壊
        Destroy(alarmAudioSource.gameObject);
        
        // アラームの設定をリセット
        alarmHour = 0;
        alarmMinute = 0;
        
        // メッセージをクリアする
        Invoke("ClearMessage", 1);
    }
}