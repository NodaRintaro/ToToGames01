using UnityEngine;
using UnityEngine.UI;

public class DataDisplay : MonoBehaviour
{
    public Text nameText;  // 名前表示
    public Text textText;  // 文表示
    private int currentIndex = 0;  // 現在表示しているデータのインデックス
    public GameObject backgroundName;
    public GameObject backgroundText;

    private CSVReader csvReader; // CSVのデータを読み込むクラス

    void Start()
    {
        // CSVファイルを読み込む
        csvReader = GetComponent<CSVReader>();

        // 最初のデータを表示する準備
        currentIndex = 0;
    }

    void Update()
    {
        // スペースキーを押した場合に次のデータを表示
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextData();
        }
    }

    // 表示を開始する
    public void StartDisplay()
    {
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
            currentIndex = (currentIndex + 1) % csvReader.dataList.Count;
            DisplayCurrentData();
        }
    }
}
