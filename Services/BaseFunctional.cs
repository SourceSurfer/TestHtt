using System.Data;
using Microsoft.Data.SqlClient;

namespace TestHtt.Services;

public class BaseFunctional : IDataService
{
    /// <summary>
    /// Вставляет данные
    /// </summary>
    /// <param name="sp">Хранимая процедура</param>
    /// <param name="paramName">Имя параметра</param>
    /// <param name="value">Значение</param>
    /// <returns>Успех</returns>
    public bool Insert(string sp, string[] paramName, object[] value)
    {
        using var connection = new SqlConService().Connection();
        using SqlCommand command = new SqlCommand(sp, connection);
        command.CommandType = CommandType.StoredProcedure;

        switch (paramName.Length)
        {
            case 3:
                command.Parameters.AddWithValue(paramName[0], value[0]);
                command.Parameters.AddWithValue(paramName[1], value[1]);
                break;
            case 5:
                command.Parameters.AddWithValue(paramName[0], value[0]);
                command.Parameters.AddWithValue(paramName[1], value[1]);
                command.Parameters.AddWithValue(paramName[2], value[2]);
                command.Parameters.AddWithValue(paramName[3], value[3]);
                command.Parameters.AddWithValue(paramName[4], value[4]);
                break;
        }


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

        switch (paramName.Length)
        {
            case 3:
                command.Parameters.AddWithValue(paramName[0], value[0]);
                command.Parameters.AddWithValue(paramName[1], value[1]);
                command.Parameters.AddWithValue(paramName[2], value[2]);
                break;
            case 6:
                command.Parameters.AddWithValue(paramName[0], value[0]);
                command.Parameters.AddWithValue(paramName[1], value[1]);
                command.Parameters.AddWithValue(paramName[2], value[2]);
                command.Parameters.AddWithValue(paramName[3], value[3]);
                command.Parameters.AddWithValue(paramName[4], value[4]);
                command.Parameters.AddWithValue(paramName[5], value[5]);
                break;
        }

        try
        {
            connection?.Open();

            //TODO когда 6 параметров возвращает -1, непонятно
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
    public bool Delete(string sp, string paramName, object value)
    {
        // TODO Сделать проверку в ХП что нельзя удалять категорию если в ней имеются элементы
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