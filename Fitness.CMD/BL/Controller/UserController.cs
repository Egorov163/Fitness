using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователи приложения.
        /// </summary>
        public List<User> Users { get; }
        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;
        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user"> Имя нового пользователя </param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u=>u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }
        /// <summary>
        /// Получить сохранённый список пользователей.
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {           
            using (FileStream fs = new FileStream("users.json", FileMode.OpenOrCreate))
            {
                if (JsonSerializer.Deserialize<List<User>>(fs) is List<User> users) // ошибка
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }                
            }
        }

        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            // Проверка

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;  
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            using (FileStream fs = new FileStream("users.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, Users);
            }
        }
        /// <summary>
        /// Получить данные пользователя.
        /// </summary>
        /// /// <returns> Пользователь приложения. </returns>

    }
}
