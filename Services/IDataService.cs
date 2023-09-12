using TestHtt.Models;

namespace TestHtt.Services
{
    public interface IDataService
    {
        /// <summary>
        /// Вставляет данные
        /// </summary>
        /// <param name="sp">Хранимая процедура</param>
        /// <param name="value">Значение</param>
        /// <returns>Успех</returns>
        bool Insert(string sp, string[] paramName, object[] value);
        /// <summary>
        /// Обновляет данные
        /// </summary>
        /// <param name="sp">Хранимая процедура</param>
        /// <param name="value">Значение</param>
        /// <returns>Успех</returns>
        bool Update(string sp, string[] paramName, object[] value);
        /// <summary>
        /// Удаляет данные
        /// </summary>
        /// <param name="sp">Хранимая процедура</param>
        /// <param name="value">Значение</param>
        /// <returns>Успех</returns>
        bool Delete(string sp, string paramName, object value);
    }
}
