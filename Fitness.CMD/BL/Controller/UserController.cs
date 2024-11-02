using Fitness.BL.Model;
using System;
using System.IO;
using System.Text.Json;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public User User { get; }
        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user"> Имя нового пользователя </param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(string userName, string genderName, DateTime birthDay, double weight, double height)
        {
            // TODO: Проверка

            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDay, weight, height);
        }
        public UserController()
        {
            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (JsonSerializer.Deserialize<User>(fs) is User user)
                {
                    User = user;
                }
                // TODO: Что делать если пользователя не прочитали
            }
        }
        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, User);
            }
        }
        /// <summary>
        /// Получить данные пользователя.
        /// </summary>

    }
}
