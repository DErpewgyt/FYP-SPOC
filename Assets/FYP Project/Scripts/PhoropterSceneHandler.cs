using UnityEngine;
using MySql.Data.MySqlClient;

public class PhoropterSceneHandler : MonoBehaviour
{
    private string connectionString = "Server=aws.connect.psdb.cloud;Database=spoc;Uid=ek5g4qg03uf2vzt45jza;Pwd=pscale_pw_okLlgZi2QrSCynilZyYm34zDM2BdlDY7hyusEPH6GDX";
    private const string AttemptPhoropterCountKey = "AttemptPhoropterCount";

    public void HandleAttemptPhoropterCount(string playerName, string adminNo)
    {
        // Load attemptKeratometerCount from the database
        int attemptPhoropterCount = LoadAttemptPhoropterCount(playerName, adminNo);

        // Increment the attemptKeratometerCount
        attemptPhoropterCount++;

        // Update the attemptKeratometerCount in the database
        UpdateAttemptPhoropterCount(playerName, adminNo, attemptPhoropterCount);

        // Save the updated attemptKeratometerCount to PlayerPrefs
        SaveAttemptPhoropterCount(attemptPhoropterCount);
    }

    private int LoadAttemptPhoropterCount(string playerName, string adminNo)
    {
        int attemptPhoropterCount = 0;

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT AttemptPhoropter FROM student WHERE AdminNo = @adminNo AND StudentName = @studentName";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@adminNo", adminNo);
                command.Parameters.AddWithValue("@studentName", playerName);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        attemptPhoropterCount = reader.GetInt32("AttemptPhoropter");
                    }
                }
            }
        }

        return attemptPhoropterCount;
    }

  private void UpdateAttemptPhoropterCount(string playerName, string adminNo, int attemptPhoropterCount)
{
    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        connection.Open();

        string query = "UPDATE student SET AttemptPhoropter = AttemptPhoropter + 1 WHERE AdminNo = @adminNo AND StudentName = @studentName";

        using (MySqlCommand command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@adminNo", adminNo);
            command.Parameters.AddWithValue("@studentName", playerName);
            Debug.Log("Phoropter now is " + attemptPhoropterCount);
            command.ExecuteNonQuery();
        }
    }
}


    private void SaveAttemptPhoropterCount(int attemptPhoropterCount)
    {
        PlayerPrefs.SetInt(AttemptPhoropterCountKey, attemptPhoropterCount);
    }
}
