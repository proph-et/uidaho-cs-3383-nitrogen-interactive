using UnityEngine;

namespace src.team_lead_1.scripts
{
    public class UIManager : MonoBehaviour
    {
        public TMPTextBox moneyTMPTextBox;
        public TMPTextBox itemsTMPTextBox;
        public int money = 50;
        public int numItems = 10;

        public void InitializeUI()
        {
            string newMoneyValue = "Money: " + money;
            moneyTMPTextBox.ChangeTMPText(newMoneyValue);

            string newItemNum = "Items: " + numItems;
            itemsTMPTextBox.ChangeTMPText(newItemNum);
        }

        public void BuyItem(int value)
        {
            if (money >= value)
            {
                money -= value;
                string newMoneyValue = "Money: " + money;
                moneyTMPTextBox.ChangeTMPText(newMoneyValue);

                numItems++;
                string newItemNum = "Items: " + numItems;
                itemsTMPTextBox.ChangeTMPText(newItemNum);
            }
            else
            {
                Debug.Log("Not enough money");
            }
        }

        public void SellItem(int value)
        {
            if (numItems > 0)
            {
                money += value;
                string newMoneyValue = "Money: " + money;
                moneyTMPTextBox.ChangeTMPText(newMoneyValue);

                numItems--;
                string newItemNum = "Items: " + numItems;
                itemsTMPTextBox.ChangeTMPText(newItemNum);
            }
            else
            {
                Debug.Log("Not enough items");
            }
        }
    }
}