using UnityEngine;
using UnityEngine.UI;

public class DataDisplay : MonoBehaviour
{
    public Text nameText;  // 名前表示
    public Text textText;  // 文表示
    private int currentIndex = 0;  // 現在表示しているデータのインデックス
    public GameObject backgroundName;  // 名前の後ろにある背景
    public GameObject backgroundText;  // 文の後ろにある背景

    private CSVReader csvReader; // CSVのデータを読み込むクラス

    void Start()
    {
        // CSVファイルを読み込む
        csvReader = GetComponent<CSVReader>();
    }

    void Update()
    {
        // スペースキーを押した場合に次のデータを表示
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (currentIndex != csvReader.dataList.Count - 1)
            {
                DisplayNextData();
            }
            else
            {
                backgroundName.SetActive(false);
                backgroundText.SetActive(false);
                currentIndex = 0;
            }
        }
    }

    // 表示を開始する
    public void StartDisplay()
    {
        // 背景表示
        backgroundName.SetActive(true);
        backgroundText.SetActive(true);

        // CSVデータの読み込みを開始
        csvReader.LoadCSV();

        // データが読み込まれたら最初のデータを表示
        if (csvReader.isDataLoaded)
        {
            DisplayCurrentData();  // 最初のデータを表示
        }
        else
        {
            Debug.LogError("CSVデータの読み込みに失敗しました！");
        }
    }

    // 現在のインデックスのデータを表示
    void DisplayCurrentData()
    {
        if (csvReader.dataList.Count > 0)
        {
            nameText.text = csvReader.dataList[currentIndex].name;
            textText.text = csvReader.dataList[currentIndex].text;
        }
    }

    // 次のデータを表示する
    void DisplayNextData()
    {
        if (csvReader.dataList.Count > 0)
        {
            // インデックスを次に進める
            currentIndex ++;
            DisplayCurrentData();
        }
    }
}
