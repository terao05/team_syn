using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class YesNoMsg : MonoBehaviour
{
    public TextMeshProUGUI confirmText;  // ���b�Z�[�W�̃e�L�X�g�\������
    public Button yesButton;             // Yes�{�^��
    public Button noButton;              // No�{�^��
    public GameObject panel;             // ���b�Z�[�W�E�B���h�E�S�̂̃p�l��

    private Action yesAction;            // Yes�����������̃A�N�V����
    private Action noAction;             // No�����������̃A�N�V����

    void Start()
    {
        // Yes/No�{�^���ɃN���b�N�C�x���g��ǉ�
        yesButton.onClick.AddListener(OnYesClick);
        noButton.onClick.AddListener(OnNoClick);

        // ������Ԃł͔�\���ɂ���
        panel.SetActive(false);
    }

    public void ShowMessage(string message, Action onYes, Action onNo, string yesText = "Yes", string noText = "No")
    {
        // ���b�Z�[�W�ƃ{�^���̃e�L�X�g��ݒ�
        confirmText.text = message;
        yesButton.GetComponentInChildren<TextMeshProUGUI>().text = yesText;
        noButton.GetComponentInChildren<TextMeshProUGUI>().text = noText;

        // Yes��No�̃A�N�V������ݒ�
        yesAction = onYes;
        noAction = onNo;

        // ���b�Z�[�W�E�B���h�E��\��
        panel.SetActive(true);
    }

    private void OnYesClick()
    {
        // Yes�A�N�V���������s���ăp�l�������
        yesAction?.Invoke();
        panel.SetActive(false);
    }

    private void OnNoClick()
    {
        // No�A�N�V���������s���ăp�l�������
        noAction?.Invoke();
        panel.SetActive(false);
    }
}
