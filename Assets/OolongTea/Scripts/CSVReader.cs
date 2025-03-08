using UnityEngine;
using System.Collections.Generic;
using System.IO;

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
    public bool isDataLoaded = false;  // �f�[�^���ǂݍ��܂ꂽ���ǂ������Ǘ�������

    // CSV�t�@�C�����t�@�C���p�X�w��œǂݍ��ރ��\�b�h
    public void LoadCSV()
    {
        // CSV�t�@�C���̃p�X���w�� (�t�@�C���p�X�F"Assets/OolongTea/CSVfiletest.csv")
        string filePath = Path.Combine(Application.dataPath, "OolongTea/CSVfiletest.csv");

        // �t�@�C���̑��݂��m�F���ēǂݍ���
        if (File.Exists(filePath))
        {
            string fileContents = File.ReadAllText(filePath);  // �t�@�C�����e��ǂݍ���
            string[] rows = fileContents.Split('\n');  // rows�z��ɍs���Ƃɕۑ�

            for (int i = 1; i < rows.Length; i++)  // CSV�̈�s�ڂ̓w�b�_�[�Ȃ̂�i=1
            {
                string row = rows[i].Trim();  // �]���ȋ󔒂�T��
                if (!string.IsNullOrEmpty(row))  // �󔒁Anull������Ȃ�X�L�b�v
                {
                    string[] columns = row.Split(',');  // ,���Ƃ�columns�z��ɕۑ�

                    CSVData data = new CSVData
                    {
                        id = int.Parse(columns[0]),
                        name = columns[1],
                        text = columns[2]
                    };

                    dataList.Add(data);
                }
            }
            isDataLoaded = true;  // �f�[�^���ǂݍ��܂ꂽ���Ƃ��m�F
        }
        else
        {
            Debug.LogError("�w�肵��CSV�t�@�C����������܂���I");
        }
    }
}
