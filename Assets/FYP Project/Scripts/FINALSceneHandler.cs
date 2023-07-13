using UnityEngine;
using MySql.Data.MySqlClient;

public class FINALSceneHandler : MonoBehaviour
{
    private string connectionString = "Server=aws.connect.psdb.cloud;Database=spoc;Uid=ek5g4qg03uf2vzt45jza;Pwd=pscale_pw_okLlgZi2QrSCynilZyYm34zDM2BdlDY7hyusEPH6GDX";
    private const string AttemptKeratometerCountKey = "AttemptKeratometerCount";

    public void HandleAttemptKeratometerCount(string playerName, string adminNo)
    {
        // Load attemptKeratometerCount from the database
        int attemptKeratometerCount = LoadAttemptKeratometerCount(playerName, adminNo);

        // Increment the attemptKeratometerCount
        attemptKeratometerCount++;

        // Update the attemptKeratometerCount in the database
        UpdateAttemptKeratometerCount(playerName, adminNo, attemptKeratometerCount);

        // Save the updated attemptKeratometerCount to PlayerPrefs
        SaveAttemptKeratometerCount(attemptKeratometerCount);
    }

    private int LoadAttemptKeratometerCount(string playerName, string adminNo)
    {
        int attemptKeratometerCount = 0;

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT AttemptKeratometer FROM student WHERE AdminNo = @adminNo AND StudentName = @studentName";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@adminNo", adminNo);
                command.Parameters.AddWithValue("@studentName", playerName);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        attemptKeratometerCount = reader.GetInt32("AttemptKeratometer");
                    }
                }
            }
        }

        return attemptKeratometerCount;
    }

  private void UpdateAttemptKeratometerCount(string playerName, string adminNo, int attemptKeratometerCount)
{
    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        connection.Open();

        string query = "UPDATE student SET AttemptKeratometer = AttemptKeratometer + 1 WHERE AdminNo = @adminNo AND StudentName = @studentName";

        using (MySqlCommand command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@adminNo", adminNo);
            command.Parameters.AddWithValue("@studentName", playerName);
            Debug.Log("Keratometer now is " + attemptKeratometerCount);
            command.ExecuteNonQuery();
        }
    }
}


    private void SaveAttemptKeratometerCount(int attemptKeratometerCount)
    {
        PlayerPrefs.SetInt(AttemptKeratometerCountKey, attemptKeratometerCount);
    }
}
