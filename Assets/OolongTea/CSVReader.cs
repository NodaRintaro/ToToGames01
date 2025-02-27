using UnityEngine;
using System.Collections.Generic;
using System.IO; // ファイル操作を行うため

[System.Serializable]
public class CSVData
{
    public int id;
    public string name;
    public string text;
}

public class CSVReader : MonoBehaviour
{
    public List<CSVData> dataList = new List<CSVData>();
    public bool isDataLoaded = false;  // データが読み込まれたかどうかを管理

    // CSVファイルをファイルパス指定で読み込むメソッド
    public void LoadCSV()
    {
        // CSVファイルのパスを指定 (ファイルパス："Assets/OolongTea/CSVfiletest.csv")
        string filePath = Path.Combine(Application.dataPath, "OolongTea/CSVfiletest.csv");

        // ファイルの存在を確認して読み込む
        if (File.Exists(filePath))
        {
            string fileContents = File.ReadAllText(filePath);  // ファイル内容を読み込む
            string[] rows = fileContents.Split('\n');

            for (int i = 1; i < rows.Length; i++)
            {
                string row = rows[i].Trim();
                if (!string.IsNullOrEmpty(row))
                {
                    string[] columns = row.Split(',');

                    CSVData data = new CSVData
                    {
                        id = int.Parse(columns[0]),
                        name = columns[1],
                        text = columns[2]
                    };

                    dataList.Add(data);
                }
            }
            isDataLoaded = true;  // データが読み込まれたことを確認
        }
        else
        {
            Debug.LogError("指定したCSVファイルが見つかりません！");
        }
    }
}
