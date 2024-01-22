using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager mainManager { get; private set; }

    public Color TeamColor;

	void Awake()
    {
        if (mainManager != null)
        {
            Destroy(this.gameObject);
            return;
        }
        else 
        {
			mainManager = this;
            DontDestroyOnLoad(this.gameObject);
        }
        LoadColor();
	}

    void Update()
    {
        TeamColor = ColorPicker.SelectedColor;
    }

	[System.Serializable]
	class SaveData
	{
		public Color TeamColor = MainManager.mainManager.TeamColor;
	}

	public void SaveColor()
    { 
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        Debug.Log(path);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            TeamColor = data.TeamColor;
        }
	}
}

