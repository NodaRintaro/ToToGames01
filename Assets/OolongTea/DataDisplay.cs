using UnityEngine;
using UnityEngine.UI;

public class DataDisplay : MonoBehaviour
{
    public Text nameText;  // ���O�\��
    public Text textText;  // ���\��
    private int currentIndex = 0;  // ���ݕ\�����Ă���f�[�^�̃C���f�b�N�X
    public GameObject backgroundName;
    public GameObject backgroundText;

    private CSVReader csvReader; // CSV�̃f�[�^��ǂݍ��ރN���X

    void Start()
    {
        // CSV�t�@�C����ǂݍ���
        csvReader = GetComponent<CSVReader>();

        // �ŏ��̃f�[�^��\�����鏀��
        currentIndex = 0;
    }

    void Update()
    {
        // �X�y�[�X�L�[���������ꍇ�Ɏ��̃f�[�^��\��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextData();
        }
    }

    // �\�����J�n����
    public void StartDisplay()
    {
        backgroundName.SetActive(true);
        backgroundText.SetActive(true);

        // CSV�f�[�^�̓ǂݍ��݂��J�n
        csvReader.LoadCSV();

        // �f�[�^���ǂݍ��܂ꂽ��ŏ��̃f�[�^��\��
        if (csvReader.isDataLoaded)
        {
            DisplayCurrentData();  // �ŏ��̃f�[�^��\��
        }
        else
        {
            Debug.LogError("CSV�f�[�^�̓ǂݍ��݂Ɏ��s���܂����I");
        }
    }

    // ���݂̃C���f�b�N�X�̃f�[�^��\��
    void DisplayCurrentData()
    {
        if (csvReader.dataList.Count > 0)
        {
            nameText.text = csvReader.dataList[currentIndex].name;
            textText.text = csvReader.dataList[currentIndex].text;
        }
    }

    // ���̃f�[�^��\������
    void DisplayNextData()
    {
        if (csvReader.dataList.Count > 0)
        {
            // �C���f�b�N�X�����ɐi�߂�
            currentIndex = (currentIndex + 1) % csvReader.dataList.Count;
            DisplayCurrentData();
        }
    }
}
