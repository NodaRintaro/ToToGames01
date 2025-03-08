using UnityEngine;
using UnityEngine.UI;

public class DataDisplay : MonoBehaviour
{
    public Text nameText;  // ���O�\��
    public Text textText;  // ���\��
    private int currentIndex = 0;  // ���ݕ\�����Ă���f�[�^�̃C���f�b�N�X
    public GameObject backgroundName;  // ���O�̌��ɂ���w�i
    public GameObject backgroundText;  // ���̌��ɂ���w�i

    private CSVReader csvReader; // CSV�̃f�[�^��ǂݍ��ރN���X

    void Start()
    {
        // CSV�t�@�C����ǂݍ���
        csvReader = GetComponent<CSVReader>();
    }

    void Update()
    {
        // �X�y�[�X�L�[���������ꍇ�Ɏ��̃f�[�^��\��
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

    // �\�����J�n����
    public void StartDisplay()
    {
        // �w�i�\��
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
            currentIndex ++;
            DisplayCurrentData();
        }
    }
}
