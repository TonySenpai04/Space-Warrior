using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private string skillDescription;
    [SerializeField] private GameObject descriptionPanel;
    [SerializeField] private Text descriptionText;
    [SerializeField] private Image skillIcon;
    [SerializeField] private SkillBase skillBase;
    private bool isPressed = false;
    private void Start()
    {
        if (skillBase != null)
            skillIcon.sprite = skillBase.icon;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Khi nút được ấn giữ, set isPressed thành true
        isPressed = true;
        // Khi ấn giữ, hiển thị mô tả của kỹ năng
        ShowSkillDescription();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Khi nhả nút ra, set isPressed thành false
        isPressed = false;
        // Khi nhả nút ra, ẩn mô tả của kỹ năng
        HideSkillDescription();
    }

    void ShowSkillDescription()
    {
        // Hiển thị panel mô tả
        descriptionPanel.SetActive(true);
        // Thiết lập văn bản mô tả
        descriptionText.text = skillDescription;
    }

    void HideSkillDescription()
    {
        // Ẩn panel mô tả
        descriptionPanel.SetActive(false);
    }
}
