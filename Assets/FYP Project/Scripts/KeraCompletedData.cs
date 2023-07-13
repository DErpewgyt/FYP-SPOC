using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;

public class KeraCompletedData : MonoBehaviour
{
    private string connectionString = "Server=aws.connect.psdb.cloud;Database=spoc;Uid=ek5g4qg03uf2vzt45jza;Pwd=pscale_pw_okLlgZi2QrSCynilZyYm34zDM2BdlDY7hyusEPH6GDX";
    private const string CompletedKeratometerCountKey = "CompleteKeratometerCount";

    public Button submitButton; // Assign the submit button GameObject in the Unity Editor

    private string playerName;
    private string adminNo;
    private bool hasSubmitted;

    private void Start()
    {
        // Add click listener to the submit button
        if (submitButton != null)
        {
            submitButton.onClick.AddListener(HandleSubmitButtonClick);
        }

        // Reset the hasSubmitted flag when the scene is loaded
        hasSubmitted = false;
    }

    public void SetPlayerData(string playerName, string adminNo)
    {
        this.playerName = playerName;
        this.adminNo = adminNo;
    }

    private void HandleSubmitButtonClick()
    {
        if (!hasSubmitted)
        {
            // Execute the method to handle complete keratometer count
            HandleCompleteKeratometerCount(playerName, adminNo);

            // Set the hasSubmitted flag to true to prevent further updates
            hasSubmitted = true;
        }
    }

    public void HandleCompleteKeratometerCount(string playerName, string adminNo)
    {
        // Load CompletedKeratometerCount from the database
        int completedKeratometerCount = LoadCompletedKeratometerCount(playerName, adminNo);

        // Increment the CompletedKeratometerCount
        completedKeratometerCount++;

        // Update the CompletedKeratometerCount in the database
        UpdateCompletedKeratometerCount(playerName, adminNo, completedKeratometerCount);

        // Save the updated CompletedKeratometerCount to PlayerPrefs
        SaveCompletedKeratometerCount(completedKeratometerCount);
    }

    private int LoadCompletedKeratometerCount(string playerName, string adminNo)
    {
        int completedKeratometerCount = 0;

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT CompletedKeratometer FROM student WHERE AdminNo = @adminNo AND StudentName = @studentName";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@adminNo", adminNo);
                command.Parameters.AddWithValue("@studentName", playerName);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        completedKeratometerCount = reader.GetInt32("CompletedKeratometer");
                    }
                }
            }
        }

        return completedKeratometerCount;
    }

    private void UpdateCompletedKeratometerCount(string playerName, string adminNo, int completedKeratometerCount)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = "UPDATE student SET CompletedKeratometer = @completedKeratometer WHERE AdminNo = @adminNo AND StudentName = @studentName";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@completedKeratometer", completedKeratometerCount);
                command.Parameters.AddWithValue("@adminNo", adminNo);
                command.Parameters.AddWithValue("@studentName", playerName);

                command.ExecuteNonQuery();
            }
        }
    }

    private void SaveCompletedKeratometerCount(int completedKeratometerCount)
    {
        PlayerPrefs.SetInt(CompletedKeratometerCountKey, completedKeratometerCount);
    }
}
