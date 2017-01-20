using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowPlayerStats : MonoBehaviour {

    [SerializeField]private Text _playerStatNames;
    [SerializeField]private Text _playerStats;
    [SerializeField]private Image _xpBar;
    [SerializeField]private Text _xpText;
    [SerializeField]private Text _goldAmount;

    void Start()
    {
        _playerStatNames = _playerStatNames.GetComponent<Text>();
        _playerStats = _playerStats.GetComponent<Text>();
        _xpBar = _xpBar.GetComponent<Image>();
        _xpText = _xpText.GetComponent<Text>();
        _goldAmount = _goldAmount.GetComponent<Text>();
        //_characterIndex = 0;
    }

    void Update()
    {
        PlayerStats();
        XpBar();
        GoldAmount();
    }

    public void PlayerStats()
    {
        // \t = tab \n = new line i used multiple \t's to line out the text
        _playerStatNames.text = "Name" + "\n" +
                                "Level" + "\n" +
                                "Strength" + "\n" +
                                "Dexterity" + "\n" +
                                "Intellect " + "\n" +
                                "Vitality" + "\n" +
                                "Spirit" + "\n";

        _playerStats.text = PlayerInformation.Name + "\n" +
                            PlayerInformation.Level + "\n" +
                            PlayerInformation.Strength + "\n" +
                            PlayerInformation.Dexterity + "\n" +
                            PlayerInformation.Intellect + "\n" +
                            PlayerInformation.Vitality + "\n" +
                            PlayerInformation.Spirit;
    }

    public void GoldAmount()
    {
        _goldAmount.text = "Gold : " + PlayerInformation.Gold.ToString();
    }

    public void XpBar()
    {
        _xpBar.fillAmount = PlayerInformation.CurrentExperience / PlayerInformation.RequiredExperience;
        _xpText.text = (float)PlayerInformation.CurrentExperience + " / " + PlayerInformation.RequiredExperience + " XP";
    }
}
