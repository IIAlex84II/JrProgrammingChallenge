using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NameManager : MonoBehaviour
{
    public static NameManager Instance;
    public string BestScoreName,Name;
    public int BestScore;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();

    }

    // Update is called once per frame
    [System.Serializable]
    class SaveData
    {
        public string BestScoreName;
        public int BestScore;
    }
    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.BestScoreName = BestScoreName;
        data.BestScore = BestScore;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestScoreName = data.BestScoreName;
            BestScore = data.BestScore;
        }
    }
}
