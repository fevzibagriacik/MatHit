using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Hit : MonoBehaviour
{
    public Text number1;
    public Text number2;
    public Text process;
    public Text txtTarget1;
    public Text txtTarget2;
    public Text txtTarget3;
    public Text coinScore;

    private int n1;
    private int n2;
    private char operation;
    private int result;
    private int targetNumber1;
    private int targetNumber2;
    private int targetNumber3;
    private int score = 0;
    private int maxNumber = 11;
    private int minNumber = 1;
    void Start()
    {
        coinScore.text = score.ToString();
    }

    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("TargetBox"))
        {
            applyProcess();
        }
    }

    public void generateNumber()
    {
        n1 = Random.Range(minNumber, maxNumber);
        n2 = Random.Range(minNumber, maxNumber);

        int rd = Random.Range(0, 3);
        if (rd == 0)
        {
            operationOptions(result, targetNumber1, targetNumber2, targetNumber3, txtTarget1, txtTarget2, txtTarget3);
        }
        else if (rd == 1)
        {
            operationOptions(result, targetNumber2, targetNumber1, targetNumber3, txtTarget2, txtTarget1, txtTarget3);
        }
        else
        {
            operationOptions(result, targetNumber3, targetNumber1, targetNumber2, txtTarget3, txtTarget1, txtTarget2);
        }
    }

    public void generateOperation()
    {
        int operationOption = Random.Range(0, 4);
        switch (operationOption)
        {
            case 0:
                operation = '+';
                break;
            case 1:
                operation = '-';
                break;
            case 2:
                operation = '*';
                break;
            case 3:
                operation = '/';
                break;
        }
    }

    public void applyProcess()
    {
        generateOperation();
        process.text = operation.ToString();

        if (operation.Equals('+'))
        {
            generateNumber();
            number1.text = n1.ToString();
            number2.text = n2.ToString();
            txtTarget1.text = targetNumber1.ToString();
            txtTarget2.text = targetNumber2.ToString();
            txtTarget3.text = targetNumber3.ToString();
        }
        else if (operation.Equals('-'))
        {
            while (result < 0)
            {
                generateNumber();
            }
            
            number1.text = n1.ToString();
            number2.text = n2.ToString();
            txtTarget1.text = targetNumber1.ToString();
            txtTarget2.text = targetNumber2.ToString();
            txtTarget3.text = targetNumber3.ToString();
        }
        else if (operation.Equals('*'))
        {
            number1.text = n1.ToString();
            number2.text = n2.ToString();
            txtTarget1.text = targetNumber1.ToString();
            txtTarget2.text = targetNumber2.ToString();
            txtTarget3.text = targetNumber3.ToString();

        }
        else if (operation.Equals('/'))
        {
            while (n1 % n2 != 0 && n2 != 0)
            {
                generateNumber() ;
            }

            number1.text = n1.ToString();
            number2.text = n2.ToString();
            txtTarget1.text = targetNumber1.ToString();
            txtTarget2.text = targetNumber2.ToString();
            txtTarget3.text = targetNumber3.ToString();
        }
        else
        {
            Debug.Log("Error");
        }

        maxNumber++;
    }

    public void operationOptions(int result, int targetNumber1, int targetNumber2, int targetNumber3, Text txtTarget1, Text txtTarget2, Text txtTarget3)
    {
        int option = Random.Range(0, 2);
        int placeOption = Random.Range(0, 3);
        targetNumber1 = result;

        switch (operation)
        {
            case '+':
                result = n1 + n2;
                if (option == 0)
                {                 
                    if(placeOption == 0)
                    {
                        targetNumber2 = targetNumber1++;
                        targetNumber3 = targetNumber2++;
                    }
                    else if(placeOption == 1)
                    {
                        targetNumber2 = targetNumber1--;
                        targetNumber3 = targetNumber1++;
                    }
                    else
                    {
                        targetNumber2 = targetNumber1--;
                        targetNumber3 = targetNumber2--;
                    }
                }
                else
                {
                    if(placeOption == 0)
                    {
                        targetNumber2 = targetNumber1 + 10;
                        targetNumber3 = targetNumber2 + 10;
                    }
                    else if(placeOption == 1)
                    {
                        targetNumber2 = targetNumber1 - 10;
                        targetNumber3 = targetNumber1 + 10;
                    }
                    else
                    {
                        targetNumber2 = targetNumber1 - 10;
                        targetNumber3 = targetNumber2 - 10;
                    }
                }
                break;
            case '-':
                result = n1 - n2;
                if (option == 0)
                {

                    if (placeOption == 0)
                    {
                        targetNumber2 = targetNumber1++;
                        targetNumber3 = targetNumber2++;
                    }
                    else if (placeOption == 1)
                    {
                        targetNumber2 = targetNumber1--;
                        targetNumber3 = targetNumber1++;
                    }
                    else
                    {
                        targetNumber2 = targetNumber1--;
                        targetNumber3 = targetNumber2--;
                    }
                }
                else
                {
                    if (placeOption == 0)
                    {
                        targetNumber2 = targetNumber1 + 10;
                        targetNumber3 = targetNumber2 + 10;
                    }
                    else if (placeOption == 1)
                    {
                        targetNumber2 = targetNumber1 - 10;
                        targetNumber3 = targetNumber1 + 10;
                    }
                    else
                    {
                        targetNumber2 = targetNumber1 - 10;
                        targetNumber3 = targetNumber2 - 10;
                    }
                }
                break;
            case '*':
                result = n1 * n2;
                if (option == 0)
                {
                    if(placeOption == 0)
                    {
                        targetNumber2 = targetNumber1 * 2;
                        targetNumber3 *= targetNumber1 * 3;
                    }
                    else if(placeOption == 1)
                    {
                        targetNumber2 = targetNumber1 * 2;
                        targetNumber3 = targetNumber1 / 2;
                    }
                    else
                    {
                        targetNumber2 = targetNumber1 / 2;
                        targetNumber3 = targetNumber2 / 3;
                    }
                }
                else
                {
                    if(placeOption == 1)
                    {
                        targetNumber2 = targetNumber1 + 10;
                        targetNumber3 = targetNumber2 + 10;
                    }
                    else if(placeOption == 2)
                    {
                        targetNumber2 = targetNumber1 - 10;
                        targetNumber3 = targetNumber1 + 10;
                    }
                    else
                    {
                        targetNumber2 = targetNumber1 - 10;
                        targetNumber3 = targetNumber2 - 10;
                    }
                }
                break;
            case '/':
                result = n1 / n2;
                if (option == 0)
                {
                    if(placeOption == 1)
                    {
                        targetNumber2 = targetNumber1++;
                        targetNumber3 = targetNumber2++;
                    }
                    else if(placeOption == 2)
                    {
                        targetNumber2 = targetNumber1--;
                        targetNumber3 = targetNumber1++;
                    }
                    else
                    {
                        targetNumber2 = targetNumber1--;
                        targetNumber3 = targetNumber2--;
                    }
                }
                else
                {
                    if (placeOption == 0)
                    {
                        targetNumber2 = targetNumber1 + 2;
                        targetNumber3 = targetNumber2 + 2;
                    }
                    else if(placeOption == 1)
                    {
                        targetNumber2 = targetNumber1 + 2;
                        targetNumber3 = targetNumber1 - 2;
                    }
                    else
                    {
                        targetNumber2 = targetNumber1 - 2;
                        targetNumber3 = targetNumber2 - 2;
                    }
                }
                break;
        }
    }
}
