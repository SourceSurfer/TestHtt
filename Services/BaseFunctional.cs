using System.Data;
using Microsoft.Data.SqlClient;

namespace TestHtt.Services;

public class BaseFunctional<T> : IDataService<T>
{
    /// <summary>
    /// Вставляет данные
    /// </summary>
    /// <param name="sp">Хранимая процедура</param>
    /// <param name="paramName">Имя параметра</param>
    /// <param name="value">Значение</param>
    /// <returns>Успех</returns>
    public bool Insert(string sp, string paramName, object value)
    {
        using var connection = new SqlConService().Connection();
        using SqlCommand command = new SqlCommand(sp, connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue(paramName, value);
        try
        {
            connection?.Open();
            int result = command.ExecuteNonQuery();

            // Check Error
            if (result < 0)
            {
                Console.WriteLine("Error inserting data into Database!");
                return false;
            }

            return true;

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }

    }

   /// <summary>
   /// Обновление данных
   /// </summary>
   /// <param name="sp">Хранимая процедура</param>
   /// <param name="paramName">Имя параметра [0], где 0 номер параметра в SP</param>
   /// <param name="position">Номер строки</param>
   /// <param name="value">Значение</param>
   /// <returns>Обновленный список</returns>
    public bool Update(string sp, string[] paramName, object[] value)
    {
        using var connection = new SqlConService().Connection();
        using SqlCommand command = new SqlCommand(sp, connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue(paramName[0], value[0]);
        command.Parameters.AddWithValue(paramName[1], value[1]);
        command.Parameters.AddWithValue(paramName[2], value[2]);
        try
        {
            connection?.Open();
            int result = command.ExecuteNonQuery();
            
            // Check Error
            if (result < 0)
            {
                Console.WriteLine("Error look server inserting data into Database!");
                return false;
            }
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
      
    }

    /// <summary>
    /// Удаление данных
    /// </summary>
    /// <param name="sp">Хранимая процедура</param>
    /// <param name="paramName">Имя параметра</param>
    /// <param name="value">Значение</param>
    /// <returns>Успех</returns>
    public bool Delete(string sp, string paramName, int position, object value)
    {
        using var connection = new SqlConService().Connection();
        using SqlCommand command = new SqlCommand(sp, connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue(paramName, value);
        try
        {
            connection?.Open();
            int result = command.ExecuteNonQuery();

            // Check Error
            if (result < 0)
            {
                Console.WriteLine("Error inserting data into Database!");
                return false;
            }

            return true;

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }
}